using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : HitObject
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("PlayerBullet")){
            BulletHit(other.gameObject);
        }
    }
    protected override void BulletHit(GameObject obj){
        base.BulletHit(obj);
        Dead();
    }
}
