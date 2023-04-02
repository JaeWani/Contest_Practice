using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : HitObject
{
    public static int A;
    protected virtual void RandomItemSpawn(){
        int rand = Random.Range(1,21);
        switch(rand){           
            case 1: GameManager.SpawnItem(0,transform); break;
            case 2: GameManager.SpawnItem(1,transform); break;
            case 3: GameManager.SpawnItem(2,transform); break;
            case 4: GameManager.SpawnItem(3,transform); break;
            default:                                    break;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("PlayerBullet")){
            BulletHit(other.gameObject);
        }
    }
    protected override void BulletHit(GameObject obj){
        base.BulletHit(obj);
    }
    protected override void Dead()
    {
        base.Dead();
        Debug.Log("ASD");
        if(GameManager.instance.IsBoss == true)
            Destroy(gameObject);
        if(HP <= 0){
        GameManager.instance.KillMonsterCount++;
        RandomItemSpawn();
        PaticleManager.SpawnPaticle(1,transform);
        }
    }
    protected override void _Destroy(){
        Destroy(gameObject);
    }
}
