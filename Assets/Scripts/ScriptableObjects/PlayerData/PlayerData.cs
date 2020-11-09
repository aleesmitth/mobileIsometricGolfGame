using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData")]
public class PlayerData : ScriptableObject {
    public FloatValue totalCoins;
    public FloatValue totalLightCoins;
    public FloatValue totalDarkCoins;
    public FloatValue bestStreak;
    public FloatValue quality;
}
