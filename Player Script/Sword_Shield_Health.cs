using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sword_Shield_Health : MonoBehaviour
{
    [SerializeField]
    TrailRenderer SwordTrail;
    [SerializeField]
    SpriteRenderer SwordSprite, ShieldSprite;
    public int MaxHealthAmount;
    public UpgradableStats stats;
    private void Awake()
    {
        SwordSprite.sprite = stats.SwordSprites[PlayerPrefs.GetInt("SwordUpgrade")];
        ShieldSprite.sprite = stats.ShieldSprites[PlayerPrefs.GetInt("ShieldUpgrade")];
        MaxHealthAmount = stats.DifferentHealthAmount[PlayerPrefs.GetInt("HealthUpgrade")];
        TrailChanger();

    }
    void TrailChanger()
    {
        if(SwordSprite.sprite.name=="Layer 7")
        {
            SwordTrail.startColor = new Color(0.7215686f, 0.7529413f, 0.7529413f);
        }else if(SwordSprite.sprite.name=="Layer 11")
        {
            SwordTrail.startColor=new Color(0.8867924f,0.8439292f,0.04601282f);
        }else if(SwordSprite.sprite.name=="Layer 12")
        {
            SwordTrail.startColor = new Color(0.09878961f, 0.5660378f, 0.2487274f);
        }
    }
}
