using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetecter : MonoBehaviour
{
     BoxCollider2D boxCollider2d;
    [SerializeField]
    UpgradableStats stats;
    int DmgAmount;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2d = GetComponent<BoxCollider2D>();
        boxCollider2d.enabled = false;
        DmgAmount = stats.DmgOf3Swords[PlayerPrefs.GetInt("SwordUpgrade")];
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(DmgAmount);
        }
        if (collision.gameObject.layer == 11)
        {
            collision.gameObject.GetComponent<BossHealth>().TakeDamage(DmgAmount, true);
        }
    }
}
