using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart : MonoBehaviour
{
    [SerializeField]
    GameObject ConsumeFlash;
    Player player;

    public int healthbonus = 15;
    void Awake()
    {
        player = FindObjectOfType<Player>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            if (player.currentHealth < player.maxHealth)
            {
                player.currentHealth += healthbonus;
            }
            Instantiate(ConsumeFlash, transform.position, transform.rotation);
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("pickup1");
        }
    }
}
