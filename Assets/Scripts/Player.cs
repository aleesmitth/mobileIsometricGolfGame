using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public FloatValue totalCoins;
    public FloatValue remainingShots;
    public FloatValue totalLightCoins;
    public FloatValue totalDarkCoins;
    public FloatValue levelCoinReward;
    public FloatValue levelShotReward;
    public FloatValue levelLightReward;
    public FloatValue levelDarkReward;
    public DisplayFloatValue normalCoinDisplay;
    public DisplayFloatValue lightCoinDisplay;
    public DisplayFloatValue darkCoinDisplay;
    public DisplayFloatValue shotsDisplay;
    public GameObject gainedShots;
    
    private void OnEnable() {
        EventManager.onCoinGrabbed += GainCoin;
        EventManager.onPlayerReceiveRewards += LevelFinished;
        EventManager.onBallHit += OneLessRemainingShot;
    }

    private void OnDisable() {
        EventManager.onCoinGrabbed -= GainCoin;
        EventManager.onPlayerReceiveRewards -= LevelFinished;
        EventManager.onBallHit -= OneLessRemainingShot;
    }

    private void OneLessRemainingShot() {
        remainingShots.value--;
        shotsDisplay.Display();
    }

    private void LevelFinished() {
        totalCoins.value += levelCoinReward.value;
        
        if (levelLightReward.value > 0) {
            totalLightCoins.value += levelLightReward.value;
            lightCoinDisplay.Display();
        }
        
        if (levelDarkReward.value > 0) {
            totalDarkCoins.value += levelDarkReward.value;
            darkCoinDisplay.Display();
        }

        remainingShots.value += levelShotReward.value;
        gainedShots.SetActive(true);
        normalCoinDisplay.Display();
        shotsDisplay.Display();
    }

    private void GainCoin() {
        totalCoins.value++;
        normalCoinDisplay.Display();
    }
}
