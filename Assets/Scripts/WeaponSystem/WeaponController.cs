using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponController : MonoBehaviour
{
    public WeaponScriptable weaponData;  
    public Transform firePoint;         
    private bool canShoot = true;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }
    private IEnumerator Shoot()
    {
        canShoot = false;
        while (Input.GetButton("Fire1"))
        {
            Rigidbody2D bullet = Instantiate(weaponData.bulletPrefab, firePoint.position, firePoint.rotation);
            yield return new WaitForSeconds(weaponData.shootRate);
        }
        canShoot = true;
    }
}

