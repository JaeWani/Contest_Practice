using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header ("플레이어")]
    [SerializeField]GameObject PlayerObject;
    [SerializeField]Player CurPlayer;

    [Header ("스폰 로직 관련")]
    [SerializeField]float SpawnTime;
                    float CurSpawnTime;
    [SerializeField]public List<GameObject> MonsterList = new List<GameObject>();

    [Header ("UI")]
    [SerializeField]Slider FuelBar;
    [SerializeField]Slider DurabilityBar;
    void Start(){
        PlayerObject = GameObject.Find("Player");
        CurPlayer = PlayerObject.GetComponent<Player>();
    }

    void Update(){
        SpawnLogic();
        UISet();
    }
    void SpawnLogic(){
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
    void UISet(){
        float fuel = CurPlayer.Fuel;
        float durability = CurPlayer.Durability;

        FuelBar.value = fuel/100;
        DurabilityBar.value = durability/100;
    }
}
