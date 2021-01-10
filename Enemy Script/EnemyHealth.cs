using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class EnemyHealth : MonoBehaviour
{
    Animator Animator;
    public int MaxHealth = 90;
    int CurrentHealth;
    [SerializeField]
    GameObject Smoke;
    [SerializeField]
    float SmokePos;
    PlayerPower playerPower;
    float GainAntiBody = 5;
    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
        Animator = GetComponent<Animator>();
        playerPower = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPower>();
        
    }
    public void TakeDamage(int DamageAmount)
    {
        CurrentHealth -= DamageAmount;
        Animator.SetTrigger("Hurt");
        if (CurrentHealth <= 0)
        {
            Die();
            FindObjectOfType<AudioManager>().Play("ed");
       
        }
        playerPower.currentAntiBodyPoint += GainAntiBody;
        CameraShaker.Instance.ShakeOnce(3f, .8f, .1f, .3f);
        FindObjectOfType<AudioManager>().Play("eh");
    }
    void Die()
    {
        if (GetComponent<CapsuleCollider2D>() != null)
        {
            GetComponent<CapsuleCollider2D>().enabled = false;
        }
        else if(GetComponent<CircleCollider2D>()!=null)
        {
            GetComponent<CircleCollider2D>().enabled = false;
        }else if (GetComponent<BoxCollider2D>()!= null)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
        GetComponent<EnemyDrop>().Drop();
        Instantiate(Smoke, new Vector2(transform.position.x, transform.position.y+SmokePos), gameObject.transform.rotation);
        FindObjectOfType<AudioManager>().Play("poof");
        Destroy(gameObject);
        if (scoresys.instance != null)
        {
            scoresys.instance.currentscore += 1;
        }
        
    }

}
