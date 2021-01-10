using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<LevelComplete>().LoadLevel();
            if (SceneManager.GetActiveScene().name == "Boss 3 Baby")
            {
                if (PlayerPrefs.GetInt("GameModeUnlocker") != 2)
                {
                    PlayerPrefs.SetInt("GameModeUnlocker", 1);           
                }
            }
            else if (SceneManager.GetActiveScene().name == "Boss 3 Normal")
            {
                PlayerPrefs.SetInt("GameModeUnlocker", 2);
            }


            else if(SceneManager.GetActiveScene().name == "Boss 1 Baby")
            {
                PlayerPrefs.SetInt("LevelCompleted", 1);
            }
            else if(SceneManager.GetActiveScene().name == "Boss 2 Baby")
            {
                PlayerPrefs.SetInt("LevelCompleted", 2);
            }
            else if (SceneManager.GetActiveScene().name == "Boss 1 Normal")
            {
                PlayerPrefs.SetInt("LevelCompleted", 3);
            }
            else if (SceneManager.GetActiveScene().name == "Boss 2 Normal")
            {
                PlayerPrefs.SetInt("LevelCompleted", 4);
            }
            else if (SceneManager.GetActiveScene().name == "Boss 1 Pro")
            {
                PlayerPrefs.SetInt("LevelCompleted", 5);
            }
            else if (SceneManager.GetActiveScene().name == "Boss 2 Pro")
            {
                PlayerPrefs.SetInt("LevelCompleted", 6);
            }

        }
    }
}
