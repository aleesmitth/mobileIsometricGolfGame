using System;
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
    public FloatValue finishLevelReward;

    public void LoadLevel() {
        bool inRange = false;
        int i = 0;
        while (!inRange && i < allTheLevels.levels.Length) {
            if (allTheLevels.levels[i].levelRangeMax > currentStreak.value) {
                inRange = true;
                //lo hice al azar esto, pero cada vez q cambia de stage, cambian las rewards por terminar el mapa
                //el player va a recibir las rewards 1 mapa atrasado digamos, porq las recibe antes
                //de cargar el mapa, esto seria como setearlas para el proximo
                this.finishLevelReward.value = (currentStreak.value + 1) * allTheLevels.levels[i].levelRangeMax;
                this.currentMap = allTheLevels.levels[i].GetRandomMap();
            }

            i++;
        }

        // se terminaron los stages de mapas, lo mantengo en el ultimo
        if (!inRange) {
            i--;
            this.currentMap = allTheLevels.levels[i].GetRandomMap();
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
