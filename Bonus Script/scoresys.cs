using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scoresys : MonoBehaviour
{
    public GameObject scorebrd;
    [SerializeField]  Text scoretext;
    public static scoresys instance;
     int score;
    public int currentscore;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scorebrd.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        score = currentscore;

    }

    public void save()
    {
        if (score > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", score);
            scoretext.text = PlayerPrefs.GetInt("Highscore").ToString();
        }
    }
}
