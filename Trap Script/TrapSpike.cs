using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpike : MonoBehaviour
{
    float DmgTimer;
    [SerializeField]
    float timerBeforeDmg;
    [SerializeField]
    int DMGAmount;
    // Start is called before the first frame update
    void Start()
    {
        DmgTimer = timerBeforeDmg;
    }

    // Update is called once per frame
    void Update()
    {
        DmgTimer -= Time.deltaTime;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (DmgTimer <= 0)
            {
                DmgTimer = timerBeforeDmg;
                collision.gameObject.GetComponent<Player>().TakeDamage(DMGAmount);
            }
        }
    }
}
