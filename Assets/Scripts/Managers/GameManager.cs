using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    private float deltaTime = 0.0f;
    public FloatValue fps;
    public TextMeshProUGUI fpsText;
    public FloatValue currentStreak;
    public FloatValue bestStreak;
    public DisplayFloatValue currentStreakDisplay;
    public DisplayFloatValue bestStreakDisplay;
    public LevelManager levelManager;

    public static GameManager instance;

    private void Awake() {
        this.MakeSingleton();
        //limitar fps
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    private void OnEnable() {
        EventManager.onLevelFinished += LevelFinished;
    }

    private void OnDisable() {
        EventManager.onLevelFinished -= LevelFinished;
    }

    public void ChangeGameQuality(bool higherQuality) {
        if (higherQuality) {
            QualitySettings.IncreaseLevel();
        }
        else {
            QualitySettings.DecreaseLevel();
        }
        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    private void MakeSingleton() {
        if (instance == null) {
            instance = this;
        }
        else if(instance!=this)
            Destroy(gameObject);
    }

    private void LevelFinished() {
        currentStreak.value++;
        if (currentStreak.value > bestStreak.value) {
            bestStreak.value = currentStreak.value;
            bestStreakDisplay.Display();
        }
        currentStreakDisplay.Display();
        levelManager.UnloadLevel();
        levelManager.LoadLevel();
    }

    public void StartGame() {
        levelManager.StartGame();
    }
    
    private void Update() {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }
    
    private void FixedUpdate() {
        //fps
        fps.value = 1.0f / deltaTime;
        float msec = deltaTime * 1000.0f;
        fpsText.text = $"{fps.value:0.} fps" + "\n" + $"{msec:0.0} ms";
    }
}
