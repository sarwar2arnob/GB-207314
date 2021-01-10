using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sball : MonoBehaviour
{
    Rigidbody2D rb;
    bool hasHit;
    [SerializeField] GameObject Particle;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

  
    void Update()
    {
        
        if(hasHit == false)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "virus")
        {
            hasHit = true;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Instantiate(Particle, collision.gameObject.transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("cannon");
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
