using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameModeUnlocker : MonoBehaviour
{
    [SerializeField]
    Button[] GameModeButtons;
    private void Awake()
    {
        if (PlayerPrefs.GetInt("GameModeUnlocker") == 0)
        {
            for(int i = 1; i < GameModeButtons.Length; i++)
            {
                GameModeButtons[i].interactable = false;
            }
        }else if (PlayerPrefs.GetInt("GameModeUnlocker") == 1)
        {
            GameModeButtons[2].interactable = false;
        }
        else
        {
            for (int i = 0;i< GameModeButtons.Length; i++)
            {
                GameModeButtons[i].interactable = true;
            }
        }
    }
    
    public void BabyMode()
    {
        PlayerPrefs.SetInt("LevelSelect", 0);
    }
    public void ProMode()
    {
        PlayerPrefs.SetInt("LevelSelect", 1);
    }
    public void TooHard()
    {
        PlayerPrefs.SetInt("LevelSelect", 2);
    }
}
