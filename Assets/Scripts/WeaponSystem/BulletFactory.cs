using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IBulletFactory
{
    Bullet CreateBullet(Transform firePoint);
}
public class BulletFactory : MonoBehaviour, IBulletFactory
{
    public static BulletFactory Instance { get; private set; }
    public Bullet bulletPrefab;

    public void Start()
    {
        ServiceLocator.Instance.Register<BulletFactory>(this);
    }

    public Bullet CreateBullet(Transform firePoint)
    {
        Bullet newBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        newBullet.Initialize(firePoint);  
        return newBullet;
    }
}