using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayFloatValue : MonoBehaviour {
    public TextMeshProUGUI text;
    public FloatValue floatValue;
    public bool inTheSameLine;
    private string originalText;

    private void Awake() {
        this.originalText = text.text;
    }

    private void OnEnable() {
        Display();
    }

    public void Display() {
        // le dejo solo 1 decimal
        if (floatValue.value % 1 != 0) {
            floatValue.value = Mathf.Floor(floatValue.value*10f) / 10f;
        }
        if (inTheSameLine)
            text.text = originalText + floatValue.value;
        else {
            text.text = floatValue.value + "\n" + originalText;
        }
    }
}
