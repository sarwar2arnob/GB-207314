using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction1 : MonoBehaviour
{
    Rigidbody2D rb2;
    [SerializeField]
    int DmgAmount;
    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
   public void Shoot()
    {
        rb2.AddForce(-transform.up * 40 * Time.deltaTime, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(DmgAmount);
            Destroy(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
