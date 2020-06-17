using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public Rigidbody2D rb;

    public GameController gameController;
    public ArrayList liveList;
    public GameObject head1;
    public GameObject head2;
    public GameObject head3;

    public GameObject weapon;

    Vector2 movement;

    public int lives = 3;



    // Start is called before the first frame update
    void Start()
    {
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        liveList = new ArrayList { head3, head2, head1};
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        checkFlip();
    }

    private void FixedUpdate()
    {
        //rb.MovePosition(rb.position + movement * walkSpeed * Time.deltaTime);
        rb.MovePosition(rb.position + movement * walkSpeed * Time.deltaTime);
    }

    public void TakeDamage()
    {
        GetComponent<SpriteRenderer>().color = Color.red;

        lives--;

        StartCoroutine(WaitABit());

        CheckDeath();

        Destroy((GameObject)liveList[lives]);

        GetComponent<SpriteRenderer>().color = Color.white;
    }

    private IEnumerator WaitABit()
    {
        yield return new WaitForSeconds(.5f);
    }

    private void CheckDeath()
    {
        if(lives < 0)
        {
            gameController.GameOver(true);
            DestroyImmediate(this.gameObject);
        }
    }

    private void checkFlip()
    {
        if (weapon.GetComponent<ShootController>().getMousePos().x >= 1.3 * transform.position.x)
        {
            transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w);
            weapon.GetComponent<ShootController>().DoTransformation(-.1f, false);
        }

        else
        {
            transform.rotation = new Quaternion(transform.rotation.x, 180, transform.rotation.x, transform.rotation.w);
            weapon.GetComponent<ShootController>().DoTransformation(.1f, true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Nice");
    }
}
