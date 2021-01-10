using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    [SerializeField]
    UpgradableStats stats;
    int DmgAmount;
    Rigidbody2D rb;
    [SerializeField]
    ParticleSystem Sparks;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Sparks.Stop();
        TrailChanger();
        DmgAmount = stats.DmgOf3Bows[PlayerPrefs.GetInt("ArrowUpgrade")];
    }
    void Update()
    {
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(DmgAmount);
            gameObject.transform.DetachChildren();
            Sparks.Play();
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == 11)
        {
            collision.gameObject.GetComponent<BossHealth>().TakeDamage(DmgAmount, false);
            gameObject.transform.DetachChildren();
            Sparks.Play();
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == 10||collision.gameObject.tag=="Health")
        {
            Destroy(gameObject);
        }
    }
    void TrailChanger()
    {
        if(GetComponent<SpriteRenderer>().sprite.name=="Arrow 1")
        {
            GetComponent<TrailRenderer>().startColor = new Color(0.5882353f, 0.5764706f, 0.5647059f);
        }else if(GetComponent<SpriteRenderer>().sprite.name == "Arrow 2")
        {
            GetComponent<TrailRenderer>().startColor = new Color(0.8773585f, 0.8070847f, 0.1117391f);
        }else if(GetComponent<SpriteRenderer>().sprite.name == "Arrow 3")
        {
            GetComponent<TrailRenderer>().startColor = new Color(0.1529412f, 0.7019608f, 0.4470589f);
        }
    }
}
