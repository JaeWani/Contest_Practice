using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Player : HitObject
{
    public static Player instance;

    [Header ("이동범위 제한")]
    [SerializeField]private Vector2 _moveLimit;
    public Vector3 ClampVector(Vector3 pos){
        return new Vector3(Mathf.Clamp(pos.x,-8.2f,1.2f),Mathf.Clamp(pos.y,-4.2f,4.2f),0);
    }
    [Header ("플레이어 스탯")]
    public float PlayerSpeed = 3;
    public float BulletSpeed = 8;
    [Header ("무적")]
    public bool IsNoDie = false;
    public GameObject NoDieObejct;
    public float NoDieTime = 0;
    [Header ("스킬")]
    public bool CanBoom = true;
    public bool CanHeal = true;
    [Header ("연료")]
    public float Fuel;
    private float CurChargeTime = 0;
    public float FuelChargeTime;

    [Header ("총알 프리펩")]
    [SerializeField]List<GameObject> BulletPrefabs = new List<GameObject>();
    public int BulletLV = 1;
    [Header ("UI")]
    [SerializeField] Image BoomSkill;
    [SerializeField] Image HealSkill;
    Rigidbody2D _RB;
    
    private void Awake(){
        instance = this;
        if(instance != this)
            Destroy(gameObject);

        Damage = 5;
        HP = 100;
        AttackDelay = 0.15f;
        PlayerAttack += _BasicAttack;

        Fuel = 100;
        HP = 100;
    }
    void Start(){
        _RB = GetComponent<Rigidbody2D>();
    }
    void Update(){
        _Move();
        _Attack();
        _SetValue();
        _CheatKey();
        _ChargeFuel();
        NoDie();
        Boom();
        Heal();
    }
    void _CheatKey(){
        if(Input.GetKeyDown(KeyCode.F1))
            PlayerAttack += _TripleAttack;
        if(Input.GetKeyDown(KeyCode.F2))
            PlayerAttack += _QuadrupleAttack;
        if(Input.GetKeyDown(KeyCode.F3)){
            PlayerAttack -= _QuadrupleAttack;
            PlayerAttack -= _TripleAttack;
        }         
        if(Input.GetKeyDown(KeyCode.F4))
            Fuel += 10;
    }

    Vector2 MoveVec;
    void _Move(){
        transform.localPosition = ClampVector(transform.localPosition);
       
        MoveVec.x = Input.GetAxisRaw("Horizontal") * PlayerSpeed;
        MoveVec.y = Input.GetAxisRaw("Vertical") * PlayerSpeed;
        _RB.velocity = MoveVec;
    }
    Action PlayerAttack;
    float time = 0;
    void _Attack(){
        if(time < AttackDelay){
            time += Time.deltaTime;
            return;
        }
        else {
            PlayerAttack();
            time = 0;
        }
    }
    void _BasicAttack(){
        PlayerBullet bullet = Instantiate(BulletPrefabs[BulletLV -1], transform.position,Quaternion.identity).GetComponent<PlayerBullet>();
        bullet.MoveDirection = new Vector2(0,1);
        bullet.BulletSpeed = BulletSpeed;
        bullet.BulletDamage = Damage;
    }
    void _TripleAttack(){
        if(Fuel > 0){
        Fuel -= 0.5f;
        PlayerBullet bullet1 = Instantiate(BulletPrefabs[BulletLV -1],transform.position,Quaternion.Euler(0,0, 10)).GetComponent<PlayerBullet>();
        PlayerBullet bullet2 = Instantiate(BulletPrefabs[BulletLV -1],transform.position,Quaternion.Euler(0,0,-10)).GetComponent<PlayerBullet>();

        bullet1.MoveDirection = new Vector2(0,1); 
        bullet2.MoveDirection = new Vector2(0,1);

        bullet1.BulletSpeed = BulletSpeed;
        bullet2.BulletSpeed = BulletSpeed;

        bullet1.BulletDamage = Damage;
        bullet2.BulletDamage = Damage;
        }
    }
    void _QuadrupleAttack(){
        if(Fuel > 0){
        Fuel -= 0.5f;
        PlayerBullet bullet1 = Instantiate(BulletPrefabs[BulletLV -1],transform.position,Quaternion.Euler(0,0, 20)).GetComponent<PlayerBullet>();
        PlayerBullet bullet2 = Instantiate(BulletPrefabs[BulletLV -1],transform.position,Quaternion.Euler(0,0,-20)).GetComponent<PlayerBullet>();

        bullet1.MoveDirection = new Vector2(0,1); 
        bullet2.MoveDirection = new Vector2(0,1);

        bullet1.BulletSpeed = BulletSpeed;
        bullet2.BulletSpeed = BulletSpeed;

        bullet1.BulletDamage = Damage;
        bullet2.BulletDamage = Damage;
        }
    }
    void _ChargeFuel(){
        if(CurChargeTime < FuelChargeTime){
            CurChargeTime += Time.deltaTime;
            return;
        }
        else{
            Fuel += 30;
            CurChargeTime = 0;
        }
    }
    void _SetValue(){
        if(Fuel > 100)
            Fuel = 100;
        if(HP > 100)
            HP = 100;
    }
    void NoDie(){
        if(NoDieTime > 0){
            IsNoDie = true;
            NoDieTime -= Time.deltaTime;
            NoDieObejct.SetActive(true);
        }
        else{
            NoDieObejct.SetActive(false);
            IsNoDie = false;
        }
    }
    void Boom(){
        if(Input.GetKeyDown(KeyCode.G)){
            if(CanBoom == true){
            SkillBoom.UseSkill();
            StartCoroutine(BoomCoolTime(30));
            }
        }
    }
    IEnumerator BoomCoolTime(float Cool){
        CanBoom = false;
        float cool = 0;
        while(cool < Cool){
            cool += Time.deltaTime;
            BoomSkill.fillAmount = cool / Cool;
            yield return new WaitForFixedUpdate();
        }
        CanBoom = true;
    }
    void Heal(){
        if(Input.GetKeyDown(KeyCode.F)){
            if(CanHeal == true){
            HP += 50;
            StartCoroutine(HealCoolTime(10));
            }
        }
    }
    IEnumerator HealCoolTime(float Cool){
        CanHeal = false;
        float cool = 0;
        while(cool < Cool){
            cool += Time.deltaTime;
            HealSkill.fillAmount = cool/Cool;
            yield return new WaitForFixedUpdate();
        }
        CanHeal = true;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(IsNoDie == false){
        if(other.CompareTag("Enemy")){
            Hit(other.gameObject);
        }
        else if(other.CompareTag("EnemyBullet")){
            EnemyBulletHit(other.gameObject);
        }
        else if(other.CompareTag("EnemyLazer")){
            LazerHit(other.gameObject);
        }
        }
    }
    protected override void Hit(GameObject obj)
    {
        base.Hit(obj);
        CameraShake.ShakeCamera(0.3f,0.2f);
    }
    protected override void EnemyBulletHit(GameObject obj)
    {
        base.EnemyBulletHit(obj);
        CameraShake.ShakeCamera(0.3f,0.2f);
    }
    protected override void LazerHit(GameObject obj)
    {
        base.LazerHit(obj);
        CameraShake.ShakeCamera(0.3f,0.2f);
    }
}   
