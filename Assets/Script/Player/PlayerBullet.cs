using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float BulletDamage;
    public float BulletSpeed;

    public Vector3 MoveDirection;

    void Start()
    {
        Invoke("_Destroy", 3);
    }
    void Update()
    {
        _BulletMove();
    }
    void _BulletMove()
    {
        transform.Translate(MoveDirection * BulletSpeed * Time.deltaTime);
    }
    void _Destroy()
    {
        Destroy(gameObject);
    }
}
