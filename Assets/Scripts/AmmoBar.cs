using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    public Gradient gradient;

    private float targetProgress = 0;
    public float fillSpeed = 0.5f;

    public void SetMaxAmmo(float ammo)
    {
        slider.maxValue = ammo;
        slider.value = ammo;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetAmmo(float ammo)
    {
        targetProgress = ammo;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void Update()
    {
        if (slider.value < targetProgress)
        {
            slider.value += fillSpeed * Time.deltaTime;
        }
        else
        {
            slider.value -= fillSpeed * Time.deltaTime;
        }
    }
}
