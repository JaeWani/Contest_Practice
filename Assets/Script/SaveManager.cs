using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
public class SaveManager : MonoBehaviour
{
    
    public static SaveManager instance;
    void Awake(){
        instance = this;
        if(instance != this)
            Destroy(gameObject);
        else    
            DontDestroyOnLoad(gameObject);
    }

    public string GameDataFileName = "Data.json";
    public SaveDataUnit _saveData;
    public SaveDataUnit saveData{
        get{
            if(_saveData == null){
                DataLoad();
                DataSave();
            }
            return _saveData;
        }
    }
    public void DataLoad(){
        string filePath= Application.persistentDataPath + GameDataFileName;
        if(File.Exists(filePath)){
            Debug.Log("파일을 불러왔습니다.");
            string FromJsonData = File.ReadAllText(filePath);
            _saveData = JsonUtility.FromJson<SaveDataUnit>(FromJsonData);
        }
        else{
            Debug.Log("파일이 없어서 새로운 파일을 생성했습니다.");
            _saveData = new SaveDataUnit();
        }
    }
    public void DataSave(){
        string ToJsonData = JsonUtility.ToJson(saveData);
        string filePath = Application.persistentDataPath + GameDataFileName;
        PlayerPrefs.SetString("Save",ToJsonData);
        Debug.Log("저장 완료입니다.");
    }

}
