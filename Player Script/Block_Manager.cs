using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Manager : MonoBehaviour
{
    [SerializeField]
    UpgradableStats stats;
    [SerializeField]
    Animator animator;
    [SerializeField]
    GameObject BlockFlashParticle;
    Rigidbody2D rb2;
    public static Block_Manager instance;
    public bool HoldingBlock = false;
    public float CooldownAfterBlockBroken = 2f;
    float CurrentCooldown;
    public float ResetTimerForBlockNumber = 3f;
    public float CurrentResetTimer;
    int CanBlockAttackBeforeBreak;
    public bool BlockBroken = false;
    public int BlockRemaining;
    public bool ShieldHit;
    float timer = .5f;
    private void Start()
    {
        instance = this;
        CurrentResetTimer = 0f;
        CurrentCooldown = CooldownAfterBlockBroken;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        ShieldHit = false;
        rb2 = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        CanBlockAttackBeforeBreak = stats.BlockCountOf3Shields[PlayerPrefs.GetInt("ShieldUpgrade")];
    }
    // Update is called once per frame
    void Update()
    {
        if (CharacterController2D.instance.m_Grounded)
        {
            if (HoldingBlock && CurrentCooldown == CooldownAfterBlockBroken)
            {
                animator.SetBool("Block", true);
                rb2.constraints = RigidbodyConstraints2D.FreezeAll;
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
            else if (!HoldingBlock || CurrentCooldown!=CooldownAfterBlockBroken)
            {
                animator.SetBool("Block", false);
                rb2.constraints = RigidbodyConstraints2D.FreezeRotation;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        if (CurrentResetTimer <= 0)
        {
            CurrentResetTimer = 0;
            BlockRemaining = CanBlockAttackBeforeBreak;
        }
        CurrentResetTimer -= Time.deltaTime;
        if (BlockBroken)
        {
            CurrentCooldown -= Time.deltaTime;
        }
        if (CurrentCooldown <= 0)
        {
            BlockRemaining = CanBlockAttackBeforeBreak;
            BlockBroken = false;
            CurrentCooldown = CooldownAfterBlockBroken;
        }
        if (BlockRemaining == 0)
        {
            BlockBroken = true;
            CurrentResetTimer = ResetTimerForBlockNumber;
        }
        if (ShieldHit)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            ShieldHit = false;
            timer = .5f;
        }

    }
    public void PointerDown()
    {
            HoldingBlock = true;
    }
    public void PointerUp()
    {
        HoldingBlock = false;
    }
    public void BlockFlash()
    {
        animator.SetTrigger("Blocked");
        Instantiate(BlockFlashParticle, transform.position, BlockFlashParticle.transform.rotation);
        FindObjectOfType<AudioManager>().Play("shield");
    }
}   
    

