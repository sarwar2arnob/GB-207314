using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPowerBall : MonoBehaviour
{
    [SerializeField]
    int DMGAmount;
    [SerializeField]
    float Speed = 20f;
    [SerializeField]
    float KnockBackAmount;
    Rigidbody2D rigidbody2D;
    float DmgTimer;
    [SerializeField]
    float timerBeforeDmg = .2f;
    [SerializeField]
    ParticleSystem GettingBig;
    [SerializeField]
    ParticleSystem Sparks;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        DmgTimer = timerBeforeDmg;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GettingBig.isPlaying)
        {
            transform.Rotate(0, 0, 360 * Time.deltaTime);
            rigidbody2D.velocity = -Vector2.right * Speed;
        }
        if (DmgTimer <= 0)
        {
            DmgTimer = timerBeforeDmg;
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(DMGAmount);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(-Vector2.right * KnockBackAmount, ForceMode2D.Impulse);

        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DmgTimer -= Time.deltaTime;
            if (DmgTimer <= 0)
            {
                collision.gameObject.GetComponent<Player>().TakeDamage(DMGAmount);
            }
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(-Vector2.right * KnockBackAmount, ForceMode2D.Impulse);
        }
    }
}
