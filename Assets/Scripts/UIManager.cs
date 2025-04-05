using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject settingPanel;
    public GameObject endGamePanel;
    public GameObject MenuPanel;

    public TextMeshProUGUI highScore;
    public TextMeshProUGUI highScoreOver;
    private void Awake()
    {
        if(instance != null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        highScore.text = GameManager.Instance.distanceTravel.ToString("F0");
        highScoreOver.text = highScore.text;
    }

    public void ShowPanel(GameObject obj)
    {
        obj.SetActive(!obj.activeSelf);
    }


}
