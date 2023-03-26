using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : HitObject
{
    [Header ("플레이어 스탯")]
    public float PlayerSpeed = 3;

    public float BulletSpeed = 8;

    [Header ("총알 프리펩")]
    [SerializeField] List<GameObject> BulletPrefabs = new List<GameObject>();
    Rigidbody2D _RB;


    private void Awake() 
    {
        Damage = 5;
        HP = 100;
        AttackDelay = 0.15f;
        PlayerAttack += _BasicAttack;
    }

    void Start()
    {
        _RB = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        _Move();
        _Attack();
        if(Input.GetKeyDown(KeyCode.F1))
            PlayerAttack += _TripleAttack;
        if(Input.GetKeyDown(KeyCode.F2))
            PlayerAttack += _QuadrupleAttack;
        if(Input.GetKeyDown(KeyCode.F3)){
            PlayerAttack -= _QuadrupleAttack;
            PlayerAttack -= _TripleAttack;
        }
    }
    Vector2 MoveVec;
    void _Move()
    {
        MoveVec.x = Input.GetAxisRaw("Horizontal") * PlayerSpeed;
        MoveVec.y = Input.GetAxisRaw("Vertical") * PlayerSpeed;
        _RB.velocity = MoveVec;
    }
    Action PlayerAttack;
    float time = 0;
    void _Attack()
    {
        if(time < AttackDelay){
            time += Time.deltaTime;
            return;
        }
        else {
            PlayerAttack();
            time = 0;
        }
    }
    void _BasicAttack()
    {
        PlayerBullet bullet = Instantiate(BulletPrefabs[0], transform.position,Quaternion.identity).GetComponent<PlayerBullet>();
        bullet.MoveDirection = new Vector2(0,1);
        bullet.BulletSpeed = BulletSpeed;
        bullet.BulletDamage = Damage;
    }
    void _TripleAttack()
    {
        PlayerBullet bullet1 = Instantiate(BulletPrefabs[0],transform.position,Quaternion.Euler(0,0, 10)).GetComponent<PlayerBullet>();
        PlayerBullet bullet2 = Instantiate(BulletPrefabs[0],transform.position,Quaternion.Euler(0,0,-10)).GetComponent<PlayerBullet>();

        bullet1.MoveDirection = new Vector2(0,1); 
        bullet2.MoveDirection = new Vector2(0,1);

        bullet1.BulletSpeed = BulletSpeed;
        bullet2.BulletSpeed = BulletSpeed;

        bullet1.BulletDamage = Damage;
        bullet2.BulletDamage = Damage;
    }
    void _QuadrupleAttack()
    {
        PlayerBullet bullet1 = Instantiate(BulletPrefabs[0],transform.position,Quaternion.Euler(0,0, 20)).GetComponent<PlayerBullet>();
        PlayerBullet bullet2 = Instantiate(BulletPrefabs[0],transform.position,Quaternion.Euler(0,0,-20)).GetComponent<PlayerBullet>();

        bullet1.MoveDirection = new Vector2(0,1); 
        bullet2.MoveDirection = new Vector2(0,1);

        bullet1.BulletSpeed = BulletSpeed;
        bullet2.BulletSpeed = BulletSpeed;

        bullet1.BulletDamage = Damage;
        bullet2.BulletDamage = Damage;
    }
}   
