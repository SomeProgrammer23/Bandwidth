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
        //Assigns player hand as parent
        parent = GameObject.Find("PlayerHand").transform;
        if (barrelLocation == null)
            barrelLocation = transform;
    }

    void Update()
    {
        //Starts animation to begin on input
        if (this.transform.IsChildOf(parent))
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (rounds > 0)
                {
                    GetComponent<Animator>().SetTrigger("Fire");
                }
            }
        }
    }

    //This method is used to shoot, and is called during animation.
    public void Shoot()
    {
        GameObject tempFlash;
        Instantiate(bulletPrefab, barrelLocation.position, (barrelLocation.rotation * Quaternion.Euler(0, 30, 0))).GetComponent<Rigidbody>().AddForce((barrelLocation.forward + (barrelLocation.right / 15)) * shotPower, ForceMode.Impulse);
        Instantiate(bulletPrefab, barrelLocation.position, (barrelLocation.rotation * Quaternion.Euler(0, -30, 0))).GetComponent<Rigidbody>().AddForce((barrelLocation.forward - (barrelLocation.right / 15)) * shotPower, ForceMode.Impulse);
        Instantiate(bulletPrefab, barrelLocation.position, (barrelLocation.rotation * Quaternion.Euler(30, 0, 0))).GetComponent<Rigidbody>().AddForce((barrelLocation.forward - (barrelLocation.up / 15)) * shotPower, ForceMode.Impulse);
        Instantiate(bulletPrefab, barrelLocation.position, (barrelLocation.rotation * Quaternion.Euler(-30, 0, 0))).GetComponent<Rigidbody>().AddForce((barrelLocation.forward + (barrelLocation.up / 15)) * shotPower, ForceMode.Impulse);
        tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);
        FindObjectOfType<AudioManager>().Play("ShotgunFire");
        Destroy(GameObject.Find("MuzzleFlash(Clone)"), 0.5f);
        --rounds;
    }

    //Creates a casing object, and is called during animation
    void CasingRelease()
    {
        GameObject casing;
        casing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        casing.GetComponent<Rigidbody>().AddExplosionForce(550f, (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        casing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(10f, 1000f)), ForceMode.Impulse);
        Destroy(GameObject.Find("Bullet_45mm_Casing(Clone)"), 1f);
    }


}
