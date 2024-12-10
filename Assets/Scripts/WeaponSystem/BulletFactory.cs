using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : GameObjectFactory<Rigidbody2D>
{
    private WeaponScriptable weaponData;
    public BulletFactory(WeaponScriptable weaponData)
    {
        this.weaponData = weaponData;
    }
    public override Rigidbody2D Create(Vector3 position, Transform parent = null)
    {
        Rigidbody2D bulletInstance = Object.Instantiate(weaponData.bulletPrefab, position, Quaternion.identity, parent);
        return bulletInstance;
    }
}