using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class button_change : MonoBehaviour
{
    public float transitiontime = 1f;
    public Animator animator;
    [SerializeField]
    GameObject HelpMenu;
    [SerializeField]
    Image HelpMenuImage;
    [SerializeField]
    Sprite[] Helpimages;
    int i = 0;
    private void Start()
    {
        if (HelpMenu != null)
        {
            HelpMenu.SetActive(false);
        }
    }
    public void changeScene(string scene_name)
    {
        StartCoroutine(Transition(scene_name));
        FindObjectOfType<AudioManager>().Play("clickbttn");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    IEnumerator Transition(string NextLevel)
    {
        animator.SetTrigger("fade");
        yield return new WaitForSeconds(transitiontime);
        SceneManager.LoadScene(NextLevel);
    }
    public void Help()
    {
        HelpMenu.SetActive(true);
        FindObjectOfType<AudioManager>().Play("clickbttn");
    }
    public void Back()
    {
        HelpMenu.SetActive(false);
        FindObjectOfType<AudioManager>().Play("backbttn");
    }
    public void GoNext()
    {
        if (i == 4) return;
        i++;
        HelpMenuImage.sprite = Helpimages[i];
        FindObjectOfType<AudioManager>().Play("clickbttn");
    }
    public void GoBack()
    {
        if (i == 0) return;
        i--;
        HelpMenuImage.sprite = Helpimages[i];
        FindObjectOfType<AudioManager>().Play("clickbttn");
    }
}
