using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public int damage = 10;
    public float range = 100f;
    public float fireRate = 15f;

    public ParticleSystem muzzleFlash;
    public Camera fpsCam;

    private float nextTimeTofire = 0f;

    // Update is called once per frame
    void Update()
    {
       if (Input.GetButtonDown("Fire1")&& Time.time >= nextTimeTofire)
        {
            nextTimeTofire = Time.time + 1f / fireRate;
            Shoot();
        } 
    }

    void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}
