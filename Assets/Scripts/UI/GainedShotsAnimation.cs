using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GainedShotsAnimation : MonoBehaviour {
    public TextMeshProUGUI gainedShotText;
    public FloatValue gainedShotTimer;
    public FloatValue gainedShotSpeed;
    public FloatValue gainedShotDissapearSpeed;
    private float timerBuffer;
    private Vector3 initialPosition;
    private Color colorBuffer;
    private void OnEnable() {
        var transformBuffer = transform;
        transformBuffer.localScale = Vector3.zero;
        colorBuffer = gainedShotText.color;
        colorBuffer.a = 0;
        gainedShotText.color = colorBuffer;
        
        timerBuffer = gainedShotTimer.value;
        initialPosition = transformBuffer.position;
    }

    private void Update() {
        if (transform.localScale.sqrMagnitude < Vector3.one.sqrMagnitude) {
            transform.localScale += Vector3.one * (Time.deltaTime * gainedShotDissapearSpeed.value * 2);
            if (!(gainedShotText.color.a < 1f)) return;
            colorBuffer = gainedShotText.color;
            colorBuffer.a += gainedShotDissapearSpeed.value * 2 * Time.deltaTime;
            gainedShotText.color = colorBuffer;
        }
        else {
            timerBuffer -= Time.deltaTime;
            if (timerBuffer > gainedShotTimer.value * 0.85) {
                transform.position += Vector3.up * gainedShotSpeed.value * Time.deltaTime;
            }
            else if (timerBuffer > gainedShotTimer.value * 0.4 &&
                     transform.position.sqrMagnitude > initialPosition.sqrMagnitude) {
                transform.position += Vector3.down * gainedShotSpeed.value * Time.deltaTime;
            }
            else {
                transform.position = initialPosition;
            }

            if (!(timerBuffer < 0)) return;
            colorBuffer = gainedShotText.color;
            colorBuffer.a -= gainedShotDissapearSpeed.value * Time.deltaTime;
            gainedShotText.color = colorBuffer;
            if (colorBuffer.a < 0)
                gameObject.SetActive(false);
        }
    }
}
