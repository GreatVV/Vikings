using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 3f;

    public Weapon Weapon;

    public Vector3 Direction;

    public float Speed;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    public void Move(float time)
    {
        transform.position += Direction * Speed * time;
    }

    void Update()
    {
        Move(Time.deltaTime);
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}