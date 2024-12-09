using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Transform firePoint;
    public BulletFactory bulletFactory;
    public WeaponScriptable weaponData;

    private float shootCooldown;

    void Update()
    {
        shootCooldown -= Time.deltaTime;
        if (Input.GetButton("Fire1") && shootCooldown <= 0f)
        {
            Shoot();
            shootCooldown = 1f / weaponData.shootRate; 
        }
    }
    private void Shoot()
    {
        Rigidbody2D bullet = bulletFactory.GetBulletFromPool(firePoint);

        if (bullet.TryGetComponent<Bullet>(out Bullet bulletScript))
        {
            bulletScript.rb.velocity = firePoint.up * bulletScript.speed;
            var audioService = new AudioService();
            ServiceLocator.Instance.Register<IAudioService>(audioService);
            audioService.ShootSound();
        }
        Debug.Log("Bullet Factory Spawn");
    }
}