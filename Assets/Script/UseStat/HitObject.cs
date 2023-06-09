using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitObject : StatObejct
{
    protected virtual void BulletHit(GameObject obj){
        if(obj != null){
        PlayerBullet bullet = obj.GetComponent<PlayerBullet>();
        float dmg = bullet.BulletDamage;
        HP -= dmg;
        }
    }
    protected virtual void EnemyBulletHit(GameObject obj){
        EnemyBullet bullet = obj.GetComponent<EnemyBullet>();
        float dmg = bullet.BulletDamage;
        HP -= dmg;
    }
    protected virtual void LazerHit(GameObject obj){
        LazerScript lazer = obj.GetComponent<LazerScript>();
        float dmg = lazer.LazerDamage;
        HP -= dmg;
    }
    protected virtual void Hit(GameObject obj){
        if(obj != null){
            StatObejct stat = obj.GetComponent<StatObejct>();
            float dmg = stat.Damage;
            HP -= dmg;
        }
    }
    protected virtual void Dead(){
        if(HP<=0)
        Destroy(gameObject);
    }
    protected virtual void _Destroy(){
        Destroy(gameObject);
    }
}
