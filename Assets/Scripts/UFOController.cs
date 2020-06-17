using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOController : MonoBehaviour
{
    public GameObject player;
    public Sprite noTop;

    public int health = 100;

    public float speed = 10f;

    public SoundController soundController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();

        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        Debug.DrawRay(transform.position, player.transform.position, Color.red, .001f);

        CheckCollision();
    }

    //Called by the weapon when it shoots the UFO
    public bool TakeDamage(int damage)
    {
        health -= damage;

        if(health < 1)
        {
            //The UFO is dead
            Die();
            return true;
        }

        GetComponent<SpriteRenderer>().sprite = noTop;

        return false;

    }

    private void MoveToPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    public void SetPlayer(GameObject player)
    {
        this.player = player;
    }

    //private IEnumerator Die()
    //{

    //}

    private void Die()
    {
        Debug.Log("I'm Died");
        soundController.PlayExplosion();
        DestroyImmediate(this.gameObject);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag.Equals("Player"))
    //    {
    //        collision.gameObject.GetComponent<PlayerController>().TakeDamage();
    //        DestroyImmediate(this.gameObject);
    //    }
    //}

    private void CheckCollision()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, player.transform.position, .1f);

        if(hit.collider.gameObject != null)
        {
            if (hit.collider.gameObject.tag.Equals("Player"))
            {
                //Debug.Log(hit.collider.gameObject);

                hit.collider.gameObject.GetComponent<PlayerController>().TakeDamage();
                Die();
            }
        }
    }
}
