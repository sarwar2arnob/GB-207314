using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public float VisionRange = 10;
    public float AttackRange = 1.5f;
    public float RayCastPos = 1.5f;
    public LayerMask PlayerLayer;
    public float Speed = 5f;
    Animator EnemyAnimator;
    Rigidbody2D rb2;
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        EnemyAnimator = GetComponent<Animator>();
        rb2 = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D playerSeen = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + RayCastPos), -transform.right, VisionRange, PlayerLayer);
       RaycastHit2D playerAttack = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + RayCastPos), -transform.right, AttackRange, PlayerLayer);
        if (!playerSeen)
        {
            EnemyAnimator.SetBool("Walking", false);
        }
        else if (playerSeen && !playerAttack)
        {
            EnemyAnimator.SetBool("Walking", true);
            rb2.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            Move();
        }
        if (playerSeen && playerAttack)
        {
            EnemyAnimator.SetBool("Walking", false);
            if (GetComponent<Enemy_Range>() != null)
            {
                GetComponent<Enemy_Range>().Shoot();
            }
            else if (GetComponent<Enemy_Meele>() != null)
            {
                GetComponent<Enemy_Meele>().Punch();
                
            }
            else { return; }
        }

        if (Player == null)
        {
            return;
        }
        else
        {
            if (Player.transform.position.x < transform.position.x)
            {
                transform.localRotation = new Quaternion(0, 0, 0, 0);
            }
            else if (Player.transform.position.x > transform.position.x)
            {
                transform.localRotation = new Quaternion(0, 180f, 0, 0);
            }
        }
    }
    private void Move()
    {
        if (Player.transform.position.x < transform.position.x)
        {
            rb2.velocity = new Vector2(-Speed*Time.deltaTime, 0);
        }else if(Player.transform.position.x > transform.position.x)
        {
            rb2.velocity = new Vector2(Speed*Time.deltaTime, 0);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y + RayCastPos), -transform.right * VisionRange, Color.black);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y + RayCastPos), -transform.right * AttackRange, Color.white);
    }
}

