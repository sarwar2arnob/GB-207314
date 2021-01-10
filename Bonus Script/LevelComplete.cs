using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public float transitiontime = 1f;
    Animator animator;
    public string leveltoload;
    [SerializeField]
    GameObject FinalGameObject;
    private void Start()
    {
        if (FinalGameObject == null) { return; }
        FinalGameObject.SetActive(false);      
    }
    private void Awake()
    {
        animator = GameObject.Find("levelchanger").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (FinalGameObject == null) { return; }
        if (collision.gameObject.CompareTag("Player"))
        {
            FinalGameObject.SetActive(true);
        }
    }
    public void LoadLevel()
    {
        if (SceneManager.GetActiveScene().name == "Boss 3 Baby" || SceneManager.GetActiveScene().name == "Boss 3 Normal" || SceneManager.GetActiveScene().name == "Boss 3 Pro")
        {
            StartCoroutine(Transition("Congratulations"));
        }
        else
        {
            StartCoroutine(Transition(leveltoload));
        }
        PlayerPrefs.SetInt("Dna Point Amount", Scoremng.instance.score);
    }
    IEnumerator Transition(string NextLevel)
    {
        animator.SetTrigger("fade");
        yield return new WaitForSeconds(transitiontime);
        SceneManager.LoadScene(NextLevel);
    }
}
