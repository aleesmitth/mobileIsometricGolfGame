using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimBallsController : MonoBehaviour {
    public Transform[] aimingBalls;
    public FloatValue shotStrength;
    [System.Serializable]

    public struct BallDistanceMultiplier {
        public float[] ballMultipliers;
    }

    public BallDistanceMultiplier ballDistanceMultiplier;

    private void FixedUpdate() {
        /*if (Input.GetKey(KeyCode.R)) {
            int i = 0;
            foreach (var ball in aimingBalls) {
                ball.position = initialPositions[i];
                i++;
            }
        }*/
        int i = 0;
        foreach (var ball in aimingBalls) {
            //just in case that i have more multipliers than balls in my inspector
            if (i > ballDistanceMultiplier.ballMultipliers.Length) break;
            var localPosition = ball.localPosition;
            localPosition = new Vector3(localPosition.x, localPosition.y,shotStrength.value * ballDistanceMultiplier.ballMultipliers[i]);
            ball.localPosition = localPosition;
            i++;
        }
    }

    public void ResetBalls() {
        foreach (var ball in aimingBalls) {
            var localPosition = ball.localPosition;
            localPosition = new Vector3(localPosition.x, localPosition.y, 0);
            ball.localPosition = localPosition;
        }
    }
}
