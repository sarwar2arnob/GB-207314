using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDestroy : MonoBehaviour
{
  void Destroy()
    {
        if (timer.instance != null && gameObject.name == "explosion(Clone)")
        {
            timer.instance.setActive();
        }
        Destroy(gameObject);
    }
}
