using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject UFO;
    public GameObject player;

    public int rate = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnUFOS();
    }

    private void SpawnUFOS()
    {
<<<<<<< HEAD
        if(Random.Range(0, 1000) < rate)
=======
        if(Random.Range(0, 100) < rate)
>>>>>>> bbf1258788002d20e43dbeeb251746492433dfb0
        {
            GameObject newUFO = Instantiate(UFO);
            newUFO.transform.position = transform.position;
            newUFO.GetComponent<UFOController>().SetPlayer(player);
        }
    }
}
