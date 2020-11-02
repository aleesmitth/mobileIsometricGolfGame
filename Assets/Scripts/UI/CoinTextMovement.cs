using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinTextMovement : MonoBehaviour {
    public FloatValue textSpeed;
    public FloatValue dissapearTimer;
    public FloatValue dissapearSpeed;
    public TextMeshProUGUI textMesh;
    private float timerBuffer;

    private void OnEnable() {
        transform.localScale = Vector3.one;
        timerBuffer = dissapearTimer.value;
        var colorBuffer = textMesh.color;
        //full alpha (visible)
        colorBuffer.a = 1;
        textMesh.color = colorBuffer;
    }

    private void Update() {
        transform.position += Vector3.up * textSpeed.value * Time.deltaTime;
        timerBuffer -= Time.deltaTime;
        if (timerBuffer > dissapearTimer.value * .7) {
            transform.localScale -= Vector3.one * Time.deltaTime;
        }
        else if (timerBuffer < dissapearTimer.value * .7 && timerBuffer > dissapearTimer.value * .2) {
            transform.localScale += Vector3.one * Time.deltaTime;
        }
        if (!(timerBuffer < 0)) return;
        var colorBuffer = textMesh.color;
        colorBuffer.a -= dissapearSpeed.value * Time.deltaTime;
        textMesh.color = colorBuffer;
        if(colorBuffer.a < 0)
            PoolCoinGrabText.instance.DestroyObject(gameObject);

    }
}
