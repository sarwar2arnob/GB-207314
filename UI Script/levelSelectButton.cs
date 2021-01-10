using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelSelectButton : MonoBehaviour
{
    public float transitiontime = 1f;
    public Animator animator;
    [SerializeField]
    Button[] LevelSelectButton;
    private void Awake()
    {
        if (PlayerPrefs.GetInt("LevelSelect") == 0 && PlayerPrefs.GetInt("LevelCompleted") < 1)
        {
            LevelSelectButton[1].image.color = Color.black;
            LevelSelectButton[2].image.color = Color.black;
            LevelSelectButton[1].interactable = false;
            LevelSelectButton[2].interactable = false;
        }
        else if (PlayerPrefs.GetInt("LevelSelect") == 0 && PlayerPrefs.GetInt("LevelCompleted") < 2)
        {
            LevelSelectButton[2].image.color = Color.black;
            LevelSelectButton[2].interactable = false;
        }
        else if (PlayerPrefs.GetInt("LevelSelect") == 1 && PlayerPrefs.GetInt("LevelCompleted") < 3)
        {
            LevelSelectButton[1].image.color = Color.black;
            LevelSelectButton[2].image.color = Color.black;
            LevelSelectButton[1].interactable = false;
            LevelSelectButton[2].interactable = false;
        }else if(PlayerPrefs.GetInt("LevelSelect") == 1 && PlayerPrefs.GetInt("LevelCompleted") < 4)
        {
            LevelSelectButton[2].image.color = Color.black;
            LevelSelectButton[2].interactable = false;
        }else if(PlayerPrefs.GetInt("LevelSelect") == 2 && PlayerPrefs.GetInt("LevelCompleted") < 5)
        {
            LevelSelectButton[1].image.color = Color.black;
            LevelSelectButton[2].image.color = Color.black;
            LevelSelectButton[1].interactable = false;
            LevelSelectButton[2].interactable = false;
        }else if(PlayerPrefs.GetInt("LevelSelect") == 2 && PlayerPrefs.GetInt("LevelCompleted") < 6)
        {
            LevelSelectButton[2].image.color = Color.black;
            LevelSelectButton[2].interactable = false;
        }
    }

    public void Level1Button()
    {
        if (PlayerPrefs.GetInt("LevelSelect") == 0)
        {
            StartCoroutine(Transition("Level 1 Baby"));
        }else if(PlayerPrefs.GetInt("LevelSelect") == 1)
        {
            StartCoroutine(Transition("Level 1 Normal"));
        }else if(PlayerPrefs.GetInt("LevelSelect") == 2)
        {
            StartCoroutine(Transition("Level 1 Pro"));
        }
        FindObjectOfType<AudioManager>().Play("clickbttn");
    }
    public void Level2Button()
    {
        if (PlayerPrefs.GetInt("LevelSelect") == 0)
        {
            StartCoroutine(Transition("Level 2 Baby"));
        }
        else if (PlayerPrefs.GetInt("LevelSelect") == 1)
        {
            StartCoroutine(Transition("Level 2 Normal"));
        }
        else if (PlayerPrefs.GetInt("LevelSelect") == 2)
        {
            StartCoroutine(Transition("Level 2 Pro"));
        }
        FindObjectOfType<AudioManager>().Play("clickbttn");
    }
    public void Level3Button()
    {
        if (PlayerPrefs.GetInt("LevelSelect") == 0)
        {
            StartCoroutine(Transition("Level 3 Baby"));
        }
        else if (PlayerPrefs.GetInt("LevelSelect") == 1)
        {
            StartCoroutine(Transition("Level 3 Normal"));
        }
        else if (PlayerPrefs.GetInt("LevelSelect") == 2)
        {
            StartCoroutine(Transition("Level 3 Pro"));
        }
        FindObjectOfType<AudioManager>().Play("clickbttn");
    }

    IEnumerator Transition(string NextLevel)
    {
        animator.SetTrigger("fade");
        yield return new WaitForSeconds(transitiontime);
        SceneManager.LoadScene(NextLevel);
    }

}
