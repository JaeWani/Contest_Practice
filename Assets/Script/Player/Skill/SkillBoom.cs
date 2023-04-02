using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBoom : MonoBehaviour
{
    public static List<GameObject> list = new List<GameObject>();

    public static void UseSkill(){
        CameraShake.ShakeCamera(1,0.5f);
        foreach(var i in list){
            if(i != null){
                var stat = i.GetComponent<StatObejct>();
                stat.HP -= 100;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy")){
            list.Add(other.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Enemy")){
           list.Remove(other.gameObject); 
        }
    }
}
