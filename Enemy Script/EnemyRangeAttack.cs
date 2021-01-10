using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeAttack : MonoBehaviour
{
    [SerializeField]
    int DMGAmount;
    [SerializeField]
    float LaserSpeed = 20f;
    Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = -transform.right * LaserSpeed;
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
            Destroy(gameObject);
         }
        if (collision.gameObject.CompareTag("Shield"))
        {
            collision.gameObject.GetComponent<Block_Manager>().BlockRemaining -= 1;
            collision.gameObject.GetComponent<Block_Manager>().CurrentResetTimer = collision.gameObject.GetComponent<Block_Manager>().ResetTimerForBlockNumber;
             Destroy(gameObject);
            collision.gameObject.GetComponent<Block_Manager>().BlockFlash();
        }
    }
}
