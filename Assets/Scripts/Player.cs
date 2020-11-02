using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public FloatValue totalCoins;
    public FloatValue remainingShots;
    public FloatValue levelCoinReward;
    public FloatValue levelShotReward;
    public DisplayFloatValue coinDisplay;
    public DisplayFloatValue shotsDisplay;
    public GameObject gainedShots;
    
    private void OnEnable() {
        EventManager.onCoinGrabbed += GainCoin;
        EventManager.onPlayerReceiveRewards += LevelFinished;
        EventManager.onBallHit += MinusRemainingShot;
    }

    private void OnDisable() {
        EventManager.onCoinGrabbed -= GainCoin;
        EventManager.onPlayerReceiveRewards -= LevelFinished;
        EventManager.onBallHit -= MinusRemainingShot;
    }

    private void MinusRemainingShot() {
        remainingShots.value--;
        shotsDisplay.Display();
    }

    private void LevelFinished() {
        totalCoins.value += levelCoinReward.value;
        remainingShots.value += levelShotReward.value;
        gainedShots.SetActive(true);
        coinDisplay.Display();
        shotsDisplay.Display();
    }

    private void GainCoin() {
        totalCoins.value++;
        coinDisplay.Display();
    }
}
