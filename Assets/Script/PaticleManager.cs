using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaticleManager : MonoBehaviour
{
    public static PaticleManager instance;
    [SerializeField] List<GameObject> PaticlePrefabs = new List<GameObject>();
    private void Awake() {
        instance = this;
        if(instance != this)
            Destroy(gameObject);
    }
    public static void SpawnPaticle(int index, Transform pos){
        instance._SpawnPaticle(index,pos);
    }
    public void _SpawnPaticle(int index, Transform pos){
        Instantiate(PaticlePrefabs[index],pos.position,Quaternion.identity);
    }
}
