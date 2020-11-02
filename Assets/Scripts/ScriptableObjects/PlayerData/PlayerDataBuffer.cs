using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
[CreateAssetMenu(fileName = "PlayerDataBuffer", menuName = "ScriptableObjects/PlayerDataBuffer")]
public class PlayerDataBuffer : ScriptableObject {
    public PlayerData playerData;
    [Header("Buffers to serialize")]
    public float coinBuffer;
    public float lightCoinBuffer;
    public float darkCoinBuffer;
    public float bestStreakBuffer;

    public void OnBeforeSerialize() {
        coinBuffer = playerData.totalCoins.value;
        lightCoinBuffer = playerData.totalLightCoins.value;
        darkCoinBuffer = playerData.totalDarkCoins.value;
        bestStreakBuffer = playerData.bestStreak.value;
    }
    
    public void OnAfterDeserialize() {
        playerData.totalCoins.value = coinBuffer;
        playerData.totalLightCoins.value = lightCoinBuffer;
        playerData.totalDarkCoins.value = darkCoinBuffer;
        playerData.bestStreak.value = bestStreakBuffer;
    }
}
