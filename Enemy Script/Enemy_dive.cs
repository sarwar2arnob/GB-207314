using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_dive : MonoBehaviour
{
    [SerializeField]
    private Transform[] Waypoints;
    [SerializeField]
    private float Speed = 2f;
    public float AttackRange = 5f;
    private int WaypointIndex = 0;
    [SerializeField]
    LayerMask PlayerLayer;
    Animator animator;
    private GameObject Player;
    private bool SawPlayer;
    private bool ReachedEndOfPath;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] Enemy = Physics2D.OverlapCircleAll(transform.position, AttackRange, PlayerLayer);
        if (Enemy.Length == 0 && (WaypointIndex == 0 || WaypointIndex == Waypoints.Length - 1))
        {
            SawPlayer = false;
        }
        else if (Enemy.Length != 0|| (WaypointIndex >= 1 && WaypointIndex <= Waypoints.Length - 2))
        {
            SawPlayer = true;
        }
        if (Player == null)
        {
            return;
        }
        else
        {
            if (Player.transform.position.x > transform.position.x)
            {
                transform.localScale = Vector2.one * transform.localScale.y;
            }
            else if (Player.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector2(-1f, 1f) * transform.localScale.y;
            }
        }
        if (SawPlayer)
        {
            Move();
        }
        if(WaypointIndex == Waypoints.Length - 1)
        {
            ReachedEndOfPath = true;
        }else if (WaypointIndex == 0)
        {
            ReachedEndOfPath = false;
        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, AttackRange);
    }
    private void Move()
    {
        animator.SetTrigger("Dive");
        if (!ReachedEndOfPath)
        {
            transform.position = Vector2.MoveTowards(transform.position, Waypoints[WaypointIndex].transform.position, Speed * Time.deltaTime);
            if (transform.position == Waypoints[WaypointIndex].transform.position)
            {
                WaypointIndex += 1;
            }
        }
        if (ReachedEndOfPath)
        {
            transform.position = Vector2.MoveTowards(transform.position, Waypoints[WaypointIndex].transform.position, Speed * Time.deltaTime);
            if (transform.position == Waypoints[WaypointIndex].transform.position)
            {
                WaypointIndex -= 1;
            }
        }

    }

}
