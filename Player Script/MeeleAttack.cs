using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleAttack : MonoBehaviour
{
    Block_Manager PlayerShield;
    [SerializeField]
    int DMGAmount;
    bool isColliding;
    private void Start()
    {
        PlayerShield = GameObject.FindGameObjectWithTag("Shield").GetComponent<Block_Manager>();
    }
    private void Update()
    {
        if (PlayerShield == null)
        {
            return;
        }
        isColliding = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isColliding) return;
        isColliding = true;
        if (collision.gameObject.CompareTag("Player") && !PlayerShield.ShieldHit)
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(DMGAmount);

        }
        if (collision.gameObject.CompareTag("Shield")&& PlayerShield.HoldingBlock&&PlayerShield.BlockRemaining!=0)
        {

            PlayerShield.BlockRemaining -= 1;
            PlayerShield.ShieldHit = true;
            PlayerShield.BlockFlash();
            PlayerShield.CurrentResetTimer = PlayerShield.ResetTimerForBlockNumber;
        }
    }
}
