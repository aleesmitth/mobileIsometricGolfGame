using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayFloatValue : MonoBehaviour {
    public TextMeshProUGUI text;
    public FloatValue floatValue;
    private string originalText;

    private void Start() {
        this.originalText = text.text;
    }

    public void Display() {
        text.text = floatValue.value + "\n" + originalText;
    }
}
