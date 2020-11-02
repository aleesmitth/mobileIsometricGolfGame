using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Levels", menuName = "ScriptableObjects/Levels")]
public class Levels : ScriptableObject {
    public Level[] levels;

    [System.Serializable]
    public class Level {
        public int levelRangeMax;
        public GameObject[] normalMapsInThisRange;
        public GameObject[] lightMapsInThisRange;
        public GameObject[] darkMapsInThisRange;
        private int lastNormalMapBuffer = default(int);
        private int lastLightMapBuffer = default(int);
        private int lastDarkMapBuffer = default(int);
        public float shotsReward;
        [Tooltip("It defaults to 1 in light map.")]
        public float lightReward;
        [Tooltip("It defaults to 1 in dark map.")]
        public float darkReward;

        public GameObject GetRandomMap(PortalType portalType) {
            GameObject map;
            switch (portalType) {
                case PortalType.Dark: this.lightReward = 0; this.darkReward = 1;
                    map = SelectMap(darkMapsInThisRange, ref lastDarkMapBuffer);
                    break;
                case PortalType.Light: this.lightReward = 1; this.darkReward = 0;
                    map = SelectMap(lightMapsInThisRange, ref lastLightMapBuffer);
                    break;
                default:
                case PortalType.Normal: this.darkReward = 0; this.lightReward = 0;
                    map = SelectMap(normalMapsInThisRange, ref lastNormalMapBuffer);
                    break;
            }

            return map;
        }

        public GameObject SelectMap(GameObject[] listOfMaps, ref int numberOfLastMap) {
            //esto es para q no me ponga 2 veces seguidas el mismo mapa
            var nextMap = numberOfLastMap;
            while (nextMap == numberOfLastMap) {
                //elijo un mapa al azar dentro de este level
                nextMap = Random.Range(0, listOfMaps.Length);
            }

            numberOfLastMap = nextMap;
            return listOfMaps[nextMap];
        }
    }
}
