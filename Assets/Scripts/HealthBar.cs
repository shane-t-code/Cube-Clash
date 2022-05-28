using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider2;
    public Image fill2;
    public Gradient gradient2;

    public void SetMaxHealth(float health)
    {
        slider2.maxValue = health;
        slider2.value = health;

        fill2.color = gradient2.Evaluate(1f);
    }

    public void SetHealth(float health)
    {
        slider2.value = health;

        fill2.color = gradient2.Evaluate(slider2.normalizedValue);
    }
}
