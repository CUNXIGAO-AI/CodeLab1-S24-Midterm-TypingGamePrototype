using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficController : MonoBehaviour
{
    public GameObject redLight;
    public GameObject yellowLight;
    public GameObject greenLight;

    private string trafficState = "red";
    private string state30 = "false";
    private float duration30 = 2.5f;
    private float timer30;

    public GameObject indicator30Out;
    public GameObject indicator30In;
    
    private float trafficTimer;
    public float durationRed = 15f;
    public float durationGreen = 15f;
    public float durationYellow = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        trafficTimer = 0;
        timer30 = 0;
        
        indicator30In.SetActive(false);
        indicator30Out.SetActive(false);
        
        redLight.SetActive(true);
        yellowLight.SetActive(false);
        greenLight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (trafficState)
        {
            case "red":
                trafficTimer += Time.deltaTime;
                if (trafficTimer >= durationRed)
                {
                    trafficState = "yellow1";
                    redLight.SetActive(false);
                    yellowLight.SetActive(true);
                }
                break;
            
            case "yellow1":
                trafficTimer += Time.deltaTime;
                if (trafficTimer >= durationRed + durationYellow)
                {
                    trafficState = "green";
                    yellowLight.SetActive(false);
                    greenLight.SetActive(true);
                }
                break;
            
            case "green":
                trafficTimer += Time.deltaTime;
                if (trafficTimer >= durationRed + durationYellow + durationGreen)
                {
                    trafficState = "yellow2";
                    greenLight.SetActive(false);
                    yellowLight.SetActive(true);
                }
                break;
            
            case "yellow2":
                trafficTimer += Time.deltaTime;
                if (trafficTimer >= durationRed + 2 * durationYellow + durationGreen)
                {
                    trafficState = "red";
                    yellowLight.SetActive(false);
                    redLight.SetActive(true);
                    trafficTimer = 0;
                }
                break;
        }

        switch (state30)
        {
            case "false":
                break;
            
            case "true":
                indicator30In.SetActive(true);
                indicator30Out.SetActive(true);
                
                timer30 += Time.deltaTime;
                
                if (timer30 >= duration30)
                {
                    indicator30In.SetActive(false);
                    indicator30Out.SetActive(false);
                    timer30 = 0;
                    state30 = "false";
                }
                
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && trafficState == "red")
        {
            GameManager.Instance.Timer += 30f;
            state30 = "true";
        }
    }
}
