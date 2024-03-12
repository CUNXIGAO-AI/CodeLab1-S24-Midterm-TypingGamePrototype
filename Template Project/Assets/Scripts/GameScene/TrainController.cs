using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrainController : MonoBehaviour
{
    public Rigidbody trainRB;

    private float trainAcceleration = 0.2f;
    private float trainBrake = 0.2f;

    private string state = "w";

    public TextMeshProUGUI WASD;
    public TextMeshProUGUI WASDRed;

    public GameObject toggleWASD;

    void Start()
    {
        toggleWASD.SetActive(true);
        WASDRed.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case "w":
                if (Input.anyKeyDown)
                {
                    if (Input.GetKeyDown(KeyCode.W))
                    {
                        state = "a";
                        trainRB.velocity += Vector3.forward * trainAcceleration;
                        WASD.text = "W";
                        WASDRed.text = " ";
                    }
                    else
                    {
                        trainRB.velocity -= Vector3.forward * trainBrake;
                        WASDRed.text = "W";
                    }
                }
                break;
            
            case "a":
                if (Input.anyKeyDown)
                {
                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        state = "s";
                        trainRB.velocity += Vector3.forward * trainAcceleration;
                        WASD.text = "WA";
                        WASDRed.text = " ";
                    }
                    else
                    {
                        trainRB.velocity -= Vector3.forward * trainBrake;
                        WASDRed.text = "WA";
                    }
                }
                break;
            
            case "s":
                if (Input.anyKeyDown)
                {
                    if (Input.GetKeyDown(KeyCode.S))
                    {
                        state = "d";
                        trainRB.velocity += Vector3.forward * trainAcceleration;
                        WASD.text = "WAS";
                        WASDRed.text = " ";
                    }
                    else
                    {
                        trainRB.velocity -= Vector3.forward * trainBrake;
                        WASDRed.text = "WAS";
                    }
                }
                break;
            
            case "d":
                if (Input.anyKeyDown)
                {
                    if (Input.GetKeyDown(KeyCode.D))
                    {
                        state = "w";
                        trainRB.velocity += Vector3.forward * trainAcceleration;
                        WASD.text = "WASD";
                        WASDRed.text = " ";
                    }
                    else
                    {
                        trainRB.velocity -= Vector3.forward * trainBrake;
                        WASDRed.text = "WASD";
                    }
                }
                break;
        }
    }
}
