using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    public Gradient gradient;

    private float targetProgress = 0;
    public float fillSpeed = 0.5f;

    public void SetMaxenergy(float energy)
    {
        slider.maxValue = energy;
        slider.value = energy;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetEnergy(float energy)
    {
        targetProgress = energy;

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

    //public void SetEnergy(float energy)
    //{
    //    slider.value = energy;

    //    fill.color = gradient.Evaluate(slider.normalizedValue);
    //}
}
