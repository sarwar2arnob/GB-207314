using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combat_Managment : MonoBehaviour
{
 
    public static Combat_Managment instance;  
    public bool AttackTrigger;
    private void Awake()
    {
        instance = this;
    }

    public void Attack()
    {
        if (GetComponent<CharacterController2D>().m_Grounded)
        {
            AttackTrigger = true;
        }
     
    }

    public void swing1()
    {
        FindObjectOfType<AudioManager>().Play("swing1");
    }

    public void swing2()
    {
        FindObjectOfType<AudioManager>().Play("swing2");
    }
}


