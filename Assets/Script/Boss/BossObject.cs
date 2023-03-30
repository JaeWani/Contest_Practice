using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossObject : HitObject
{
    public GameObject EnemyBullet;

    void Start(){
        GameManager.instance.BossObj = gameObject;
        StartCoroutine(BossPattern());
        MaxHP = HP;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("PlayerBullet")){
            BulletHit(other.gameObject);
        }
    }
    protected override void BulletHit(GameObject obj){
        base.BulletHit(obj);
        Dead();
    }
    protected override void Dead()
    {
        base.Dead();
        if(HP <= 0)
        StopAllCoroutines();
    }
    IEnumerator BossPattern(){
        while(true){
        yield return new WaitForSeconds(5);
        for(int i = 0; i < 36; i++){
            Instantiate(EnemyBullet,transform.position,Quaternion.Euler(0,0,i * 30));
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(3);
        for(int i = 0; i< 36; i++){
            Instantiate(EnemyBullet,transform.position,Quaternion.Euler(0,0,i*10));
        }
        }
    }
}
