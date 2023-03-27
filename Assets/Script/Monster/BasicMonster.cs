using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMonster : HitObject
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("PlayerBullet")){
            Hit(other.gameObject);
        }
    }
}
