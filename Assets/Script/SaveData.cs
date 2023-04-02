using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SaveDataUnit
{
   public string Name;
   public int Score;
}
[CreateAssetMenu]
public class SaveData : ScriptableObject
{
    public List<SaveDataUnit> Datas = new List<SaveDataUnit>();
}
