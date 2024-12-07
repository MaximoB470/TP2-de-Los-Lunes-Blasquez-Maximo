using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    public WeaponScriptable weaponData;
    public int poolSize = 1;  
    private Queue<Rigidbody2D> bulletPool = new Queue<Rigidbody2D>();

    // No conectar factory pool con la bala como si fueran "hermanos"   //hacer bullet manager para la pool xd

    void Start()
    {
        InitializeBulletPool();
    }
    private void InitializeBulletPool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            Rigidbody2D bullet = Instantiate(weaponData.bulletPrefab, Vector3.zero, Quaternion.identity);
            bullet.gameObject.SetActive(false);  
            bulletPool.Enqueue(bullet);
        }
    }
    public Rigidbody2D GetBulletFromPool(Transform firePoint)
    {
        Rigidbody2D bullet;
        if (bulletPool.Count > 0)
        {
            bullet = bulletPool.Dequeue();
        }
        else
        {
            bullet = Instantiate(weaponData.bulletPrefab, firePoint.position, firePoint.rotation);
        }
        bullet.gameObject.SetActive(true);
        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = firePoint.rotation;
        bullet.velocity = Vector2.zero;

        if (bullet.TryGetComponent<Bullet>(out Bullet bulletScript))
        {
            bulletScript.Initialize(this);
        }
        return bullet;
    }
    public void ReturnBulletToPool(Rigidbody2D bullet)
    {
        bullet.gameObject.SetActive(false);  
        bulletPool.Enqueue(bullet);  
    }
}