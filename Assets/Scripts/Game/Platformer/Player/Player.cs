using UnityEngine;

public class Player : MonoBehaviour
{
    public Weapon Weapon;
    public Vector3 WeaponPosition;
    public Vector3 Direction;

    public void SetWeapon(Weapon weapon)
    {
        Weapon = weapon;
        weapon.transform.SetParent(transform, false);
        weapon.transform.localPosition = WeaponPosition;
        weapon.Direction = Direction;
    }

    void Start()
    {
        var weapons = GetComponentsInChildren<Weapon>();
        foreach (var weapon in weapons)
        {
            SetWeapon(weapon);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Weapon.Shoot();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            Weapon.Reload();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Weapon.ChangeMode();
        }
    }
}