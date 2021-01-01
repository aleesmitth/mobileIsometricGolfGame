using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    //el level manager se encarga de sacar el mapa de la pool adecuada dependiendo mi current streak
    
    public Transform playerBall;
    public Transform golfClub;
    public FloatValue currentStreak;
    public Levels allTheLevels;
    public Transform startingPosition;
    public GameObject currentMap;
    public FloatValue levelCoinReward;
    public FloatValue levelShotReward;
    public FloatValue levelLightReward;
    public FloatValue levelDarkReward;

    public void LoadLevel(PortalType portalType) {
        bool inRange = false;
        int i = 0;
        while (!inRange && i < allTheLevels.levels.Length) {
            if (allTheLevels.levels[i].levelRangeMax > currentStreak.value) {
                inRange = true;
                
                this.currentMap = allTheLevels.levels[i].GetRandomMap(portalType);
                
                //actualizo las rewards
                this.levelCoinReward.value = (currentStreak.value + 1) * allTheLevels.levels[i].levelRangeMax;
                this.levelShotReward.value = allTheLevels.levels[i].shotsReward;
                this.levelLightReward.value = allTheLevels.levels[i].lightReward;
                this.levelDarkReward.value = allTheLevels.levels[i].darkReward;
            }

            i++;
        }

        // se terminaron los stages de mapas, lo mantengo en el ultimo
        if (!inRange) {
            i--;
            this.currentMap = allTheLevels.levels[i].GetRandomMap(portalType);
            // estos 2 pueden cambiar solo por el portal que se elije, shots y coins dependen
            // del stage en el que esta,y si no hay mas stages se mantienen como aca.
            this.levelLightReward.value = allTheLevels.levels[i].lightReward;
            this.levelDarkReward.value = allTheLevels.levels[i].darkReward;
        }

        this.currentMap = Instantiate(this.currentMap);
        this.startingPosition = this.currentMap.transform.Find("StartingPosition");
        StartGame();
    }

    public void LoadStartingLevel() {
        if(currentMap != null)
            Destroy(currentMap);
        this.currentMap = allTheLevels.levels[0].GetRandomMap(PortalType.Normal);
        this.currentMap = Instantiate(this.currentMap);
        this.startingPosition = this.currentMap.transform.Find("StartingPosition");
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
