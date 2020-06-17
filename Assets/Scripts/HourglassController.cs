﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourglassController : MonoBehaviour
{
    public TimeLeft timeLeft;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayer();
    }

    private void CheckPlayer()
    {
        if (transform.position.Equals(player.transform.position))
        {
            timeLeft.AddTime(10);

            Destroy(this.gameObject);
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag.Equals("Player"))
    //    {

    //    }

    //}
}
