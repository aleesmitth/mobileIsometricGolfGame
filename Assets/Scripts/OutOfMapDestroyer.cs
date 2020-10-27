using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TODO HARDCODEADO, ES PARA NO PERDER RECURSOS SI SE CAE ALGO, DESPUES LO ARREGLO CON UN GAME MANAGER
public class OutOfMapDestroyer : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) other.transform.position = new Vector3(0,10,0);
        else Destroy(other.gameObject);
    }
}
