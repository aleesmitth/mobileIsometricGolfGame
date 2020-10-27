using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfClubRotation : MonoBehaviour { 
    public FloatValue shotStrength;
    public Transform ballPositionWithOffset;
    //TODO puedo hacer que en vez de enparentarlo con la rotacion de la bola, solo actualizo el forward en update
    //TODO y cuando me hacen onenable actualizo la posicion
    //el evento me permite mover mi golfclub a la bola, aunque la animacion del disparo anterior no haya desaparecido.
    private void OnEnable() {
        EventManager.onBallDragged += UpdatePosition;
    }
    private void OnDisable() {
        EventManager.onBallDragged -= UpdatePosition;
    }

    private void UpdatePosition() {
        transform.position = ballPositionWithOffset.position;
        transform.forward = ballPositionWithOffset.forward;
    }

    private void Update() {
        // esto lo hace rotar sin parar constate y relativo a la velocidad
        //transform.Rotate(shotStrength.value, 0,0);

        var golfClubTransform = transform;
        var eulerAngles = golfClubTransform.eulerAngles;
        eulerAngles.x = shotStrength.value;
        golfClubTransform.eulerAngles = eulerAngles;
    }
    
}
