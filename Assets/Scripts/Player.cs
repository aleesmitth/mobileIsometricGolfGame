using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public FloatValue coin;
    public DisplayFloatValue coinDisplay;
    private void OnEnable() {
        EventManager.onCoinGrabbed += GainCoin;
    }

    private void OnDisable() {
        EventManager.onCoinGrabbed -= GainCoin;
    }

    private void GainCoin() {
        coin.value++;
        coinDisplay.Display();
    }
}
