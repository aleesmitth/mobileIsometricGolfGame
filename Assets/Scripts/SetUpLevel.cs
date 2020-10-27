using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetUpLevel : MonoBehaviour {
    public Transform playerBall;
    public Transform startingPosition;
    public FloatValue fps;
    private float deltaTime = 0.0f;
    public TextMeshProUGUI fpsText;

    private void Awake() {
        //limitar fps
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    private void Start() {
        playerBall.position = startingPosition.position;
    }

    private void Update() {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    private void FixedUpdate() {
        //fps
        fps.value = 1.0f / deltaTime;
        float msec = deltaTime * 1000.0f;
        fpsText.text = $"{fps.value:0.} fps" + "\n" + $"{msec:0.0} ms";
    }
}
