using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{

    [SerializeField] GameObject Particle;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("danger"))
        {
            transform.parent = null;
            gameObject.AddComponent<Rigidbody2D>();
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

        }

        if (collision.gameObject.CompareTag("cannon"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Instantiate(Particle, collision.gameObject.transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("Explosion");
            timer.instance.save();
            timer.instance.gameFinised = true;
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
