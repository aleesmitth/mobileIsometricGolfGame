using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;

public class FileManager : MonoBehaviour {
    public PlayerDataBuffer playerDataBuffer;
    private const string playerDataLocalPath = "/PlayerData.dat";
    private const string playerDataLocalPathBackup = "/PlayerDataBackup.dat";
    public FloatValue autoSaveInSeconds;
    
    private void Start() {
        Load();
        StartCoroutine(AutomaticBackupSave());
    }

    private IEnumerator AutomaticBackupSave() {
        yield return new WaitForSeconds(autoSaveInSeconds.value);
        Save(playerDataLocalPathBackup);
        StartCoroutine(AutomaticBackupSave());
    }

    private void Save(string localPath) {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(Application.persistentDataPath + localPath, FileMode.Create);
        playerDataBuffer.OnBeforeSerialize();
        var json = JsonUtility.ToJson(playerDataBuffer);
        binaryFormatter.Serialize(fileStream, json);
        fileStream.Close();
    }

    private void Load() {
        string validLocalPath;
        if (File.Exists(Application.persistentDataPath + playerDataLocalPath)) {
            validLocalPath = "/PlayerData.dat";
        }
        else if (File.Exists(Application.persistentDataPath + playerDataLocalPathBackup)) {
            validLocalPath = "/PlayerDataBackup.dat";
        }
        else return;
        
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(Application.persistentDataPath + validLocalPath, FileMode.Open);
        var json = binaryFormatter.Deserialize(fileStream) as string;
        JsonUtility.FromJsonOverwrite(json, playerDataBuffer);
        fileStream.Close();
        playerDataBuffer.OnAfterDeserialize();
    }

    private void OnApplicationPause(bool pauseStatus) {
        if(pauseStatus)
            Save(playerDataLocalPath);
    }
}
