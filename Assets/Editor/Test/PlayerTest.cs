using NUnit.Framework;
using UnityEngine;
using System.Collections;

[TestFixture]
public class PlayerTest 
{
    [Test]
    public void CreateWeaponTest()
    {
        var player = TestHelper.GetPlayer();
        player.WeaponPosition = new Vector2(10, 10);

        var weapon = TestHelper.GetWeapon();
        player.SetWeapon(weapon);

        Assert.AreSame(weapon, player.Weapon);
        Assert.That(weapon.transform.IsChildOf(player.transform));
        Assert.That(weapon.transform.position == (player.transform.position + player.WeaponPosition));
    }

    
}