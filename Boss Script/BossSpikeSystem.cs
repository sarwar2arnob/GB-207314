using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpikeSystem : MonoBehaviour
{
    public static BossSpikeSystem instance;
    Animator SpikeAnimator;
    // Start is called before the first frame update
    void Start()
    {
        SpikeAnimator = GetComponent<Animator>();
        instance = this;
    }
    public void SpikeUp()
    {
        SpikeAnimator.SetTrigger("Spike Up");
    }
    public void SpikeDown()
    {
        SpikeAnimator.SetTrigger("Spike Down");
    }

}
