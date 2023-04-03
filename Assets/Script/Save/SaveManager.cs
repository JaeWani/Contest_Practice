using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    public JsonData jsonData;
    private void Awake() {
        instance = this;
        if(instance != this)
            Destroy(gameObject);
        else 
            DontDestroyOnLoad(gameObject);
    }
    public void DataSave(string name)
    {
        jsonData.datas.Add(new JsonDataStruct(name, GameManager.Data.score));
        jsonData.datas = jsonData.datas.OrderByDescending(item => item.score).ToList();
        if(jsonData.datas.Count > 5)
        jsonData.datas = jsonData.datas.GetRange(0, 5);
        else
        jsonData.datas = jsonData.datas.GetRange(0,jsonData.datas.Count);
        var content = JsonUtility.ToJson(jsonData);
        PlayerPrefs.SetString("save", content);
        PlayerPrefs.Save();
    }
    public JsonData DataLoad()
    {
        var content = PlayerPrefs.GetString("save");
        var data = JsonUtility.FromJson<JsonData>(content);
        return data;
    }
}
