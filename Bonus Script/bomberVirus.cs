using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomberVirus : MonoBehaviour
{
    float speed = 7;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        FindObjectOfType<AudioManager>().Play("virus");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != "Edge") return;
        Destroy(gameObject);
    }
}
