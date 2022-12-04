using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraZoom : MonoBehaviour {
    public CinemachineVirtualCamera ballVCam;
    public CinemachineVirtualCamera freelookVCam;
    public Transform ballVCamTranf;
    public Transform freelookVCamTransf;
    public FloatValue camZoomSpeed;
    public FloatValue minCamZoomValue;
    public FloatValue maxZoom;
    public FloatValue minZoom;
    private Vector3 initialZoomDistance;
    private Vector3[] touchInitialPositions;
    private bool[] initialZoomTouch;
    private void Update() {
        if (Input.touchCount == 1) {
            var touch = Input.GetTouch(0);
            switch (touch.phase) {
                case TouchPhase.Began:
                    StartDrag(0);
                    break;
                case TouchPhase.Canceled:
                case TouchPhase.Ended:
                    Release(0);
                    break;
                default:
                    break;
            }
        }

        if (Input.touchCount != 2) return;
        for (int i = 1; i >= 0; i--) {
            var touch = Input.GetTouch(i);
            switch (touch.phase) {
                case TouchPhase.Began:
                    StartDrag(i);
                    break;
                case TouchPhase.Moved:
                    Dragging(i);
                    break;
                case TouchPhase.Canceled:
                case TouchPhase.Ended:
                    Release(i);
                    break;
                default:
                    break;
            }
        }
    }
    private void StartDrag(int touchNumber) {
        /*this.initialTouchZoomPosition[touchNumber] = GetTouchPosition(touchNumber);
        this.zoomInitialTouch[touchNumber] = true;*/
        this.touchInitialPositions[touchNumber] = GetTouchPosition(touchNumber);
        this.initialZoomTouch[touchNumber] = true;
    }

    private void Dragging(int touchNumber) {
        //if(!ImStill()) return;
        if (!initialZoomTouch[0] || !initialZoomTouch[1]) return;
        if (initialZoomDistance.Equals(Vector3.zero))
            initialZoomDistance = touchInitialPositions[0] - touchInitialPositions[1];
        var touchPosition = GetTouchPosition(touchNumber);
        //direction from where i am touching now to initial touch
        var otherTouchPosition = GetTouchPosition(Opposite(touchNumber));
        var distance = touchPosition - otherTouchPosition;
        var deltaDistance = distance.magnitude - initialZoomDistance.magnitude;
        //Debug.Log($"delta distance {deltaDistance}");
        if (Math.Abs(deltaDistance) < minCamZoomValue.value) return;
        if (deltaDistance < 0) {
            if (freelookVCam.m_Lens.OrthographicSize < maxZoom.value)
                freelookVCam.m_Lens.OrthographicSize += Time.deltaTime * camZoomSpeed.value;
        }
        else {
            if (freelookVCam.m_Lens.OrthographicSize > minZoom.value)
                freelookVCam.m_Lens.OrthographicSize -= Time.deltaTime * camZoomSpeed.value;
        }
        /*var direction = this.touchInitialPositions[touchNumber] - position;
        if (direction.magnitude < minCamZoomValue.value) return;
        if ((position - touchInitialPositions[Opposite(touchNumber)]).magnitude < initialZoomDistance.magnitude) {
            if (freelookVCam.m_Lens.OrthographicSize > minZoom.value)
                freelookVCam.m_Lens.OrthographicSize -= Time.deltaTime * camZoomSpeed.value;
        }
        else {
            if (freelookVCam.m_Lens.OrthographicSize < maxZoom.value)
                freelookVCam.m_Lens.OrthographicSize += Time.deltaTime * camZoomSpeed.value;
        }*/
        //direction relative to my ball
        //direction = mainBall.position - direction;
        //disable rotation in y axis
        //direction.y = 0;

        //Debug.DrawRay(mainBall.position, direction, Color.cyan, 2f);
        //Debug.DrawRay(mainBall.position, direction, Color.cyan, 2f);
        //freelookVCam.rotation = Quaternion.LookRotation(direction,Vector3.up);
        //var targetRotation = Quaternion.AngleAxis(180, transform.up) * freelookVCam.rotation;
        //freelookVCam.rotation = Quaternion.Slerp(freelookVCam.rotation,targetRotation, camSpeed.value * Time.deltaTime);
        /*freelookVCamTransf.transform.RotateAround(ballTracker.transform.position, Vector3.up,
            Mathf.Sign(direction.x) * direction.magnitude * camRotationSpeed.value * Time.deltaTime);*/

        //freelookVCam.rotation = Quaternion.Lerp(freelookVCam.rotation, lookRotation, Time.deltaTime * camSpeed.value);
        //mainBall.transform.forward = direction;
        //mainBall.ro

        //mainBall.rotation();
    }

    private int Opposite(int touchNumber) {
        return touchNumber == 0 ? 1 : 0;
    }
    
    private Vector3 GetTouchPosition(int touchNumber) {
        return Input.GetTouch(touchNumber).position;
    }

    private void Release(int touchNumber) {
        Debug.Log("release");
        initialZoomTouch[touchNumber] = false;
        freelookVCamTransf.position = ballVCamTranf.position;
        freelookVCamTransf.rotation = ballVCamTranf.rotation;
        freelookVCam.m_Lens.OrthographicSize = ballVCam.m_Lens.OrthographicSize;
        initialZoomDistance = Vector3.zero;
        
    }

    private void Start() {
        initialZoomTouch = new bool[2];
        touchInitialPositions = new Vector3[2];
        initialZoomDistance = Vector3.zero;
        freelookVCam.m_Lens.OrthographicSize = ballVCam.m_Lens.OrthographicSize;
    }
}
