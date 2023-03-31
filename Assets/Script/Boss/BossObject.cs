using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossObject : HitObject
{
    public GameObject EnemyBullet;
    bool IsNoDie = false;

    void Start(){
        GameManager.instance.BossObj = gameObject;
        StartCoroutine(BossPattern());
        MaxHP = HP;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("PlayerBullet")){
            if(IsNoDie == false)
            BulletHit(other.gameObject);
        }
    }
    protected override void BulletHit(GameObject obj){
        base.BulletHit(obj);
        Dead();
    }
    protected override void Dead()
    {
        if(HP <= 0){
        StopAllCoroutines();
        StartCoroutine(DeadEffect());
        }
    }
    IEnumerator DeadEffect(){
        IsNoDie = true;
        CameraShake.ShakeCamera(3,0.5f);
        PaticleManager.SpawnPaticle(2,transform);
        yield return new WaitForSeconds(3);
        GameManager.StageEnd();
        base.Dead();
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
