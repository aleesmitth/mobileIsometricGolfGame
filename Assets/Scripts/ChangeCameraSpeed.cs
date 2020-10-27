using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraSpeed : MonoBehaviour {
    public FloatValue cameraSpeed;
    public void IncreaseSpeed() {
        if(cameraSpeed.value >= 5) return;
        cameraSpeed.value += .2f;
    }

    public void DecreaseSpeed() {
        if(cameraSpeed.value == 0) return;
        cameraSpeed.value -= .2f;
    }
}
