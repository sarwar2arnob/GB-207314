using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    #region Variable
    public static Player instance;
    [SerializeField]
    ParticleSystem Dust;
    [SerializeField]
    ParticleSystem JumpDust;
    [SerializeField]
    CharacterController2D controller;
    [SerializeField]
    Joystick joystick;
    [SerializeField]
    Animator animator;
    [SerializeField]
    GameObject Blood;

    float horizontalMove = 0;
    public float speed = 5f;
    bool jump = false;
    public bool inLadder = false;
    public float LadderSpeed = 5f;
    public int maxHealth = 100;
    public int currentHealth;
    bool walking = false;
    bool Jumped = false;
    public bool takingDmg;
    [SerializeField]
    HealthBar healthBar;
    [SerializeField]
    GameObject GameOver;
    Rigidbody2D rb;
    #endregion
    // Update is called once per frame
    private void Start()
    {
        maxHealth = GetComponent<Sword_Shield_Health>().MaxHealthAmount;
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        healthBar.SetMaxHealth(maxHealth);
        instance = this;
        GameOver.SetActive(false);
        
    }
    public void TakeDamage(int DamageAmount)
    {
        if (!gameObject.GetComponent<PlayerPower>().isInvincible)
        {
            currentHealth -= DamageAmount;
            Instantiate(Blood, transform.position, Blood.transform.rotation);
            if (currentHealth > 0)
            {
                animator.SetTrigger("Hurt");
            }
            else if (currentHealth <= 0)
            {
                Die();
            }
            CameraShaker.Instance.ShakeOnce(3f, .8f, .1f, .3f);
            FindObjectOfType<AudioManager>().Play("hurt");
        }
    }
    void Die()
    {
        animator.SetBool("Falling", false);
        animator.SetTrigger("IsDead");
        GetComponent<CapsuleCollider2D>().enabled = false;
        rb.gravityScale = 0f;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        if(scoresys.instance != null)
        {
            scoresys.instance.save();
        }
        FindObjectOfType<AudioManager>().Play("GameOver");
    }
    void Update()
    {
        healthBar.SetHealth(currentHealth);
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }else if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
        if (joystick.Horizontal >= .5f && !takingDmg)
        {
            horizontalMove = speed;
            animator.SetBool("Run", true);
            walking = true;
        }
        else if (joystick.Horizontal <= -.5f && !takingDmg )
        {
            horizontalMove = -speed;
            animator.SetBool("Run", true);
            walking = true;
        }
        else { horizontalMove = 0; animator.SetBool("Run", false);walking = false; }
        if (joystick.Vertical >= .5f && !takingDmg && !inLadder)
        {
            jump = true;
            animator.SetBool("Jump", true);
            Jumped = true;
        }
        else { jump = false;}
        if (rb.velocity.y < 0 && !inLadder)
        {
            animator.SetBool("LadderDown", false);
            animator.SetBool("Falling", true);
            animator.SetBool("Jump", false);
            Jumped = false;
        }
        else if(rb.velocity.y > .05 && !inLadder)
        {
            animator.SetBool("Falling", false);
            animator.SetBool("Jump", true);
            Jumped = true;
        }
        else if(rb.velocity.y <= 0 && inLadder)
        {
            animator.SetBool("Falling", false);
            animator.SetBool("LadderDown", true);
            Jumped = false;
        }
        if (walking && CharacterController2D.instance.m_Grounded&& !Dust.isPlaying)
        {
            Dust.Play();
        }
        if(Jumped && CharacterController2D.instance.m_Grounded && !JumpDust.isPlaying && !Combat_Managment.instance.AttackTrigger && !Block_Manager.instance.HoldingBlock)
        {
            JumpDust.Play();
        }
        if (CharacterController2D.instance.m_Grounded)
        {
            animator.SetBool("Falling", false);
            animator.SetBool("LadderUp", false);
            animator.SetBool("LadderDown", false);
            animator.SetBool("Jump", false);
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            inLadder = true;
        }
        if (other.CompareTag("Ladder") && joystick.Vertical >= .5f)
        {
            rb.velocity = new Vector2(0, LadderSpeed);
            animator.SetBool("LadderUp", true);
            animator.SetBool("LadderDown", false);
            animator.SetBool("Jump", false);
            animator.SetBool("Falling", false);

        }
        else if (other.CompareTag("Ladder") && joystick.Vertical <= -.5f)
        {
            rb.velocity = new Vector2(0, -LadderSpeed);
            animator.SetBool("LadderUp", false);
            animator.SetBool("LadderDown", true);
            animator.SetBool("Jump", false);
            animator.SetBool("Falling", false);

        }
        else if(other.CompareTag("Ladder") && joystick.Vertical == 0)
        {
            rb.velocity = new Vector2(0, -1);
            animator.SetBool("LadderUp", false);
            animator.SetBool("LadderDown", true);
            animator.SetBool("Jump", false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            inLadder = false;
            animator.SetBool("LadderUp", false);
            animator.SetBool("LadderDown", false);
        }
    }
    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
    }
    public void StopPlaying()
    {
        JumpDust.Stop();
        if (!Combat_Managment.instance.AttackTrigger && !Block_Manager.instance.HoldingBlock)
        {
            FindObjectOfType<AudioManager>().Play("land");
        }
    }
    public void LoadActiveScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GameIsOver()
    {
        GameOver.SetActive(true);
    }
    public void Jump()
    {
        FindObjectOfType<AudioManager>().Play("jump");
    }
    public void Run()
    {
        FindObjectOfType<AudioManager>().Play("run");
    }
}
