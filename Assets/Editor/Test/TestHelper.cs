using UnityEngine;

public class TestHelper
{
    public static Player GetPlayer()
    {
        var player = Object.FindObjectOfType<Player>();
        if (player)
        {
            return player;
        }
        return new GameObject("Player", typeof (Player)).GetComponent<Player>();
    }

    public static Weapon GetWeapon()
    {
        return new GameObject("Weapon", typeof (Weapon)).GetComponent<Weapon>();
    }

    public static GameObject GetBullet()
    {
        return new GameObject("Bullet",typeof(Bullet));
    }
}