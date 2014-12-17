using System.Collections.Generic;
using UnityEngine;

public class ThreeBulletSpawner : IBulletSpawner
{
    public Weapon Weapon { get; set; }
    public List<Bullet> Shooted { get; private set; }

    public ThreeBulletSpawner()
    {
        Shooted = new List<Bullet>();
    }

    public int Shoot()
    {
        for (int i = 0; i < 3; i++)
        {
            var bullet = SpawnerHelper.Create(Weapon);
            Shooted.Add(bullet);
            if (i == 0)
            {
                bullet.Direction = Weapon.Direction;
            }
            if (i == 1)
            {
                bullet.Direction = Weapon.Direction + new Vector3(0, 0.5f);
            }
            if (i == 2)
            {
                bullet.Direction = Weapon.Direction + new Vector3(0, -0.5f);
            }
        }
        
        return 1;
    }

   
}

public class SpawnerHelper
{
    public static Bullet Create(Weapon weapon)
    {
        var go = Object.Instantiate(weapon.bulletPrefab) as GameObject;
        go.transform.SetParent(weapon.bulletRoot, true);
        go.transform.position = weapon.transform.position + weapon.BulletSpawnPosition;
        var bullet = go.GetComponent<Bullet>();
        bullet.Weapon = weapon;
        bullet.Direction = weapon.Direction;
        bullet.Speed = weapon.BulletSpeed;
        return bullet;
    }
}