﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMeele : MonoBehaviour
{
    [SerializeField]
    int DmgAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(DmgAmount);
        }
    }
}
