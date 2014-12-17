using UnityEngine;
using System.Collections;

public class AutoShoot : MonoBehaviour
{

    public Weapon Weapon;

    public float interval = 0.5f;

    public void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        yield return new WaitForSeconds(interval);
        Weapon.Shoot(true);
        StartCoroutine(Shoot());
    }
}
