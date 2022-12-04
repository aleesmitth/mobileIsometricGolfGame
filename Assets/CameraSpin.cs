using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraSpin : MonoBehaviour {
    public Transform freelookVCamTransf;
    public Transform ballVCamTranf;
    public FloatValue camRotationSpeed;
    public FloatValue minCamRotationValue;
    private Vector3 touchInitialPosition;
    private bool initialTouch = default(bool);
    public Transform ballTracker;
    public RectTransform rotationOutOfBounds;
    private void Update() {
        //cam rotation
        if (Input.touchCount != 1) return;
        var touch = Input.GetTouch(0);
        switch (touch.phase) {
            case TouchPhase.Began:
                StartDrag();
                break;
            case TouchPhase.Stationary:
            case TouchPhase.Moved:
                Dragging();
                break;
            case TouchPhase.Canceled:
            case TouchPhase.Ended:
                Release();
                break;
            default:
                break;
        }
    }
    
    

    

    private void StartDrag() {
        this.touchInitialPosition = GetTouchPosition(0);
        //todo: here i should validate if initial touch is within bounds, example not taped a button or camera joystick.
        if (RectTransformUtility.RectangleContainsScreenPoint(rotationOutOfBounds, this.touchInitialPosition)) return;
        this.initialTouch = true;
        //Debug.DrawRay(transform.position, initialTouchPosition, Color.red, 2f);
    }

    private void Dragging() {
        //if(!ImStill()) return;
        if (!initialTouch) return;
        var position = GetTouchPosition(0);
        //direction from where i am touching now to initial touch
        var direction = this.touchInitialPosition - position;
        if (direction.magnitude < minCamRotationValue.value) return;
        //direction relative to my ball
        //direction = mainBall.position - direction;
        //disable rotation in y axis
        //direction.y = 0;

        //Debug.DrawRay(mainBall.position, direction, Color.cyan, 2f);
        //Debug.DrawRay(mainBall.position, direction, Color.cyan, 2f);
        //freelookVCam.rotation = Quaternion.LookRotation(direction,Vector3.up);
        //var targetRotation = Quaternion.AngleAxis(180, transform.up) * freelookVCam.rotation;
        //freelookVCam.rotation = Quaternion.Slerp(freelookVCam.rotation,targetRotation, camSpeed.value * Time.deltaTime);
        freelookVCamTransf.transform.RotateAround(ballTracker.transform.position, Vector3.up,
            Mathf.Sign(-direction.x) * direction.magnitude * camRotationSpeed.value * Time.deltaTime);
        
        //freelookVCam.rotation = Quaternion.Lerp(freelookVCam.rotation, lookRotation, Time.deltaTime * camSpeed.value);
        //mainBall.transform.forward = direction;
        //mainBall.ro

        //mainBall.rotation();
    }

    private void Release() {
        initialTouch = false;
        freelookVCamTransf.position = ballVCamTranf.position;
        freelookVCamTransf.rotation = ballVCamTranf.rotation;
    }
    
    private Vector3 GetTouchPosition(int touchNumber) {
        return Input.GetTouch(touchNumber).position;
    }

    private void Start() {
        freelookVCamTransf.rotation = ballVCamTranf.rotation;
    }
}
