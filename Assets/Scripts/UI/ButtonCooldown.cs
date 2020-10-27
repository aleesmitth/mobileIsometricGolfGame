using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCooldown : MonoBehaviour {
    public Button thisButton;
    public Button[] buttonsToCooldown;

    private void Awake() {
        thisButton.onClick.AddListener(StartCooldown);
    }

    private void StartCooldown() {
        ButtonsDisabler.instance.StartCooldown(buttonsToCooldown);
    }
}
