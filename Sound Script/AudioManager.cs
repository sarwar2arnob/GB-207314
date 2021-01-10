using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

	public static AudioManager instance;

	public AudioMixerGroup mixerGroup;

	public Sound[] sounds;

	void Awake()
	{
		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;

            s.source.outputAudioMixerGroup = mixerGroup;
		}
	}
    public void Stop(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Stop();
    }

	public void Play(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));
        s.source.Play();
	}
    private void Start()
    {
        if(SceneManager.GetActiveScene().name=="Boss 1 Baby"|| SceneManager.GetActiveScene().name == "Boss 1 Normal" || SceneManager.GetActiveScene().name == "Boss 1 Pro" || SceneManager.GetActiveScene().name == "Boss 2 Baby" || SceneManager.GetActiveScene().name == "Boss 2 Normal" || SceneManager.GetActiveScene().name == "Boss 2 Pro" || SceneManager.GetActiveScene().name == "Boss 3 Baby" || SceneManager.GetActiveScene().name == "Boss 3 Normal" || SceneManager.GetActiveScene().name == "Boss 3 Pro"|| SceneManager.GetActiveScene().name == "bomber"||SceneManager.GetActiveScene().name == "infinite")
        {
            Play("BossBG");
        }else if(SceneManager.GetActiveScene().name == "Level 1 Baby"|| SceneManager.GetActiveScene().name == "Level 1 Normal"|| SceneManager.GetActiveScene().name == "Level 1 Pro"||SceneManager.GetActiveScene().name == "Level 2 Baby" || SceneManager.GetActiveScene().name == "Level 2 Normal" || SceneManager.GetActiveScene().name == "Level 2 Pro"||SceneManager.GetActiveScene().name == "Level 3 Baby" || SceneManager.GetActiveScene().name == "Level 3 Normal" || SceneManager.GetActiveScene().name == "Level 3 Pro" || SceneManager.GetActiveScene().name == "maze1" || SceneManager.GetActiveScene().name == "maze2" || SceneManager.GetActiveScene().name == "maze3")
        {
            Play("LevelBG");
        }else if(SceneManager.GetActiveScene().name=="Mainmenu"|| SceneManager.GetActiveScene().name == "upgrade" || SceneManager.GetActiveScene().name == "GameMode" || SceneManager.GetActiveScene().name == "Bonus" || SceneManager.GetActiveScene().name == "levelSelect")
        {
            Play("MainMenuBG");
        }else if (SceneManager.GetActiveScene().name == "Congratulations")
        {
            Play("Congratulations");
        }
        if(SceneManager.GetActiveScene().name == "Boss 1 Baby" || SceneManager.GetActiveScene().name == "Boss 1 Normal" || SceneManager.GetActiveScene().name == "Boss 1 Pro" || SceneManager.GetActiveScene().name == "Boss 2 Baby" || SceneManager.GetActiveScene().name == "Boss 2 Normal" || SceneManager.GetActiveScene().name == "Boss 2 Pro" || SceneManager.GetActiveScene().name == "Boss 3 Baby" || SceneManager.GetActiveScene().name == "Boss 3 Normal" || SceneManager.GetActiveScene().name == "Boss 3 Pro")
        {
            Play("EvilLaugh");
        }
    }
    private void Update()
    {
        if (Player.instance!=null)
        {
            if (Player.instance.currentHealth <= 0)
            {
                if (SceneManager.GetActiveScene().name == "Boss 1 Baby" || SceneManager.GetActiveScene().name == "Boss 1 Normal" || SceneManager.GetActiveScene().name == "Boss 1 Pro" || SceneManager.GetActiveScene().name == "Boss 2 Baby" || SceneManager.GetActiveScene().name == "Boss 2 Normal" || SceneManager.GetActiveScene().name == "Boss 2 Pro" || SceneManager.GetActiveScene().name == "Boss 3 Baby" || SceneManager.GetActiveScene().name == "Boss 3 Normal" || SceneManager.GetActiveScene().name == "Boss 3 Pro" || SceneManager.GetActiveScene().name == "bomber" || SceneManager.GetActiveScene().name == "infinite")
                {
                    Stop("BossBG");
                }
                else if (SceneManager.GetActiveScene().name == "Level 1 Baby" || SceneManager.GetActiveScene().name == "Level 1 Normal" || SceneManager.GetActiveScene().name == "Level 1 Pro" || SceneManager.GetActiveScene().name == "Level 2 Baby" || SceneManager.GetActiveScene().name == "Level 2 Normal" || SceneManager.GetActiveScene().name == "Level 2 Pro" || SceneManager.GetActiveScene().name == "Level 3 Baby" || SceneManager.GetActiveScene().name == "Level 3 Normal" || SceneManager.GetActiveScene().name == "Level 3 Pro" || SceneManager.GetActiveScene().name == "maze1" || SceneManager.GetActiveScene().name == "maze2" || SceneManager.GetActiveScene().name == "maze3")
                {
                    Stop("LevelBG");
                }
            }
        }
    }
    //private void OnApplicationQuit()
    //{
    //    PlayerPrefs.DeleteAll();
    //}
}
