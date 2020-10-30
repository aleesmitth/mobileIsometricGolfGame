using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData")]
public class PlayerData : ScriptableObject {
    public FloatValue coin;
    public FloatValue bestStreak;
    public float coinBuffer;
    public float bestStreakBuffer;

    public void OnBeforeSerialize() {
        coinBuffer = coin.value;
        bestStreakBuffer = bestStreak.value;
    }
    
    public void OnAfterDeserialize() {
        coin.value = coinBuffer;
        bestStreak.value = bestStreakBuffer;
    }
}
