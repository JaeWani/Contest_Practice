using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float BulletDamage;
    public float BulletSpeed;

    public Vector3 MoveDirection;

    public enum BulletLevel{
        LV1,LV2,LV3,LV4,LV5
    }
    [SerializeField] BulletLevel curLevel;
    void Start(){
        Invoke("_Destroy", 3);
        _SetDamage();
    }
    void Update(){
        _BulletMove();
    }
    void _BulletMove(){
        transform.Translate(MoveDirection * BulletSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy")){
            _Destroy();
        }
    }

    void _Destroy(){
        Destroy(gameObject);
    }
    void _SetDamage(){
        switch(curLevel){
            case BulletLevel.LV1:                    break;
            case BulletLevel.LV2: BulletDamage *= 2; break;
            case BulletLevel.LV3: BulletDamage *= 3; break;
            case BulletLevel.LV4: BulletDamage *= 4; break;
            case BulletLevel.LV5: BulletDamage *= 5; break;

            default:  break;
        }
    }
}
