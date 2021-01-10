using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaser : MonoBehaviour
{
    [SerializeField]
    float MoveSpeed;
    [SerializeField]
    Vector2 MoveDirection;
    [SerializeField]
    int DmgAmount;
    Rigidbody2D rb2;
    private void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        MoveDirection.Normalize();
    }
    private void Update()
    {
        MoveLaser();
    }
    void MoveLaser()
    {
        rb2.velocity = MoveSpeed * MoveDirection;
    }
    void ChangeDirection()
    {
        MoveDirection.y *= -1;
    }
    void Flip()
    {
        MoveDirection.x *= -1;        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Top")|| collision.gameObject.CompareTag("Left") || collision.gameObject.CompareTag("Bottom") || collision.gameObject.CompareTag("Right"))
        {
            transform.Rotate(0, 180, 0);
        }
        if (collision.gameObject.CompareTag("Top") || collision.gameObject.CompareTag("Bottom"))
        {
            ChangeDirection();
        }else if (collision.gameObject.CompareTag("Left") || collision.gameObject.CompareTag("Right"))
        {
            Flip();
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(DmgAmount);
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
