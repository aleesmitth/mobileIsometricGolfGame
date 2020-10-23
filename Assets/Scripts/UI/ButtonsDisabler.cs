using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsDisabler : MonoBehaviour {
    public FloatValue cooldown;
    public static ButtonsDisabler instance;

    private void Awake() {
        if(instance == null)
            instance = this;
    }

    public void StartCooldown(Button[] buttons) {
        foreach (var button in buttons) {
            instance.StartCoroutine(DisableButton(button));
        }
    }

    private IEnumerator DisableButton(Button button) {
        button.interactable = false;
        yield return new WaitForSeconds(cooldown.value);
        button.interactable = true;
    }
}
