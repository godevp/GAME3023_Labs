using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public float mp;
    public Slider mpSlider;

    private void Start()
    {
        mpSlider.maxValue = mp;
        mpSlider.value = mp;
    }

    private void Update()
    {
        mpSlider.value = mp;
    }

}
