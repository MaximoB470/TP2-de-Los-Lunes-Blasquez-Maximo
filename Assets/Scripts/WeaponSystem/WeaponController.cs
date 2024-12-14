using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Transform firePoint;  
    public IBulletFactory bulletFactory;  

    private float shootCooldown;

    private void Start()
    {
        if (bulletFactory == null)
        {
            bulletFactory = ServiceLocator.Instance.GetService<BulletFactory>();
        }

    
    }
    private void Update()
    {
        shootCooldown -= Time.deltaTime;

        if (Input.GetButton("Fire1") && shootCooldown <= 0f)
        {
            Shoot();
            shootCooldown = 0.5f;
        }
    }

    private void Shoot()
    {
        Bullet bullet = bulletFactory.CreateBullet(firePoint);

        var audioService = ServiceLocator.Instance.GetService<IAudioService>();
        if (audioService != null)
        {
            audioService.ShootSound();
        }
    }
}