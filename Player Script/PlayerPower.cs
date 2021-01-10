using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPower : MonoBehaviour
{
    #region Variable
    [SerializeField]
    float TotalInvincibilityDuration;
    float InvincibilityTimer;
    public bool isInvincible;
    Animator PlayerAnimator;
    [SerializeField]
    float maxAntiBodyPoint;
    public float currentAntiBodyPoint;
    [SerializeField]
    AntiBodyBar antiBodyBar;
    [SerializeField]
    Material PlayerMaterial;
    [SerializeField]
    Text TimerCountDown;
    [SerializeField]
    Image InvincibilityImage;
    [SerializeField]
    ParticleSystem ShockWaveParticle;
    [SerializeField]
    GameObject ShockWaveObject;
    [SerializeField]
    float KnockBackRadius;
    [SerializeField]
    int KnockBackDmg;
    [SerializeField]
    float KnockBackAmount;
    [SerializeField]
    LayerMask KnockBackLayer;
    float timer;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        PlayerAnimator = GetComponent<Animator>();
        InvincibilityTimer = TotalInvincibilityDuration;
        antiBodyBar.SetMaxAntiBodyPoint(maxAntiBodyPoint);
        currentAntiBodyPoint = 100;
        timer = .2f;
        ShockWaveParticle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        antiBodyBar.SetAntiBodyPoint(currentAntiBodyPoint);
        if (isInvincible)
        {
            timer -= Time.deltaTime;
            if (timer <= 0 && PlayerMaterial.GetColor("_color")==new Color(.45f,.45f,.45f,0))
            {
                timer = .2f;
                PlayerMaterial.SetColor("_color", Color.clear);
            }else if(timer <= 0 && PlayerMaterial.GetColor("_color") == Color.clear)
            {
                timer = .2f;
                PlayerMaterial.SetColor("_color", new Color(.45f, .45f, .45f, 0));
            }

            TimerCountDown.enabled = true;
            InvincibilityTimer -= Time.deltaTime;
            TimerCountDown.text = Mathf.Abs((InvincibilityTimer)).ToString("0.00");
            InvincibilityImage.color = new Color(.32f, .32f, .32f, InvincibilityImage.color.a);

        }
        else
        {
            TimerCountDown.enabled = false;
            PlayerMaterial.SetColor("_color", Color.clear);
            InvincibilityImage.color = new Color(1, 1, 1, InvincibilityImage.color.a);
        }
        if (InvincibilityTimer <= 0)
        {
            InvincibilityTimer = TotalInvincibilityDuration;
            isInvincible = false;
        }
        if (currentAntiBodyPoint >= maxAntiBodyPoint)
        {
            currentAntiBodyPoint = maxAntiBodyPoint;
        }
    }
    public void KnockBack()
    {
        if (currentAntiBodyPoint >= 100 && GetComponent<CharacterController2D>().m_Grounded)
        {
            PlayerAnimator.SetTrigger("KnockBack");
            currentAntiBodyPoint = 0;
        }
    }
    public void Invincibility()
    {
        isInvincible = true;        
    }
    public void InvincibleButton()
    {
        if (currentAntiBodyPoint >= 100 && GetComponent<CharacterController2D>().m_Grounded )
        {
            PlayerAnimator.SetTrigger("Invincibility");
            currentAntiBodyPoint = 0;
        }
    }
    public void ShockWaveGather()
    {
        ShockWaveParticle.Play();
    }
    public void ShockWave()
    {
        Instantiate(ShockWaveObject, ShockWaveParticle.transform.position, ShockWaveObject.transform.rotation);
    }
    public void KnockBackRange()
    {
        Collider2D[] Colliders = Physics2D.OverlapCircleAll(ShockWaveParticle.transform.position, KnockBackRadius, KnockBackLayer);
        foreach(Collider2D collider in Colliders)
        {
            if (collider.gameObject.layer == 8)
            {
                collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(KnockBackDmg);
                if (collider.gameObject.GetComponent<Rigidbody2D>())
                {   
                    collider.gameObject.GetComponent<Rigidbody2D>().AddForce(collider.gameObject.transform.right * KnockBackAmount, ForceMode2D.Impulse);
                }

            }else if (collider.gameObject.layer == 11)
            {
                collider.gameObject.GetComponent<BossHealth>().TakeDamage(KnockBackDmg,true);
            }else if (collider.gameObject.layer == 12)
            {
                Destroy(collider.gameObject);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(ShockWaveParticle.transform.position, KnockBackRadius);
    }
}
