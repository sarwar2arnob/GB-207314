using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_JumpProjectile : MonoBehaviour
{
    [SerializeField]
    Vector2 DirectionOfBounce;
    Animator Anim;
    Rigidbody2D rb2;
    bool TouchedGround;
    [SerializeField]
    int DmgAmount;
    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TouchedGround)
        {
            Jump();
            TouchedGround = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bottom"))
        {
            TouchedGround = true;
            Anim.SetTrigger("GroundTouch");
        }
        else if (collision.gameObject.CompareTag("Left"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<Player>().TakeDamage(DmgAmount);
        }
    }

    public void Jump()
    {
        rb2.AddForce(DirectionOfBounce, ForceMode2D.Impulse);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
