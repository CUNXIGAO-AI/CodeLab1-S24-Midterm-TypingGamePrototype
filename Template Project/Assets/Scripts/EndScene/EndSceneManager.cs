using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneManager : MonoBehaviour
{

    public TextMeshProUGUI currentScore;
    public TextMeshProUGUI highScoreList;
    // Start is called before the first frame update
    void Start()
    {
        currentScore.text = "Your Score is: " + GameOverScores.instance.Score.ToString("F1") + "s";
        highScoreList.text = GameOverScores.instance.HighScoresString;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("StartScene");
        }
    }
}
