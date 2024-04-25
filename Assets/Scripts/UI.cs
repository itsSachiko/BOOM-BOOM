using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] GameObject losePanel;
    [SerializeField] GameObject winPanel;


    void OnWin()
    {
        Time.timeScale = 0f;
        winPanel.SetActive(true);
    }

    void OnLose()
    {
        Time.timeScale = 0f;
        losePanel.SetActive(true);
    }
    private void OnEnable()
    {
        GameManager.onWin += OnWin;
        PlayerHP.onLose += OnLose;
    }
}
