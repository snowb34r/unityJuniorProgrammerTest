using System;
using System.IO;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public string PlayerName = "test";
    public string BestName = "test";
    public int HighScore = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else { Destroy(gameObject); }
        LoadTheData();
        Debug.Log("Score upon Awaken: " + HighScore);
        //InputField theodore = GameObject.Find("InputField").GetComponent<InputField>();
        //theodore.text = PlayerName;  new player names seemed to not save, so this didnt work
    }

    [System.Serializable]
    class SaveData
    {
        public string PlayerName;
        public int HighScore;
        public string BestName;
    }

    public void SaveTheData()
    {
        SaveData data = new SaveData();
        data.PlayerName = PlayerName;
        data.HighScore = HighScore;
        data.BestName = BestName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/ssvefile.json", json);
    }

    public void ReadStringInput(string s)
    {
        PlayerName = s;
    }

    public void LoadTheData()
    {
        string path = Application.persistentDataPath + "/ssvefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            PlayerName = data.PlayerName;
            HighScore = data.HighScore;
            BestName = data.BestName;
        }
    }
    public void ChangeScenes(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }

    public void Exit()
    {
        SaveTheData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}