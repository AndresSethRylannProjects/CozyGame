using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PomodoroTimer : MonoBehaviour
{
    public bool hasFinished = true; // change to false in the future
    [SerializeField] float remainingTime;
    public TextMesh timerText;
    public bool tick = false;


    // Start is called before the first frame update
    void Start()
    {
        // not sure if I want something here yet
    }

    // start timer
    public void startTimer(int time){
        
        if(!hasFinished){
            // ask user if they are sure they want to reset the timer
            // if yes, then reset the timer
            // if no, then do nothing
        }
        else {
            // start timer
            tick = true;
            // make timer text visible
            timerText.gameObject.SetActive(true);

            // set remaining time based on user input
            switch(time){
            case 10:
                remainingTime = 600;
                break;
            case 15:
                remainingTime = 900;
                break;
            case 30:
                remainingTime = 1800;
                break;
            case 45:
                remainingTime = 2700;
                break;
            case 60:
                remainingTime = 3600;
                break;
            default:
                remainingTime = 3600;
                break;
        }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if(tick){
            if (remainingTime > 0){
                remainingTime -= Time.deltaTime;
            }
            else if (remainingTime < 0){
                remainingTime = 0;
            }
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
