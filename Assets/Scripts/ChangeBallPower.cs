using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBallPower : MonoBehaviour {
    public FloatValue ballPower;
    public FloatValue maxPower;
    public void IncreasePower() {
        if(ballPower.value >= maxPower.value) return;
        ballPower.value += 1f;
    }

    public void DecreasePower() {
        if(ballPower.value == 0) return;
        ballPower.value -= 1f;
    }
}
