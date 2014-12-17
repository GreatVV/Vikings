using System.Linq;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class WeaponTest
{
    [Test]
    public void InitWeaponWithLineSpawnerShootAndCheckChildExistAndRightDirection()
    {
        var player = TestHelper.GetPlayer();
        player.Direction = new Vector3(1f,0f);
        player.WeaponPosition = new Vector3(1f, 0.5f);

        Weapon weapon = TestHelper.GetWeapon();
        weapon.BulletSpawnPosition = new Vector3(1f, 0.5f);
        weapon.BulletSpeed = 1f;
        weapon.bulletPrefab = TestHelper.GetBullet();
        player.SetWeapon(weapon);

        Assert.AreEqual(player.Direction, weapon.Direction);

        var lineBulletSpawner = new LineBulletSpawner();
        

        weapon.Spawner = lineBulletSpawner;

        Assert.AreSame(lineBulletSpawner, weapon.Spawner);
        Assert.AreSame(lineBulletSpawner.Weapon, weapon);

        weapon.Shoot();

        var bullet = lineBulletSpawner.Shooted.First();
        Assert.AreSame(bullet.transform, weapon.bulletRoot.transform.GetChild(0));
        Assert.AreSame(weapon, bullet.Weapon);

        Assert.AreEqual(new Vector3(2f, 1f), bullet.transform.position);

        bullet.Move(1f);

        Assert.AreEqual(new Vector3(3f, 1f), bullet.transform.position);

    }

    [Test]
    public void ReloadTestShootBulletAndChangeAmountOfBullets()
    {
        var weapon = TestHelper.GetWeapon();
        weapon.bulletPrefab = TestHelper.GetBullet();
        weapon.Spawner = new LineBulletSpawner();

        weapon.MagazineSize = 1;
        weapon.LeftBullets = 1;

        Assert.IsTrue(weapon.CanShoot);

        weapon.Shoot();

        Assert.AreEqual(0, weapon.LeftBullets);

        Assert.IsFalse(weapon.CanShoot);

        weapon.Reload();

        Assert.IsTrue(weapon.CanShoot);
        Assert.AreEqual(weapon.MagazineSize, weapon.LeftBullets);
    }
}