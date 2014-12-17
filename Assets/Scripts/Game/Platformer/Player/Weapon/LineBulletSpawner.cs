using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

[Serializable]
public class LineBulletSpawner : IBulletSpawner
{
    public Weapon Weapon { get; set; }
    public List<Bullet> Shooted { get; private set; }

    public LineBulletSpawner()
    {
        Shooted = new List<Bullet>();
    }

    public int Shoot()
    {
        var bullet = SpawnerHelper.Create(Weapon);
        Shooted.Add(bullet);
        return 1;
    }
}