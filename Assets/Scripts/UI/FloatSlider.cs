using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatSlider : MonoBehaviour {
    public Slider slider;
    public FloatValue floatValue;

    private void Start() {
        slider.value = floatValue.value;
    }

    public void OnValueChanged(float value) {
        floatValue.value = value;
    }
}
