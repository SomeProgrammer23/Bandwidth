using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : MonoBehaviour
{

    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;
    public Transform barrelLocation;
    public Transform casingExitLocation;
    private Transform parent;
    public int rounds = 8;


    public float shotPower = 100f;

    void Start()
    {
        parent = GameObject.Find("PlayerHand").transform;
        if (barrelLocation == null)
            barrelLocation = transform;
    }

    void Update()
    {
        if (this.transform.IsChildOf(parent))
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (rounds > 0)
                {
                    //--rounds;
                    GetComponent<Animator>().SetTrigger("Fire");
                }
            }
        }
    }

    public void Shoot()
    {
        //  GameObject bullet;
        //  bullet = Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation);
        // bullet.GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);

        GameObject tempFlash;
        //Centre Bullet
        //Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower, ForceMode.Impulse);
        //Cardinal Bullets
        Instantiate(bulletPrefab, barrelLocation.position, (barrelLocation.rotation * Quaternion.Euler(0, 30, 0))).GetComponent<Rigidbody>().AddForce((barrelLocation.forward + (barrelLocation.right / 15)) * shotPower, ForceMode.Impulse);
        Instantiate(bulletPrefab, barrelLocation.position, (barrelLocation.rotation * Quaternion.Euler(0, -30, 0))).GetComponent<Rigidbody>().AddForce((barrelLocation.forward - (barrelLocation.right / 15)) * shotPower, ForceMode.Impulse);
        Instantiate(bulletPrefab, barrelLocation.position, (barrelLocation.rotation * Quaternion.Euler(30, 0, 0))).GetComponent<Rigidbody>().AddForce((barrelLocation.forward - (barrelLocation.up / 15)) * shotPower, ForceMode.Impulse);
        Instantiate(bulletPrefab, barrelLocation.position, (barrelLocation.rotation * Quaternion.Euler(-30, 0, 0))).GetComponent<Rigidbody>().AddForce((barrelLocation.forward + (barrelLocation.up / 15)) * shotPower, ForceMode.Impulse);
        tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

        Destroy(GameObject.Find("MuzzleFlash(Clone)"), 0.5f);
        --rounds;
        //Destroy(GameObject.Find("Bullet_45mm_Casing(Clone)"), 1f);

        //  Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation).GetComponent<Rigidbody>().AddForce(casingExitLocation.right * 100f);

    }

    void CasingRelease()
    {
         GameObject casing;
        casing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        casing.GetComponent<Rigidbody>().AddExplosionForce(550f, (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        casing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(10f, 1000f)), ForceMode.Impulse);
    }


}
