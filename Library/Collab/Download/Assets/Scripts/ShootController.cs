using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootController : MonoBehaviour
{
    //public Image crosshair;
    public GameObject crosshair;
    public GameObject laser;
    public GameObject rotationPoint;


    public float fireRate = 10f;
    public float shootCooldown;

    public int MAX_MAG = 30;
    public int totalBullets = 500;
    public int bullets = 30;

    public int damage = 50;

    public float reloadTime = 2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AimCrosshair();
        CheckShoot();
        CheckReload();
        DoTransformation();
        LockPosition();



        //Debug.Log(crosshair.transform.position);

    }

    private void LockPosition()
    {

    }

    private void DoTransformation()
    {
        //transform.LookAt(crosshair.transform);

        //Vector3.RotateTowards(transform.position, crosshair.transform.position, 2 * Mathf.PI, 100f);
        transform.rotation = new Quaternion(0, 0, transform.rotation.z, transform.rotation.w);


        transform.localPosition = new Vector3(.073f, -.025f, -.1f);
    }

    private void AimCrosshair()
    {

    }

    private void CheckReload()
    {
        if (Input.GetKey(KeyCode.R))
            StartCoroutine(Reload());
    }

    private void CheckShoot()
    {
        if (bullets > 0)
        {

            if (Input.GetMouseButton(0) && Time.time > shootCooldown)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right*10);
                GameObject newLaser = Instantiate(laser);

                newLaser.SetActive(true);

                newLaser.transform.position = transform.position;
                newLaser.transform.rotation = transform.rotation;

                newLaser.transform.SetParent(rotationPoint.transform);
                newLaser.transform.localPosition = new Vector3(0.546f, .006f, 0);


                newLaser.AddComponent<LaserFader>();


                if (hit.collider.tag.Equals("Enemy"))
                {
                    hit.collider.GetComponent<UFOController>().TakeDamage(50);
                }

                Debug.DrawRay(transform.position, Vector2.right, Color.red);

                shootCooldown = Time.time + 1 / 2f;
            }
        }

        else
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);

        if (bullets < 1)
            totalBullets -= MAX_MAG;

        else
            totalBullets -= (MAX_MAG - bullets);

        bullets = MAX_MAG;
    }
}
