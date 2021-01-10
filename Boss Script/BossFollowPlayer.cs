using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class BossFollowPlayer : MonoBehaviour
{
    [SerializeField]
    int DmgAmount;
    Transform Target;
    Rigidbody2D rb2;
    [SerializeField]
    float Speed;
    [SerializeField]
    float rotateSpeed;
    [SerializeField]
    ParticleSystem GettingBig;
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        rb2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!GettingBig.isPlaying)
        {
            Vector2 Direction = (Vector2)Target.position - rb2.position;
            Direction.Normalize();
            float rotateAmount = Vector3.Cross(Direction, -transform.right).z;
            rb2.angularVelocity = -rotateAmount * rotateSpeed;
            rb2.velocity = -transform.right * Speed;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(DmgAmount);
            Destroy(gameObject);
        }
    }
}
