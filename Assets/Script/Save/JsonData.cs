using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Save/Json", fileName = "savedata")]
public class JsonData : ScriptableObject
{
    public List<JsonDataStruct> datas = new List<JsonDataStruct>();
}

[System.Serializable]
public struct JsonDataStruct
{
    public JsonDataStruct(string name, int score){
        this.name = name;
        this.score = score;
    }
    public string name;
    public int score;
}