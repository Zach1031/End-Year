using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
<<<<<<< HEAD
using UnityEngine.UI;
=======
>>>>>>> bbf1258788002d20e43dbeeb251746492433dfb0

public class GameController : MonoBehaviour
{
    public GameObject gameOverText;
<<<<<<< HEAD

    public Text youDied;
    public Text timesUp;
=======
>>>>>>> bbf1258788002d20e43dbeeb251746492433dfb0
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

<<<<<<< HEAD
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


=======
    public void GameOver()
    {
        Debug.Log("Game Over!");
        gameOverText.SetActive(true);
>>>>>>> bbf1258788002d20e43dbeeb251746492433dfb0
        SceneManager.LoadScene("Start Screen");
    }
}
