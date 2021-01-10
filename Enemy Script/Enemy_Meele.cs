using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Meele : MonoBehaviour
{
    float countdown ;
    public float EnemyAttackCdr = 1f;
    Animator EnemyAnimator;
    // Start is called before the first frame update
    void Start()
    {
        EnemyAnimator = GetComponent<Animator>();
        countdown = EnemyAttackCdr;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;      
    }
    public void Punch()
    {
        if (countdown <= 0)
        {
            EnemyAnimator.SetTrigger("Attack");
            countdown = EnemyAttackCdr;
        }
    }
}
