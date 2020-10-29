using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public Transform playerBall;
    public Transform golfClub;
    public FloatValue currentStreak;
    public Levels allTheLevels;
    public Transform startingPosition;
    public GameObject currentMap;
    public void LoadLevel() {
        bool inRange = false;
        int i = 0;
        while (!inRange && i < allTheLevels.levels.Length) {
            if (allTheLevels.levels[i].levelRangeMax > currentStreak.value) {
                inRange = true;
                this.currentMap = allTheLevels.levels[i].GetRandomMap();
            }

            i++;
        }

        if (!inRange) {
            this.currentMap = allTheLevels.levels[i - 1].GetRandomMap();
        }

        this.currentMap = Instantiate(this.currentMap);
        this.startingPosition = this.currentMap.transform.Find("StartingPosition");
        playerBall.transform.position = startingPosition.position;
        playerBall.gameObject.SetActive(true);
    }

    public void UnloadLevel() {
        golfClub.gameObject.SetActive(false);
        playerBall.gameObject.SetActive(false);
        Destroy(this.currentMap);
    }

    public void StartGame() {
        playerBall.position = startingPosition.position;
        playerBall.gameObject.SetActive(true);
    }
}
