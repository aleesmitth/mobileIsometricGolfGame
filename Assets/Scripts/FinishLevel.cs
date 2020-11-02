using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public enum PortalType {
    Dark,
    Light,
    Normal
}
public class FinishLevel : MonoBehaviour {
    public FloatValue finishLevelReward;
    public PortalType portalType;
    private void OnTriggerEnter(Collider other) {
        if (!other.gameObject.CompareTag("Player")) return;
        
        GameObject textGameObject = PoolCoinGrabText.instance.Get();
        textGameObject.transform.localScale *= 1.5f;
        textGameObject.GetComponent<TextMeshProUGUI>().text = "+" + finishLevelReward.value;
        textGameObject.transform.position = Camera.main.WorldToScreenPoint(transform.position);
        
        EventManager.OnLevelFinished(portalType);
    }
}
