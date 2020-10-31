using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class InactiveOnClick : MonoBehaviour {
    public Button button;
    public GameObject toDeactivate;
    void Start() {
        button.onClick.AddListener(Exit);
    }

    private void Update() {
        if (Input.GetKey(KeyCode.Escape)) {
            Exit();
        }
    }

    private void Exit() {
        toDeactivate.SetActive(false);
    }
}
