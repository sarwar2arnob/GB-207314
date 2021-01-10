using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon : MonoBehaviour
{
    public GameObject[] cball;
    public float launchForce;
    int count;
    public Transform shotPoint;
    bool changedcolor;
    public GameObject point;
    GameObject[] points;
    public int numberofpoints;
    public float spaceBetweenPoints;
    Vector2 direction;
    [SerializeField] GameObject Particle;
    private void Start()
    {
        points = new GameObject[numberofpoints];
        for(int i = 0; i< numberofpoints; i++)
        {
            points[i] = Instantiate(point, shotPoint.position, Quaternion.identity);
        }
    }


    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 cPosition = transform.position;
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = mousePosition - cPosition;
            transform.right = direction;
        }
        else if (Input.GetMouseButtonUp(0) && !changedcolor)
        {
            Shoot();
            Instantiate(Particle, shotPoint.transform.position, transform.rotation);
        }

        for (int i = 0; i < numberofpoints; i++)
        {
            points[i].transform.position = PointPosition(i * spaceBetweenPoints);
        }
        changedcolor =false;
    }

    public void Shoot()
    {
       GameObject newball = Instantiate(cball[count], shotPoint.position, shotPoint.rotation);
        newball.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
        FindObjectOfType<AudioManager>().Play("cannon");
        
    }

    Vector2 PointPosition(float t)
    {
        Vector2 position = (Vector2)shotPoint.position + (direction.normalized * launchForce * t) + (0.5f*Physics2D.gravity*(t * t));
        return position;
    }

    public void ballchange()
    {
        count = 0;
        changedcolor = true;
    }
    public void ballchange1()
    {
        count = 1;
        changedcolor = true;

    }
    public void ballchange2()
    {
        count = 2;
        changedcolor = true;

    }


}
