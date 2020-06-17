using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject gameOverText;

    public Text youDied;
    public Text timesUp;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver(bool died)
    {
        //if (died)
        //    youDied.enabled = true;

        //else
        //    timesUp.enabled = true;

        //Debug.Log("Game Over!");
        //gameOverText.SetActive(true);
        //StartCoroutine(WaitABit());
        //SceneManager.LoadScene("Start Screen");

        StartCoroutine(TimeToDie(died));
    }

    private IEnumerator TimeToDie(bool died)
    {
        if (died)
            youDied.enabled = true;

        else
            timesUp.enabled = true;

        Debug.Log("Game Over!");
        gameOverText.SetActive(true);

        yield return new WaitForSeconds(3f);


        SceneManager.LoadScene("Start Screen");
    }
}
