using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour {
    public Transform startingPosition;
    private void OnTriggerEnter(Collider other) {
        if (!other.gameObject.CompareTag("Player")) return;
        other.transform.position = startingPosition.position;
    }
}
