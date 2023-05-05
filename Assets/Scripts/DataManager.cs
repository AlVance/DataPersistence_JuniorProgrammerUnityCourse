using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string currentPlayerName = "";
    public string playerName = "";
    public int playerPuntuation = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadPlayerData();
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int playerPuntuation;
    }

    public void SavePlayerData()
    {
        playerName = currentPlayerName;
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.playerPuntuation = playerPuntuation;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
            playerPuntuation = data.playerPuntuation;
        }
    }
}
