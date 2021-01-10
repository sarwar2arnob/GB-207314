using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Range : MonoBehaviour
{
    public float AttackTimer = 1.5f;
    float currentTime;
    [SerializeField]
    GameObject Laser;
    [SerializeField]
    Transform FirePoint;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = AttackTimer;
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
    }
    public void Shoot()
    {
        if (FirePoint == null)
        {
            return;
        }
        else
        {
            if (currentTime <= 0)
            {
                currentTime = AttackTimer;
                Instantiate(Laser, FirePoint.position, FirePoint.rotation);
                animator.SetTrigger("Shoot");
            }
        }
    }

}
