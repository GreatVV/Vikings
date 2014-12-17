using System;
using System.Collections.Generic;


public interface IBulletSpawner
{
    Weapon Weapon { get; set; }
    List<Bullet> Shooted { get; }
    int Shoot();
}