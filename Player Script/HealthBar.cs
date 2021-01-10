using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    [SerializeField]
    RectTransform HealthFill;
    public void SetHealth(int Health)
    {
        slider.value = Health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }
    private void Awake()
    {
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
}