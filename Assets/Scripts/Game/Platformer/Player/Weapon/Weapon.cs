using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public bool IsCloseCombat = false;

    public Vector3 BulletSpawnPosition;
    public float BulletSpeed;
    public Vector3 Direction;
    [SerializeField]
    public IBulletSpawner _spawner;
    public GameObject bulletPrefab;
    public int MagazineSize = 10;
    public int LeftBullets = 10;

    

    public List<IBulletSpawner> Modes = new List<IBulletSpawner>()
                                        {
                                            new LineBulletSpawner(),
                                            new ThreeBulletSpawner()
                                        };

    public int modeIndex = 0;
    public Transform bulletRoot;

    public void ChangeMode()
    {
        modeIndex++;
        if (modeIndex >= Modes.Count)
        {
            modeIndex = 0;
        }
        Spawner = Modes[modeIndex];
    }

    public IBulletSpawner Spawner
    {
        get
        {
            return _spawner;
        }
        set
        {
            _spawner = value;
            _spawner.Weapon = this;
        }
    }

    public bool CanShoot
    {
        get
        {
            return LeftBullets > 0;
        }
    }

    void Start()
    {
        Spawner = new LineBulletSpawner();
    }

    public void Shoot(bool ignoreCanShoot = false)
    {
        if (CanShoot || ignoreCanShoot)
        {
            var bulletSpawned = Spawner.Shoot();
            LeftBullets -= bulletSpawned;
        }
    }

    public void Reload()
    {
        LeftBullets = MagazineSize;
    }
}