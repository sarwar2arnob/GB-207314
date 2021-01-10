using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss4Directional : MonoBehaviour
{
    Transform Target;
    [SerializeField]
    ParticleSystem GettingBig;
    [SerializeField]
    GameObject Direction1;
    [SerializeField]
    GameObject Direction2;
    [SerializeField]
    GameObject Direction3;
    [SerializeField]
    GameObject Direction4;
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Vector3 direction = Target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GettingBig.isPlaying)
        {
            if (Direction1 != null && Direction2 != null && Direction3 != null && Direction4 != null)
            {
                Direction1.GetComponent<Direction1>().Shoot();
                Direction2.GetComponent<Direction2>().Shoot();
                Direction3.GetComponent<Direction3>().Shoot();
                Direction4.GetComponent<Direction4>().Shoot();
            }
            else if(Direction1 == null || Direction2 == null || Direction3 == null || Direction4 == null)
            {
                Destroy(gameObject);
            }
        }
    }
}
