using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData")]
public class PlayerData : ScriptableObject {
    public FloatValue totalCoins;
    public FloatValue bestStreak;
    public float coinBuffer;
    public float bestStreakBuffer;

    public void OnBeforeSerialize() {
        coinBuffer = totalCoins.value;
        bestStreakBuffer = bestStreak.value;
    }
    
    public void OnAfterDeserialize() {
        totalCoins.value = coinBuffer;
        bestStreak.value = bestStreakBuffer;
    }
}
