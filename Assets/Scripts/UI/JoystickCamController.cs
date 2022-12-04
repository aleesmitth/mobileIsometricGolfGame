using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class JoystickCamController : MonoBehaviour {
    public Joystick joystick;
    public Transform freelookVCamTransf;
    private CinemachineVirtualCamera ballVCam;
    public Transform ballVCamTranf;
    public FloatValue camSpeed;
    private Camera _camera;
    public Transform ballTracker;

    private void Awake() {
        ballVCam = ballVCamTranf.GetComponent<CinemachineVirtualCamera>();
        _camera = Camera.main;
    }

    private void Update() {
        var direction = joystick.Direction;
        direction = Quaternion.Euler(0, 0, -45) * direction;
        var camPosition = freelookVCamTransf.position;
        freelookVCamTransf.position = new Vector3(camPosition.x + direction.x * camSpeed.value, camPosition.y, camPosition.z + direction.y * camSpeed.value);
    }
    

    private void OnEnable() {
        freelookVCamTransf.position = ballVCamTranf.position;
    }
}
