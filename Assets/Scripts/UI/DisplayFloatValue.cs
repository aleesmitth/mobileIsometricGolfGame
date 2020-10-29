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

    public void Display() {
        if (inTheSameLine)
            text.text = originalText + " " + floatValue.value;
        else {
            text.text = floatValue.value + "\n" + originalText;
        }
    }
}
