using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject viewIn;
    public GameObject viewOut;
    public GameObject viewTransit;
    private string currentView;
    
    public Rigidbody rbTrain;
    public TextMeshProUGUI SpdIn;
    public TextMeshProUGUI SpdOut;
    
    private float timer = 0f;
    public TextMeshProUGUI timerIn;
    public TextMeshProUGUI timerOut;
    
    public float Timer
    {
        get
        {
            return timer;
        }
        set
        {
            timer = value;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        
        viewIn.SetActive(false);
        viewOut.SetActive(true);
        viewTransit.SetActive(false);
        currentView = "outside";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            viewTransit.SetActive(true);
            viewIn.SetActive(false);
            viewOut.SetActive(false);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            switch (currentView)
            {
                case "outside":
                    viewIn.SetActive(true);
                    viewOut.SetActive(false);
                    viewTransit.SetActive(false);
                    currentView = "inside";
                    break;
                case "inside":
                    viewOut.SetActive(true);
                    viewIn.SetActive(false);
                    viewTransit.SetActive(false);
                    currentView = "outside";
                    break;
            }
        }

        if (rbTrain.velocity.z >= 0)
        {
            SpdIn.text = rbTrain.velocity.magnitude.ToString("F1") + "MPH";
            SpdOut.text = rbTrain.velocity.magnitude.ToString("F1") + "MPH";
        }
        
        if (rbTrain.velocity.z < 0)
        {
            SpdIn.text = "-" + rbTrain.velocity.magnitude.ToString("F1") + "MPH";
            SpdOut.text = "-" + rbTrain.velocity.magnitude.ToString("F1") + "MPH";
        }

        timer += Time.deltaTime;
        timerIn.text = timer.ToString("F1");
        timerOut.text = timer.ToString("F1");

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("StartScene");
        }
    }
}
