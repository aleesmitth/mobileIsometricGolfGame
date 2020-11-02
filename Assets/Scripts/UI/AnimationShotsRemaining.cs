using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationShotsRemaining : MonoBehaviour {
    public FloatValue remainingShotsTimerAnimation;
    private float timerBuffer;
    private void OnEnable() {
        EventManager.onPlayerReceiveRewards += ResetAnimationTimer;
    }
    private void OnDisable() {
        EventManager.onPlayerReceiveRewards += ResetAnimationTimer;
    }

    private void ResetAnimationTimer() {
        timerBuffer = remainingShotsTimerAnimation.value;
    }

    private void Update() {
        if (timerBuffer < 0) return;
        timerBuffer -= Time.deltaTime;
        if (timerBuffer > remainingShotsTimerAnimation.value * 0.85) {
            transform.localScale -= Vector3.one * Time.deltaTime;
        }
        else if (timerBuffer > remainingShotsTimerAnimation.value * 0.45) {
            transform.localScale += Vector3.one * Time.deltaTime;
        }
        else if(timerBuffer > 0 && transform.localScale.sqrMagnitude > Vector3.one.sqrMagnitude) {
            transform.localScale -= Vector3.one * Time.deltaTime;
        }
        //just in case that the localscale doesnt end up in 1,1,1.
        else {
            transform.localScale = Vector3.one;
        }
    }
}
