using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float BulletDamage;
    public float BulletSpeed;
    public Vector3 MoveDirection = new Vector2(0,1);
    void Update(){
        _BulletMove();
    }
    void _BulletMove(){
        transform.Translate(MoveDirection * BulletSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            PaticleManager.SpawnPaticle(0,transform);
            _Destroy();
        }
    }
    void _Destroy(){
        Destroy(gameObject);
    }
}
