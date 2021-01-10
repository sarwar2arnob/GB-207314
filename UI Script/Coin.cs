using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    GameObject ConsumeFlash;
    public int coinValue = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Scoremng.instance.ChangeScore(coinValue);
            Instantiate(ConsumeFlash, transform.position, transform.rotation);
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("pickup2");
        }
    }
}
