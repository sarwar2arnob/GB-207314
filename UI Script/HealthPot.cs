using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPot : MonoBehaviour
{
    [SerializeField]
    GameObject smoke;
    SpriteRenderer sprite;
    [SerializeField]
    Sprite OpenSprite;
    bool destroed;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8 || collision.gameObject.layer == 9 || collision.gameObject.layer == 10 || collision.gameObject.layer == 12||collision.gameObject.name=="GameObject")
        {
            return;
        }
        else
        {
            sprite.sprite = OpenSprite;
            transform.position = new Vector2(transform.position.x, transform.position.y + .5f);
            Invoke("Destroyed", .5f);
        }
    }
    void Destroyed()
    {
        Instantiate(smoke, transform.position, Quaternion.identity);
        GetComponent<EnemyDrop>().Drop();
        Destroy(gameObject);
    }
}
