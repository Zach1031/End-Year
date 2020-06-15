using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFader : MonoBehaviour
{
    public float fadeAmount = 255;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        fadeAmount -= 15;

        if(fadeAmount < 1)
        {
            Destroy(this.gameObject);
        }

    }
}
