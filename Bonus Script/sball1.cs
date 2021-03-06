﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sball1 : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] GameObject Smoke;
    bool hasHit;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
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

        if (collision.gameObject.tag == "virus1")
        {
            hasHit = true;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Instantiate(Smoke, collision.gameObject.transform.position, Quaternion.identity);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
