using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class timer : MonoBehaviour
{
    public static timer instance;
    float currentTime;
    float startingTime = 0f;
    int time;
    public float scoretime;
    public bool gameFinised;
    //float Countdown;
    [SerializeField] Text scoretext;
    [SerializeField] Text texttimer;
    [SerializeField] GameObject ScoreBoard;

    void Start()
    {
        instance = this;
        scoretext.text = PlayerPrefs.GetFloat("highscore").ToString("0.0");      
        currentTime = startingTime;
        texttimer.text = time.ToString();
        ScoreBoard.SetActive(false);
        gameFinised = false;

    }

    
    void Update()
    {
        texttimer.text = currentTime.ToString("0.0");
        if (!gameFinised)
        {
            currentTime += 1 * Time.deltaTime;
        }
        scoretime = currentTime;
    }

    public void save()
    {
        if (scoretime > PlayerPrefs.GetFloat("highscore"))
        {
            PlayerPrefs.SetFloat("highscore", scoretime);
            scoretext.text = PlayerPrefs.GetFloat("highscore").ToString("0.0");
        }
    }
    public void setActive()
    {
            ScoreBoard.SetActive(true);        
    }
}
