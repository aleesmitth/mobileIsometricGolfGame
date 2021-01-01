using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
[CreateAssetMenu(fileName = "PlayerDataBuffer", menuName = "ScriptableObjects/PlayerDataBuffer")]
public class PlayerDataBuffer : ScriptableObject {
    [Header("Buffers to serialize")]
    public float cameraSpeedBuffer = default(float);
    public float coinBuffer = default(float);
    public float lightCoinBuffer = default(float);
    public float darkCoinBuffer = default(float);
    public float bestStreakBuffer = default(float);
    public float qualityBuffer = default(float);

    public void OnBeforeSerialize(PlayerData playerData) {
        cameraSpeedBuffer = playerData.cameraSpeed.value;
        coinBuffer = playerData.totalCoins.value;
        lightCoinBuffer = playerData.totalLightCoins.value;
        darkCoinBuffer = playerData.totalDarkCoins.value;
        bestStreakBuffer = playerData.bestStreak.value;
        qualityBuffer = playerData.quality.value;
    }
    
    public void OnAfterDeserialize(PlayerData playerData) {
        playerData.cameraSpeed.value = cameraSpeedBuffer;
        playerData.totalCoins.value = coinBuffer;
        playerData.totalLightCoins.value = lightCoinBuffer;
        playerData.totalDarkCoins.value = darkCoinBuffer;
        playerData.bestStreak.value = bestStreakBuffer;
        playerData.quality.value = qualityBuffer;
    }
}
