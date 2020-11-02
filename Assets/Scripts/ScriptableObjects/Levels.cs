using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Levels", menuName = "ScriptableObjects/Levels")]
public class Levels : ScriptableObject {
    public Level[] levels;

    [System.Serializable]
    public class Level {
        public int levelRangeMax;
        public GameObject[] mapsInThisRange;
        private int lastMapBuffer = default(int);
        public float shotsReward;

        public GameObject GetRandomMap() {
            var nextMap = this.lastMapBuffer;
            while (nextMap == this.lastMapBuffer) {
                nextMap = Random.Range(0, mapsInThisRange.Length);
            }

            this.lastMapBuffer = nextMap;
            return mapsInThisRange[nextMap];
        }
    }
}
