using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOController : MonoBehaviour
{
    public GameObject player;
    public Sprite noTop;

    public int health = 100;

    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
    }

    //Called by the weapon when it shoots the UFO
    public bool TakeDamage(int damage)
    {
        health -= damage;

        if(health < 0)
        {
            //The UFO is dead
            //StartCoroutine(Die());
            Destroy(this.gameObject);
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
}
