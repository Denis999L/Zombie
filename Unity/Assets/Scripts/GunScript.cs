using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{
    public int damage = 10;
    public float range = 100f;
    public float fireRate = 15f;

    public int maxAmmo = 30;
    public int currentAmmo;
    public float reloadTime = 2f;
    private bool isReloading = false;

    public ParticleSystem muzzleFlash;
    public Camera fpsCam;

    private float nextTimeTofire = 0f;

    private AmmoDisplay ammoDisplay;

   void Start()
    {
        currentAmmo = maxAmmo;
        ammoDisplay = GameObject.Find("MainCanvas").GetComponent<AmmoDisplay>();
        ammoDisplay.UpdateAmmo(currentAmmo);
    }
    
    
    // Update is called once per frame
    void Update()
    {
        
        if (isReloading)
            return;

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeTofire)
        {
            nextTimeTofire = Time.time + 1 / fireRate;
            Shoot();
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading");
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        ammoDisplay.UpdateAmmo(currentAmmo);
        isReloading = false;
    }

    void Shoot()
    {
        muzzleFlash.Play();

        currentAmmo--;
        ammoDisplay.UpdateAmmo(currentAmmo);

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
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
