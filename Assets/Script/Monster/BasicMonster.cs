using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMonster : Monster
{

    Rigidbody2D _RB;
    [SerializeField] GameObject bullet;
    [SerializeField] float MoveSpeed;
    [SerializeField] GameObject Target;
    float curfireTime = 0;
    public float fireTime = 1;
    private void Start() {
        _RB = GetComponent<Rigidbody2D>();
        //밑으로 이동하도록 velocity 설정
        _RB.velocity = new Vector2(0,-1 * MoveSpeed);
        Target = GameObject.Find("Player");
    }
    private void Update() {
        fire();
    }
    protected override void Dead()
    {
        if(HP <= 0){
            GameManager.instance.Score += 50;
        }
        base.Dead();
    }
    void fire(){
        if(curfireTime < fireTime){
            curfireTime += Time.deltaTime;
            return;
        }
        else{
            curfireTime = 0;
            TrackingBullet();
        }
    }
    void TrackingBullet(){
        var vec = Target.transform.position - transform.position;
        var deg = Mathf.Atan2(vec.y,vec.x) * Mathf.Rad2Deg;
        Instantiate(bullet,transform.position,Quaternion.Euler(0,0,deg + 90));
    }
}
