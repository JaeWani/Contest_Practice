using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class RankingSave : MonoBehaviour
{
    [SerializeField] InputField nameInput;
    [SerializeField] private Button save;
    [SerializeField] private Button exit;
    [SerializeField] private JsonData jsonData;

   private void Start() {
        save.onClick.AddListener(() => {
            jsonData.datas.Add(new JsonDataStruct(nameInput.text, GameManager.Data.score));
            jsonData.datas = jsonData.datas.OrderByDescending(item => item.score).ToList();
            jsonData.datas = jsonData.datas.GetRange(0,5);
            var content = JsonUtility.ToJson(jsonData);
            PlayerPrefs.SetString("save", content);
            PlayerPrefs.Save();
        });
   }
}
