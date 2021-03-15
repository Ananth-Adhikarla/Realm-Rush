using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleProjectileSpawn : MonoBehaviour
{

    public GameObject firePoint1;
    public GameObject firePoint2;
    public GameObject VFXs = null;
    private float timeToFire = 0f;
    public float fireRate;
    public bool isEnabled = false;
  
    public GameObject bullet1 = null, bullet2 = null;

    void Update()
    {

        if (isEnabled == true)
        {
            if (Time.time > timeToFire)
            {

                timeToFire = Time.time + 1f / fireRate;
                SpawnVFX();
            }
        }

    }

    public void SpawnVFX()
    {

        bullet1 = Instantiate(VFXs, firePoint1.transform.position, transform.localRotation);
        bullet2 = Instantiate(VFXs, firePoint2.transform.position, transform.localRotation);


        var ps1 = bullet1.GetComponent<ParticleSystem>();
        var ps2 = bullet2.GetComponent<ParticleSystem>();
    }


    public void DisableVFX()
    {
        isEnabled = false;
    }
}
