using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    public GameObject cow;

    public bool flyingAway;
    public bool loading;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CowRotate();

        if (Input.GetKey(KeyCode.Return) && !loading)
            StartCoroutine(StartGame());

        if (flyingAway)
            FlyAway();
    }

    private void CowRotate()
    {
        cow.transform.Rotate(new Vector3(0, 0, -2f));
    }

    private IEnumerator StartGame()
    {
        flyingAway = true;
        loading = true;

        yield return new WaitForSeconds(2);

        SceneManager.LoadScene("End Year");
    }

    private void FlyAway()
    {
        transform.Translate(new Vector3(0, 2f, 0));
    }
}
