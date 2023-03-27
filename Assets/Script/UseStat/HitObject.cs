using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitObject : StatObejct
{
    protected void Hit(GameObject obj)
    {
        if(obj != null){
        PlayerBullet bullet = obj.GetComponent<PlayerBullet>();
        float dmg = bullet.BulletDamage;
        HP -= dmg;
        }
    }
}
