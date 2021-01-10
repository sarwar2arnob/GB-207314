using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponChange : MonoBehaviour
{
    [SerializeField] GameObject Bow, Sword, ArrowButton1, ArrowButton2, AttackButton;
    Image ImagetoChange;
    [SerializeField] Sprite ArrowIcon, SwordIcon;
    bool ButtonPressed;
    // Start is called before the first frame update
    void Start()
    {
        ImagetoChange = GetComponent<Image>();
        FindObjectOfType<AudioManager>().Play("WC Sword");
    }

    // Update is called once per frame
    void Update()
    {
        if (ButtonPressed && ImagetoChange.sprite == ArrowIcon)
        {
            ImagetoChange.sprite = SwordIcon;
        }
        else if (ButtonPressed && ImagetoChange.sprite == SwordIcon)
        {
            ImagetoChange.sprite = ArrowIcon;
        }
        if(ImagetoChange.sprite == ArrowIcon)
        {
            AttackButton.GetComponent<Button>().enabled = true;
            AttackButton.GetComponent<Image>().color = new Color(1, 1, 1, .9f);
            ArrowButton1.SetActive(false);
            ArrowButton2.SetActive(false);
            Sword.GetComponent<SpriteRenderer>().color = new Color(Sword.GetComponent<SpriteRenderer>().color.r, Sword.GetComponent<SpriteRenderer>().color.g, Sword.GetComponent<SpriteRenderer>().color.b, 1);
            Bow.SetActive(false);
        }
        else if(ImagetoChange.sprite == SwordIcon)
        {
            AttackButton.GetComponent<Button>().enabled = false;
            AttackButton.GetComponent<Image>().color = new Color(.4f, .4f, .4f, .9f);
            ArrowButton1.SetActive(true);
            ArrowButton2.SetActive(true);
            Sword.GetComponent<SpriteRenderer>().color = new Color(Sword.GetComponent<SpriteRenderer>().color.r, Sword.GetComponent<SpriteRenderer>().color.g, Sword.GetComponent<SpriteRenderer>().color.b, 0);
            Bow.SetActive(true);
            FindObjectOfType<AudioManager>().Play("WC Sword");
        }
        ButtonPressed = false;
    }

    public void ButtonPress()
    {
        ButtonPressed = true;
    }
}
