using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScores : MonoBehaviour
{
    public static GameOverScores instance;
    
    string FILE_PATH;

    private float score;

    public float Score
    {
        get
        {
            return score;
        }

        set { score = value; }
    }
    
    string highScoresString = "";

    public string HighScoresString
    {
        get
        {
            return highScoresString;
        }

        set
        {
            highScoresString = value;
        }
    }
    
    
    List<float> highScores;
    
    public List<float> HighScores
    {
        get
        {
            if (highScores == null && File.Exists(FILE_PATH))
            {
                Debug.Log("got from file");
                
                highScores = new List<float>();

                HighScoresString = File.ReadAllText(FILE_PATH);

                HighScoresString = HighScoresString.Trim();
                
                string[] highScoreArray = HighScoresString.Split("\n");

                for (int i = 0; i < highScoreArray.Length; i++)
                {
                    float currentScore = float.Parse(highScoreArray[i]);
                    highScores.Add(currentScore);
                }
            }
            else if(highScores == null)
            {
                Debug.Log("NOPE");
                highScores = new List<float>();
                highScores.Add(3);
                highScores.Add(2);
                highScores.Add(1);
                highScores.Add(0);
            }

            return highScores;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        
        FILE_PATH = Application.dataPath + "/Data/HighScores.txt";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    bool IsHighScore(float timer)
    {

        for (int i = 0; i < HighScores.Count; i++)
        {
            if (timer < highScores[i])
            {
                return true;
            }
        }

        return false;
    }
    
    void SetHighScore()
    {
        if (IsHighScore(score))
        {
            int highScoreSlot = -1;

            for (int i = 0; i < HighScores.Count; i++)
            {
                if (score < highScores[i])
                {
                    highScoreSlot = i;
                    break;
                }
            }
                
            highScores.Insert(highScoreSlot, score);
            
            Debug.Log(score);

            highScores = highScores.GetRange(0, 5);

            string scoreBoardText = "";

            foreach (var highScore in highScores)
            {
                scoreBoardText += highScore + "\n";
            }

            highScoresString = scoreBoardText;
                
            File.WriteAllText(FILE_PATH, highScoresString);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            score = GameManager.Instance.Timer;
            SetHighScore();
            SceneManager.LoadScene("EndScene");
        }
    }
}
