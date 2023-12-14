using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public string playerName;
    public string newPlayerName;
    public int highScore;
    
    public static GameManager Instance;
    private void Awake(){
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadSavedData();

    }

    public void SetNewPlayerName(string name){
        newPlayerName = name;
    }
    public void SetHighScoreName(string name){
        playerName = name;
    }
    public void CurrentPlayerNewHighScore(){
        playerName = newPlayerName;
    }

    public string GetHighScoreText(){
        return "Highest Score " + highScore.ToString() + " By " + playerName + ".";
    }

    public void setScore(int score){
        highScore = score;
    }

    [System.Serializable]
    class SaveData {
        public string name;
        public int score;
    }
    
    public void SaveGameData(){
        SaveData saveData = new SaveData();
        saveData.name = playerName;
        saveData.score = highScore;

        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json" ,json);

    }

    public void LoadSavedData(){
        string path = Application.persistentDataPath +"/savefile.json";
        if (File.Exists(path)){
            string json = File.ReadAllText(path);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json); 

            playerName = saveData.name;
            highScore = saveData.score;
        }
    }
}

    
