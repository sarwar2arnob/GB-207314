using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
  
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public float transitiontime = 1f;
    public Animator animator;

    public void Resume()
   {
        GameIsPaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        FindObjectOfType<AudioManager>().Play("clickbttn");
    }

   public  void Pause()
   {

       pauseMenuUI.SetActive(true);
       Time.timeScale = 0f;
       GameIsPaused = true;
        FindObjectOfType<AudioManager>().Play("backbttn");

    }

   public void LoadMenu()
    {
        
        Time.timeScale = 1f;

        StartCoroutine(Transition("Mainmenu"));
        FindObjectOfType<AudioManager>().Play("clickbttn");

    }
    public void Quit()
    {
        print("quit");
        Application.Quit();
    }
    public void SetDna()
    {
        PlayerPrefs.SetInt("Dna Point Amount", Scoremng.instance.score);
    }
    IEnumerator Transition(string NextLevel)
    {
        animator.SetTrigger("fade");
        yield return new WaitForSeconds(transitiontime);
        SceneManager.LoadScene(NextLevel);
    }
}
