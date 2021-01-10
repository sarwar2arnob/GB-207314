using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Scoremng : MonoBehaviour
{
    [SerializeField]
    Image DNAPointImage;
    public static Scoremng instance;
    [SerializeField]
    TextMeshProUGUI DNAPoint;
    public int score;
    private void Awake()
    {
        SceneManager.sceneLoaded += SceneLoaded;
    }
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        score = PlayerPrefs.GetInt("Dna Point Amount");
        PlayerPrefs.SetInt("Dna Show Amount", score);
    }
    private void Update()
    {
        DNAPoint.text = "X" + PlayerPrefs.GetInt("Dna Show Amount").ToString();
    }
    public void ChangeScore(int coinValue)
    {
        score += coinValue;
        PlayerPrefs.SetInt("Dna Show Amount", score);
    }
    private void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        score = PlayerPrefs.GetInt("Dna Point Amount");
    }
}
