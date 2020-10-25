using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour {
    public Transform ball;

    private void Start() {
        transform.position = ball.position;
    }

    private void Update() {
        if (transform.position != ball.position) {
            transform.position = ball.position;
        }
    }
}
