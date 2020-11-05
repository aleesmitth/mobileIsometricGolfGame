using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfClubRotation : MonoBehaviour {
    private bool doReleaseRotation;
    public FloatValue shotStrength;
    public Transform ballPositionWithOffset;
    //TODO puedo hacer que en vez de enparentarlo con la rotacion de la bola, solo actualizo el forward en update
    //TODO y cuando me hacen onenable actualizo la posicion
    //el evento me permite mover mi golfclub a la bola, aunque la animacion del disparo anterior no haya desaparecido.
    private void OnEnable() {
        EventManager.onBallDragged += UpdatePosition;
        EventManager.onBallHit += SetTransform;
        doReleaseRotation = false;
    }

    private void SetTransform() {
        doReleaseRotation = true;
    }

    private void OnDisable() {
        EventManager.onBallDragged -= UpdatePosition;
        EventManager.onBallHit -= SetTransform;
        doReleaseRotation = false;
    }

    private void UpdatePosition() {
        var transformBuffer = transform;
        transformBuffer.position = ballPositionWithOffset.position;
        transformBuffer.forward = ballPositionWithOffset.forward;
    }

    private void Update() {
        //roto al palo de golf, slerp cuando golpea, eulers cuando preparo el disparo.
        
        // esto lo hace rotar sin parar constate y relativo a la velocidad
        //transform.Rotate(shotStrength.value, 0,0);
        if (doReleaseRotation) {
            var rotationBuffer = transform.rotation;
            var rotationXAxis = Quaternion.Euler(shotStrength.value, rotationBuffer.eulerAngles.y, rotationBuffer.eulerAngles.z);
            //multiplico el tiempo *30 para que la animacion del palo termine antes que la pelota se mueva mucho.
            rotationBuffer =
                Quaternion.Slerp(rotationBuffer, rotationXAxis, Time.deltaTime * 30f);
            transform.rotation = rotationBuffer;
            if (transform.rotation == rotationXAxis) doReleaseRotation = false;
        }
        else {
            var golfClubTransform = transform;
            var eulerAngles = golfClubTransform.eulerAngles;
            eulerAngles.x = shotStrength.value;
            golfClubTransform.eulerAngles = eulerAngles;
        }
    }
}
