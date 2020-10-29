using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour {
    public FloatValue coin;
    private void OnTriggerEnter(Collider other) {
        Debug.Log("asd");
        if (!other.gameObject.CompareTag("Player")) return;
        Debug.Log("asdd");
        EventManager.OnCoinGrabbed();
        //placeholder para pool
        gameObject.SetActive(false);
    }
}
