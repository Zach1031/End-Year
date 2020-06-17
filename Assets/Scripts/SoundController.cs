using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource laserSource;
    public AudioSource explosionSource;

    public bool makingNoise;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayLaser()
    {
        if(makingNoise)
            laserSource.Play();
    }

    public void PlayExplosion()
    {
        if (makingNoise)
            explosionSource.Play();
    }
}
