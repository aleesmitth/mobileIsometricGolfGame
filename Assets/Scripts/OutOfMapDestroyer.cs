using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class OutOfMapDestroyer : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.gameObject.SetActive(false);
            EventManager.OnPlayerDied();
        }
        else {
            other.gameObject.SetActive(false);
        }
    }
}
