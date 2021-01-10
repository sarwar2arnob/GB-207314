using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EZCameraShake;

public class BossHealth : MonoBehaviour
{
    public static BossHealth Instance;
    public int MaxHealth = 90;
    int CurrentHealth;
    public bool HalfHealth;
    public bool IsInVulnerable = false;
    PlayerPower playerPower;
    [SerializeField]
    ParticleSystem DmgParticle;
    [SerializeField]
    ParticleSystem DeathParticle;
    [SerializeField]
    GameObject Smoke;
    [SerializeField]
    Transform SmokePos;
    [SerializeField]
    GameObject HappyEarth;
    public bool Dying = false;
    float GainAntiBody = 7;
    Animator BossAnimator;
    public bool HalfHealthAnimationDone = false;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
        DmgParticle.Stop();
        DeathParticle.Stop();
        BossAnimator = GetComponent<Animator>();
        playerPower = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPower>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth <= MaxHealth / 2)
        {
            HalfHealth = true;
            if (!HalfHealthAnimationDone)
            {
                BossAnimator.SetTrigger("Half Health");
            }
        }
        else { HalfHealth = false; }
    }
    public void TakeDamage(int DamageAmount,bool HitByMeele)
    {
        if (gameObject.name == "Boss-1")
        {
                FindObjectOfType<AudioManager>().Play("bossh1");
        }
        else if (gameObject.name == "Boss-2")
        {
            FindObjectOfType<AudioManager>().Play("bossh2");
        }
       else if (gameObject.name == "Boss-3")
        {
            FindObjectOfType<AudioManager>().Play("bossh3");
        }
        if (HitByMeele)
        {
            DmgParticle.Play();
        }
        if (IsInVulnerable) { return; }
        CurrentHealth -= DamageAmount;
        playerPower.currentAntiBodyPoint += GainAntiBody;
        if (CurrentHealth <= 0)
        {
            Die();
        }
        CameraShaker.Instance.ShakeOnce(2.2f, .5f, .1f, .3f);
    }

    

    public void bossd1()
    {
        FindObjectOfType<AudioManager>().Play("bossd1");
    }

    public void bossd2()
    {
        FindObjectOfType<AudioManager>().Play("bossd2");
    }

    public void bossd3()
    {
        FindObjectOfType<AudioManager>().Play("bossd3");
    }


    void Die()
    {
        if (GetComponent<CapsuleCollider2D>() != null)
        {
            GetComponent<CapsuleCollider2D>().enabled = false;
        }
        else if (GetComponent<CircleCollider2D>() != null)
        {
            GetComponent<CircleCollider2D>().enabled = false;
        }
        else if (GetComponent<BoxCollider2D>() != null)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
        DeathParticle.Play();
        Dying = true;
        BossAnimator.SetTrigger("Death");
    }
    void Destroy()
    {
        Destroy(gameObject);
        Instantiate(Smoke, SmokePos.position, gameObject.transform.rotation);
        Instantiate(HappyEarth, SmokePos.position, SmokePos.rotation);
    }
    public void CameraShake()
    {
        CameraShaker.Instance.ShakeOnce(4f, 1f, .1f, .3f);
    }

    public void HeavtImpact()
    {
        FindObjectOfType<AudioManager>().Play("Heavy Impact");
    }
}
