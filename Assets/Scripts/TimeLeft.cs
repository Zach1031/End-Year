using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLeft : MonoBehaviour
{
    public Text text;
    public float timeLeft = 1000f;

    public GameController gameController;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            timeLeft = 0;
            Destroy(player.gameObject);
            gameController.GameOver(false);
        }


        text.text = "Time Left: " + Mathf.Round(timeLeft);
    }

    public float AddTime(int time)
    {
        timeLeft += timeLeft;

        return timeLeft;
    }
}
