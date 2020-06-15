using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootController : MonoBehaviour
{
    //public Image crosshair;
    public GameObject crosshair;
    public GameObject laser;
    public GameObject rotationPoint;

    public SoundController soundController;

    public Vector3 mousePos;

    public Image ammoCounter;
    public Text currentAmmoCounter;
    public Text totalAmmoCounter;

    public float fireRate = 10f;
    public float shootCooldown;

    public float MAX_MAG = 30;
    public float totalBullets = 500;
    public float bullets = 30;

    public int damage = 50;

    public float reloadTime = 2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckShoot();
        CheckReload();
        DoTransformation();
        UpdateUI();
    }

    private void DoTransformation()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //transform.LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.up);

        transform.LookAt(2 * transform.position - mousePos);

        transform.rotation = new Quaternion(0f, 0f, transform.rotation.z, transform.rotation.w);

        transform.localPosition = new Vector3(.073f, -.025f, -.1f);
    }

    public Vector3 getMousePos()
    {
        return mousePos;
    }

    private void CheckReload()
    {
        if (Input.GetKey(KeyCode.R))
            StartCoroutine(Reload());
    }

    private void CheckShoot()
    {
        if (bullets > 0)
        {

            if (Input.GetMouseButton(0) && Time.time > shootCooldown)
            {

                RaycastHit2D hit = Physics2D.Raycast(transform.position, -(2 * transform.position - mousePos));

                GameObject newLaser = Instantiate(laser);

                newLaser.SetActive(true);

                newLaser.transform.position = transform.position;
                newLaser.transform.rotation = transform.rotation;

                newLaser.transform.SetParent(rotationPoint.transform);
                newLaser.transform.localPosition = new Vector3(0.546f, .006f, 0);


                newLaser.AddComponent<LaserFader>();


                if(hit.collider != null)
                {
                    if (hit.collider.tag.Equals("Enemy"))
                    {
                        hit.collider.GetComponent<UFOController>().TakeDamage(50);
                    }
                }

                soundController.PlayLaser();

                Debug.DrawRay(transform.position, -(2 * transform.position - mousePos));

                shootCooldown = Time.time + 1 / 2f;

                bullets--;
            }
        }

        else
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);

        if (bullets < 1)
            totalBullets -= MAX_MAG;

        else
            totalBullets -= MAX_MAG - bullets;

        bullets = MAX_MAG;
    }

    private void UpdateUI()
    {
        ammoCounter.fillAmount = bullets / MAX_MAG;

        Debug.Log(bullets / MAX_MAG);

        currentAmmoCounter.text = bullets + "/" + MAX_MAG;
        totalAmmoCounter.text = totalBullets.ToString();
    }
}
