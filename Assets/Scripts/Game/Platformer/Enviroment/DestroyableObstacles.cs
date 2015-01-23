using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class DestroyableObstacles : MonoBehaviour
{

    public bool ByCloseCombat = true;
    public bool ByRangeCombat = true;

    public GameObject SpawnOnHit;

    void OnTriggerEnter2D(Collider2D other)
    {
        var bullet = other.gameObject.GetComponent<Bullet>();
        if (bullet)
        {
            if (bullet.Weapon.IsCloseCombat && ByCloseCombat || (!bullet.Weapon.IsCloseCombat && ByRangeCombat))
            {
                bullet.Hit();

                if (SpawnOnHit)
                {
                    var go = Instantiate(SpawnOnHit) as GameObject;
                    go.transform.position = transform.position;
                }

                Destroy(gameObject);
            }
        }
    }
}
