using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public FloatValue totalCoins;
    public FloatValue finishLevelReward;
    public DisplayFloatValue coinDisplay;
    private void OnEnable() {
        EventManager.onCoinGrabbed += GainCoin;
    }

    private void OnDisable() {
        EventManager.onCoinGrabbed -= GainCoin;
    }

    public void LevelFinished() {
        totalCoins.value += finishLevelReward.value;
        coinDisplay.Display();
    }

    private void GainCoin() {
        totalCoins.value++;
        coinDisplay.Display();
    }
}
