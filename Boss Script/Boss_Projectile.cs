using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Projectile : MonoBehaviour
{
    [SerializeField]
    int DMGAmount;
    [SerializeField]
    float Speed = 20f;
    [SerializeField]
    ParticleSystem GettingBig;
    new Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GettingBig.isPlaying)
        {
            rigidbody2D.velocity = -transform.right * Speed;
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Shield"))
        {
            collision.gameObject.GetComponent<Block_Manager>().BlockRemaining -= 1;
            collision.gameObject.GetComponent<Block_Manager>().CurrentResetTimer = collision.gameObject.GetComponent<Block_Manager>().ResetTimerForBlockNumber;
            Destroy(gameObject);
            collision.gameObject.GetComponent<Block_Manager>().BlockFlash();
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(DMGAmount);
            Destroy(gameObject);
        }
    }
}
