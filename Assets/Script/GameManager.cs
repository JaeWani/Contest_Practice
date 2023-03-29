using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header ("플레이어")]
    [SerializeField]GameObject PlayerObject;
    [SerializeField]Player CurPlayer;

    [Header ("스폰 로직 관련")]
    [SerializeField]float SpawnTime;
                    float CurSpawnTime;
    [SerializeField]public List<GameObject> MonsterList = new List<GameObject>();

    [Header ("Score")]
    public int Score = 0;
    public List<int> ScoreIncrement = new List<int>();
    [SerializeField]float GetScoreTime;
                    float CurScoreTime;
    [Header ("Stage")]
    public int StageNum = 1;
    public int KillMonsterCount = 0;
    public int TargetMonsterCount = 50;
    public bool IsBoss = false;


    [Header ("UI")]
    [SerializeField]Slider FuelBar;
    [SerializeField]Slider DurabilityBar;
    [SerializeField]Slider BossHPBar;
    [SerializeField]Text ScoreText;
    [SerializeField]Text MonsterCountText;
    [SerializeField]Text BossText;
    [SerializeField]Image BossImage;
    [Header ("아이템 프리펩")]
    [SerializeField]List<GameObject> ItemPrefabs = new List<GameObject>();
    private void Awake() {
        instance = this;  
        if(instance != this)
            Destroy(gameObject);  
    }
    void Start(){
        PlayerObject = GameObject.Find("Player");
        CurPlayer = PlayerObject.GetComponent<Player>();
       
    }

    void Update(){
        SpawnLogic();
        UISet();
        ScoreUp();
        BossFight();
    }
    void SpawnLogic(){
        if(IsBoss == false){
        if(CurSpawnTime < SpawnTime){
            CurSpawnTime += Time.deltaTime;
            return;
        }
        else{
        Vector2 vec = new Vector2(Random.Range(-8,2), 6);
        Instantiate(MonsterList[0],vec,Quaternion.identity);      
        CurSpawnTime = 0;      
        }
        }
    }
    void ScoreUp(){
        if(CurScoreTime < GetScoreTime){
            CurScoreTime += Time.deltaTime;
            return;
        }
        else{
            CurScoreTime = 0;
            Score += ScoreIncrement[StageNum -1];
        }
    }

    void UISet(){
        float fuel = CurPlayer.Fuel;
        float durability = CurPlayer.HP;

        FuelBar.value = fuel/100;
        DurabilityBar.value = durability/100;

        ScoreText.text = Score + "점";

        if(IsBoss == true){
            MonsterCountText.gameObject.SetActive(false);
            BossHPBar.gameObject.SetActive(true);
        }
        else{
            BossHPBar.gameObject.SetActive(false);
            MonsterCountText.gameObject.SetActive(true);
            MonsterCountText.text = TargetMonsterCount - KillMonsterCount +"마리";
        }
    }
    void BossFight(){
        if(IsBoss == false && KillMonsterCount >= TargetMonsterCount){
        IsBoss = true;
        TextFadeInOut(BossText, 2);
        ImageFadeInOut(BossImage,2);
        StartCoroutine(BossSpawn());
        }
    }
    IEnumerator BossSpawn(){
        yield return new WaitForSeconds(5);
        Debug.Log("스폰");
    }
    void TextFadeInOut(Text obj, int count){
        StartCoroutine(Fade());
        obj.gameObject.SetActive(true);
        IEnumerator Fade(){
            Color cur = obj.color;
            Color c = new Color(cur.r,cur.g,cur.b,0);
            for(int j = 0; j < count; j++){
                for(int i = 0; i < 100; i++){
                obj.color = c;
                c.a += 0.01f;
                yield return new WaitForSeconds(0.01f);
                }
                for(int i = 100; i > 0; i--){
                obj.color = c;
                c.a -= 0.01f;
                yield return new WaitForSeconds(0.01f);
                }
            }
            obj.gameObject.SetActive(false);
        }
    }
    void ImageFadeInOut(Image obj, int count){
        StartCoroutine(Fade());
        obj.gameObject.SetActive(true);
        IEnumerator Fade(){
            Color cur = obj.color;
            Color c = new Color(cur.r,cur.g,cur.b,0);
            for(int j = 0; j < count; j++){
                for(int i = 0; i < 100; i++){
                obj.color = c;
                c.a += 0.01f;
                yield return new WaitForSeconds(0.01f);
                }
                for(int i = 100; i > 0; i--){
                obj.color = c;
                c.a -= 0.01f;
                yield return new WaitForSeconds(0.01f);
                }
            }
            obj.gameObject.SetActive(false);
        }
    }

    public static void SpawnItem(int index, Transform pos){
        instance._SpawnItem(index, pos);
    }
    public void _SpawnItem(int index, Transform pos){
        Instantiate(ItemPrefabs[index], pos.position,Quaternion.identity);
    }
}
