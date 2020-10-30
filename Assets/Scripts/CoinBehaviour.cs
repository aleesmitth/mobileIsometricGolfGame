using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (!other.gameObject.CompareTag("Player")) return;
        EventManager.OnCoinGrabbed();
        //placeholder para pool
        gameObject.SetActive(false);
    }
}
