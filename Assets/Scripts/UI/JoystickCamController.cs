using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class JoystickCamController : MonoBehaviour {
    public Joystick joystick;
    public Transform freelookVCam;
    public Transform ballVCam;
    public FloatValue camSpeed;

    private void Update() {
        var direction = joystick.Direction;
        direction = Quaternion.Euler(0, 0, -45) * direction;
        var camPosition = freelookVCam.position;
        freelookVCam.position = new Vector3(camPosition.x + direction.x * camSpeed.value, camPosition.y, camPosition.z + direction.y * camSpeed.value);
    }

    private void OnEnable() {
        freelookVCam.position = ballVCam.position;
    }
}
