using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConsume : MonoBehaviour
{
    Transform Target;
    Animator Anim;
    [SerializeField]
    float RangeOfConsume;
    [SerializeField]
    LayerMask PlayerMask;
    [SerializeField]
    float Speed;
    bool FoundPlayer;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        Target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float step = Speed * Time.deltaTime;
        Collider2D collider = Physics2D.OverlapCircle(transform.position, RangeOfConsume, PlayerMask);
        if (collider)
        {
            FoundPlayer = true;
        }
        if (FoundPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, step);
            Anim.SetTrigger("Consume");
        }
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, RangeOfConsume);
    }
}
