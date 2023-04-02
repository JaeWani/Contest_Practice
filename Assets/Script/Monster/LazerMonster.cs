using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerMonster : Monster
{
    [SerializeField] GameObject LazerObj;
    [SerializeField] GameObject WarningObj;
    [SerializeField] GameObject Target;

    bool IsShoot = false;

    void Start(){
        Lazer();
        Target = GameObject.Find("Player");
        var obj = LazerObj.GetComponent<LazerScript>();
        obj.LazerDamage = 10;
    }
    private void Update() {
        Dead();
        Tracking();
    }
    void Tracking(){
        var vec = Target.transform.position - transform.position;
        var deg = Mathf.Atan2(vec.y,vec.x) * Mathf.Rad2Deg;
        if(IsShoot == false)
        transform.rotation = Quaternion.Euler(0,0,deg + 90);
    }
    void Lazer(){
        StartCoroutine(Attack());
        IEnumerator Attack(){
            IsShoot = true;
            for(int i = 0; i < 2; i++){
                WarningObj.SetActive(true);
                yield return new WaitForSeconds(1);
                WarningObj.SetActive(false);
                yield return new WaitForSeconds(1);
            }
            LazerObj.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            LazerObj.SetActive(false);
            IsShoot = false;
            yield return new WaitForSeconds(2);
            StartCoroutine(Attack());
        }
    }
    protected override void Dead()
    {
        if(HP <= 0){
            GameManager.instance.Score += 50;
        }
        base.Dead();
    }
}
