using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AntiBodyBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetAntiBodyPoint(float AntiBodyPoint)
    {
        slider.value = AntiBodyPoint;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    public void SetMaxAntiBodyPoint(float AntiBody)
    {
        slider.maxValue = AntiBody;
        fill.color = gradient.Evaluate(1f);
    }

}