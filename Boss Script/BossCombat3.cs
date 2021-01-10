using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCombat3 : MonoBehaviour
{
    #region Variable
    [SerializeField]
    GameObject JumpProjectile;
    [SerializeField]
    GameObject PlayerFollowProjec;
    [SerializeField]
    Transform BeamPositionUp;
    [SerializeField]
    Transform BeamPositionDown;
    [SerializeField]
    GameObject PowerBeam;
    [SerializeField]
    Transform ProjectilePoint;
    [SerializeField]
    Transform CameraPoint;
    int Randomizer;
    [SerializeField]
    GameObject Directional;
    [SerializeField]
    GameObject LaserAttack;
    float timer;
    Animator BossAnimator;
    [SerializeField]
    float AttackTimer;
    [SerializeField]
    float MeeleAttackRange;
    [SerializeField]
    float RayCastPos;
    [SerializeField]
    LayerMask PlayerLayer;
    [SerializeField]
    int DMGAmount;
    [SerializeField]
    float KnockBackAmount;
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
            Direction();
            SpikeUp();
            SpikeDown();
            Beam();
            Jump_Projectile();
            PlayerFollowProjectile();
            Laser();
            BossAnimator.SetBool("Meele", false);
        }
        else if(PlayerInMeele)
        {
            BossAnimator.SetBool("Meele", true);
        }
        else if (Player.instance.currentHealth <= 0)
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
    void Direction()
    {
        if (GetComponent<BossHealth>().HalfHealth && Randomizer == 1)
        {
            Instantiate(Directional, CameraPoint.transform.position, transform.rotation);
            BossAnimator.SetTrigger("Projectile");
            FindObjectOfType<AudioManager>().Play("bossm3");

        }
    }
    void Randomize()
    {
        Randomizer = Random.Range(1, 8);
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
        if (!GetComponent<BossHealth>().HalfHealth && (Randomizer == 4 || Randomizer == 1))
        {
            Instantiate(PowerBeam, BeamPositionUp.transform.position, transform.rotation);
            Instantiate(PowerBeam, BeamPositionDown.transform.position, transform.rotation);
            BossAnimator.SetTrigger("Projectile");
            FindObjectOfType<AudioManager>().Play("bossm4");
        }
        else if (GetComponent<BossHealth>().HalfHealth && Randomizer == 4)
        {
            Instantiate(PowerBeam, BeamPositionUp.transform.position, transform.rotation);
            Instantiate(PowerBeam, BeamPositionDown.transform.position, transform.rotation);
            BossAnimator.SetTrigger("Projectile");
            FindObjectOfType<AudioManager>().Play("bossm4");
        }
    }
    void PlayerFollowProjectile()
    {
        if (Randomizer == 5)
        {
            Instantiate(PlayerFollowProjec, ProjectilePoint.transform.position, PlayerFollowProjec.transform.rotation);
            BossAnimator.SetTrigger("Projectile");
            FindObjectOfType<AudioManager>().Play("bossm5");
        }
    }
    void Jump_Projectile()
    {
        if (!GetComponent<BossHealth>().HalfHealth && (Randomizer == 6 || Randomizer == 7))
        {
            Instantiate(JumpProjectile, ProjectilePoint.position, transform.rotation);
            BossAnimator.SetTrigger("Projectile");
            FindObjectOfType<AudioManager>().Play("bossm6");
        }
        else if (GetComponent<BossHealth>().HalfHealth && Randomizer == 6)
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
    void Laser()
    {
        if (GetComponent<BossHealth>().HalfHealth && Randomizer == 7)
        {
            Instantiate(LaserAttack, ProjectilePoint.position, LaserAttack.transform.rotation);
            BossAnimator.SetTrigger("Projectile");
            FindObjectOfType<AudioManager>().Play("bossm2");
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawRay(new Vector2(transform.position.x, transform.position.y + RayCastPos), -transform.right * MeeleAttackRange);
    }
}
