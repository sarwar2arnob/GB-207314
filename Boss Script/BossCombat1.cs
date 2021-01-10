using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCombat1 : MonoBehaviour
{
    #region Variable
    [SerializeField]
    GameObject JumpProjectile;
    [SerializeField]
    Transform BeamPositionUp;
    [SerializeField]
    Transform BeamPositionDown;
    [SerializeField]
    GameObject PowerBeam;
    [SerializeField]
    Transform ProjectilePoint;
    [SerializeField]
    int DMGAmount;
    [SerializeField]
    float KnockBackAmount;
    int Randomizer;
    [SerializeField]
    GameObject BossBullet;
    float timer;
    Animator BossAnimator;
    [SerializeField]
    float AttackTimer = 2;
    [SerializeField]
    float MeeleAttackRange;
    [SerializeField]
    float RayCastPos;
    [SerializeField]
    LayerMask PlayerLayer;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        timer = AttackTimer;
        BossAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D PlayerInMeele = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + RayCastPos), -transform.right, MeeleAttackRange, PlayerLayer);
        timer -= Time.deltaTime;
        if (timer <= 0 && Randomizer == 0)
        {
            Randomize();
            timer = AttackTimer;
        }
        if (!PlayerInMeele && !GetComponent<BossHealth>().Dying && Player.instance.currentHealth > 0)
        {
            ShootProjectile();
            SpikeUp();
            SpikeDown();
            Beam();
            Jump_Projectile();
            BossAnimator.SetBool("Meele", false);
        }
        else if(PlayerInMeele)
        {
            BossAnimator.SetBool("Meele", true);
        }else if(Player.instance.currentHealth <= 0)
        {
            BossAnimator.SetBool("Meele", false);
        }

        if (Randomizer != 0)
        {
            Randomizer = 0;
        }
        if (GetComponent<BossHealth>().HalfHealth)
        {
            AttackTimer = 1.5f;
        }

    }
    void Randomize()
    {
        Randomizer = Random.Range(1, 5);
    }
    void ShootProjectile()
    {
        if (!GetComponent<BossHealth>().HalfHealth && (Randomizer==1||Randomizer==4))
        {
            BossAnimator.SetTrigger("Projectile");
           Instantiate(BossBullet, ProjectilePoint.transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().Play("bossm3");
        }
    }
    void SpikeUp()
    {
        if (Randomizer == 2)
        {
            BossSpikeSystem.instance.SpikeUp();
            BossAnimator.SetTrigger("Spike Up");
            FindObjectOfType<AudioManager>().Play("bossm1");
        }
    }
    void SpikeDown()
    {
        if (Randomizer == 3)
        {
            BossSpikeSystem.instance.SpikeDown();
            BossAnimator.SetTrigger("Spike Down");
            FindObjectOfType<AudioManager>().Play("bossm1");
        }
    }
    void Beam()
    {
        if (GetComponent<BossHealth>().HalfHealth && Randomizer==4)
        {
                Instantiate(PowerBeam, BeamPositionUp.transform.position, transform.rotation);
                Instantiate(PowerBeam, BeamPositionDown.transform.position, transform.rotation);
            BossAnimator.SetTrigger("Projectile");
            FindObjectOfType<AudioManager>().Play("bossm4");


        }
    }
    void Jump_Projectile()
    {
        if (GetComponent<BossHealth>().HalfHealth && Randomizer==1)
        {
                Instantiate(JumpProjectile, ProjectilePoint.position, transform.rotation);
            BossAnimator.SetTrigger("Projectile");
            FindObjectOfType<AudioManager>().Play("bossm6");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(DMGAmount);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(-Vector2.right * KnockBackAmount, ForceMode2D.Impulse);

        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawRay(new Vector2(transform.position.x, transform.position.y + RayCastPos), -transform.right * MeeleAttackRange);
    }
}