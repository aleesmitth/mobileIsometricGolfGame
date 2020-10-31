using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour {
    private int coin = 1;
    private void OnTriggerEnter(Collider other) {
        if (!other.gameObject.CompareTag("Player")) return;
        EventManager.OnCoinGrabbed();

        GameObject textGameObject = PoolCoinGrabText.instance.Get();
        textGameObject.transform.localScale = Vector3.one;
        textGameObject.GetComponent<TextMeshProUGUI>().text = "+" + coin;
        textGameObject.transform.position = Camera.main.WorldToScreenPoint(transform.position);
        
        gameObject.SetActive(false);
    }
}
