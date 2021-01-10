using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class UpgradeSystem : MonoBehaviour
{
    [SerializeField]
    Image SwordImage, ShieldImage, BowImage;
    [SerializeField]
    Sprite Sword2, Sword3, Shield2, Shield3, Bow2, Bow3;
    [SerializeField]
    RectTransform HealthFill;
    [SerializeField]
    int[] UpgradeAmount;
    [SerializeField]
    Text[] UpgradeText;
    [SerializeField]
    Button[] UpgradeButtons;
    
    // Start is called before the first frame update
    void Awake()
    {
        if (PlayerPrefs.GetInt("SwordUpgrade") == 1)
        {
            SwordImage.sprite = Sword2;
        }
        else if (PlayerPrefs.GetInt("SwordUpgrade") == 2)
        {
            SwordImage.sprite = Sword3;
        }

        if (PlayerPrefs.GetInt("ShieldUpgrade") == 1)
        {
            ShieldImage.sprite = Shield2;
        }
        else if (PlayerPrefs.GetInt("ShieldUpgrade") == 2)
        {
            ShieldImage.sprite = Shield3;
        }

        if (PlayerPrefs.GetInt("ArrowUpgrade") == 1)
        {
            BowImage.sprite = Bow2;
        }
        else if (PlayerPrefs.GetInt("ArrowUpgrade") == 2)
        {
            BowImage.sprite = Bow3;
        }

        if (PlayerPrefs.GetInt("HealthUpgrade") == 1)
        {
            HealthFill.sizeDelta = new Vector2(617.7889f, 84);
            HealthFill.localPosition = new Vector2(58, 0);
        }
        else if (PlayerPrefs.GetInt("HealthUpgrade") == 2)
        {
            HealthFill.sizeDelta = new Vector2(732.562f, 84);
            HealthFill.localPosition = new Vector2(115.3f, 0);
        }
        else
        {
            HealthFill.sizeDelta = new Vector2(501.9286f, 84);
            HealthFill.localPosition = new Vector2(0, 0);
        }
    }
    private void Start()
    {
        for(int i= 0 ; i< 8 ; i++)
        {
            UpgradeText[i].text = UpgradeAmount[i].ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("SwordUpgrade") == 1)
        {
            UpgradeButtons[0].interactable = false;
        }
        else if(PlayerPrefs.GetInt("SwordUpgrade") == 2)
        {
            UpgradeButtons[0].interactable = false;
            UpgradeButtons[1].interactable = false;
        }

        if(PlayerPrefs.GetInt("ShieldUpgrade") == 1)
        {
            UpgradeButtons[2].interactable = false;
        }else if(PlayerPrefs.GetInt("ShieldUpgrade") == 2)
        {
            UpgradeButtons[2].interactable = false;
            UpgradeButtons[3].interactable = false;
        }

        if(PlayerPrefs.GetInt("ArrowUpgrade") == 1)
        {
            UpgradeButtons[4].interactable = false;
        }else if(PlayerPrefs.GetInt("ArrowUpgrade") == 2)
        {
            UpgradeButtons[4].interactable = false;
            UpgradeButtons[5].interactable = false;
        }

        if(PlayerPrefs.GetInt("HealthUpgrade") == 1)
        {
            UpgradeButtons[6].interactable = false;
        }else if(PlayerPrefs.GetInt("HealthUpgrade") == 2)
        {
            UpgradeButtons[6].interactable = false;
            UpgradeButtons[7].interactable = false;
        }
    }
    public void SwordUpgrade1()
    {
        if (SwordImage.sprite != Sword3 && UpgradeAmount[0]<=Scoremng.instance.score)
        {
            SwordImage.sprite = Sword2;
            PlayerPrefs.SetInt("SwordUpgrade", 1);
            Scoremng.instance.score -= UpgradeAmount[0];
            PlayerPrefs.SetInt("Dna Show Amount", Scoremng.instance.score);
            PlayerPrefs.SetInt("Dna Point Amount", Scoremng.instance.score);
            FindObjectOfType<AudioManager>().Play("upgradebttn");
        }
    }
    public void SwordUpgrade2()
    {
        if (UpgradeAmount[4] <= Scoremng.instance.score)
        {
            SwordImage.sprite = Sword3;
            PlayerPrefs.SetInt("SwordUpgrade", 2);
            Scoremng.instance.score -= UpgradeAmount[4];
            PlayerPrefs.SetInt("Dna Show Amount", Scoremng.instance.score);
            PlayerPrefs.SetInt("Dna Point Amount", Scoremng.instance.score);
            FindObjectOfType<AudioManager>().Play("upgradebttn");
        }
    }
    public void ShieldUpgrade1()
    {
        if (ShieldImage.sprite != Shield3 && UpgradeAmount[1] <= Scoremng.instance.score)
        {
            ShieldImage.sprite = Shield2;
            PlayerPrefs.SetInt("ShieldUpgrade", 1);
            Scoremng.instance.score -= UpgradeAmount[1];
            PlayerPrefs.SetInt("Dna Show Amount", Scoremng.instance.score);
            PlayerPrefs.SetInt("Dna Point Amount", Scoremng.instance.score);
            FindObjectOfType<AudioManager>().Play("upgradebttn");
        }
    }
    public void ShieldUpgrade2()
    {
        if (UpgradeAmount[5] <= Scoremng.instance.score)
        {
            ShieldImage.sprite = Shield3;
            PlayerPrefs.SetInt("ShieldUpgrade", 2);
            Scoremng.instance.score -= UpgradeAmount[5];
            PlayerPrefs.SetInt("Dna Show Amount", Scoremng.instance.score);
            PlayerPrefs.SetInt("Dna Point Amount", Scoremng.instance.score);
            FindObjectOfType<AudioManager>().Play("upgradebttn");
        }
    }
    public void ArrowUpgrade1()
    {
        if (BowImage.sprite != Bow3 && UpgradeAmount[2] <= Scoremng.instance.score)
        {
            BowImage.sprite = Bow2;
            PlayerPrefs.SetInt("ArrowUpgrade", 1);
            Scoremng.instance.score -= UpgradeAmount[2];
            PlayerPrefs.SetInt("Dna Show Amount", Scoremng.instance.score);
            PlayerPrefs.SetInt("Dna Point Amount", Scoremng.instance.score);
            FindObjectOfType<AudioManager>().Play("upgradebttn");
        }
    }
    public void ArrowUpgrade2()
    {
        if (UpgradeAmount[6] <= Scoremng.instance.score)
        {
            BowImage.sprite = Bow3;
            PlayerPrefs.SetInt("ArrowUpgrade", 2);
            Scoremng.instance.score -= UpgradeAmount[6];
            PlayerPrefs.SetInt("Dna Show Amount", Scoremng.instance.score);
            PlayerPrefs.SetInt("Dna Point Amount", Scoremng.instance.score);
            FindObjectOfType<AudioManager>().Play("upgradebttn");
        }
    }
    public void HealthUpgrade1()
    {
        if(HealthFill.rect.width!= 732.562f && UpgradeAmount[3] <= Scoremng.instance.score)
        {
            HealthFill.sizeDelta = new Vector2(617.7889f, 84);
            HealthFill.localPosition = new Vector2(58, 0);
            PlayerPrefs.SetInt("HealthUpgrade", 1);
            Scoremng.instance.score -= UpgradeAmount[3];
            PlayerPrefs.SetInt("Dna Show Amount", Scoremng.instance.score);
            PlayerPrefs.SetInt("Dna Point Amount", Scoremng.instance.score);
            FindObjectOfType<AudioManager>().Play("upgradebttn");
        }
    }
    public void HealthUpgrade2()
    {
        if (UpgradeAmount[7] <= Scoremng.instance.score)
        {
            HealthFill.sizeDelta = new Vector2(732.562f, 84);
            HealthFill.localPosition = new Vector2(115.3f, 0);
            PlayerPrefs.SetInt("HealthUpgrade", 2);
            Scoremng.instance.score -= UpgradeAmount[7];
            PlayerPrefs.SetInt("Dna Show Amount", Scoremng.instance.score);
            PlayerPrefs.SetInt("Dna Point Amount", Scoremng.instance.score);
            FindObjectOfType<AudioManager>().Play("upgradebttn");
        }
    }
}
