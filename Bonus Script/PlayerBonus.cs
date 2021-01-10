using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerBonus : MonoBehaviour
{
    public int keys = 0;
    [SerializeField]
    float moveSpeed = 5f;

    Rigidbody2D rb;

    Touch touch;
    Vector3 touchPosition, whereToMove;
    bool isMoving = false;

    float previousDistanceToTouchPos, currentDistanceToTouchPos;

    public Text keyAmount;
    public GameObject door;

    [SerializeField] GameObject Particle;
 

    // Start is called before the first frame update
    private void Start()
    {
        keyAmount.text = "" + keys;
        rb = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
            currentDistanceToTouchPos = (touchPosition - transform.position).magnitude;

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Began)
            {
                previousDistanceToTouchPos = 0;
                currentDistanceToTouchPos = 0;
                isMoving = true;
                touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0;
                whereToMove = (touchPosition - transform.position).normalized;
                rb.velocity = new Vector2(whereToMove.x * moveSpeed, whereToMove.y * moveSpeed);
            }
        }

        if (currentDistanceToTouchPos > previousDistanceToTouchPos)
        {
            isMoving = false;
            rb.velocity = Vector2.zero;
        }

        if (isMoving)
            previousDistanceToTouchPos = (touchPosition - transform.position).magnitude;

        if (keys<=0)
        {
            Destroy(door);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Keys")
        {
            keys--;
            keyAmount.text =""+keys;
            FindObjectOfType<AudioManager>().Play("poof");
            Destroy(collision.gameObject);
            Instantiate(Particle, collision.gameObject.transform.position, Quaternion.identity);

        }

     
        if (collision.gameObject.tag == "Enemies")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }




    }

}