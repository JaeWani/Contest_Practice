using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField] Button RankingButton;
    [SerializeField] Image RankingPanel;
    [SerializeField] Button InGameButton;
    void Start(){
        RankingButton.onClick.AddListener(() => Rank());
        InGameButton.onClick.AddListener(() => SceneManager.LoadScene(1));
    }

    [SerializeField] List<Text> RankText;
    void Rank(){
        RankingPanel.gameObject.SetActive(true);
        var data = SaveManager.instance.DataLoad();
        for(int i = 0; i < 5; i++){
            var score = data.datas[0].score;
            RankText[0].text = "순위 : "+(i+1)+"등" + "  점수 : " + score;
        }
    }
    
}
