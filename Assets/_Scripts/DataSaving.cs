using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;
using UnityEngine.UI;
using TMPro;
using System.Runtime.CompilerServices;

public class DataSaving : MonoBehaviour
{
    // Create a field for the save file.
    string saveFile;
    string theTime;
    string theDate;
    string userID;
    private StreamWriter sw;
    GameData gameData = new GameData();
    void Awake()
    {

       



    }
    public void GetUserID(){

        theDate = System.DateTime.Now.ToString("MM/dd/yyyy");
        getTime();
        Debug.Log(theDate + theTime);
        // Update the path once the persistent path exists.
        saveFile = Application.persistentDataPath + "/"+userID+"gamedata.csv";
        Debug.Log("File is saved at:" + saveFile);
    }
    public void UpdateStartingData(int uid)
    {
        if (!File.Exists(saveFile))
        {
            gameData.ParticipantID = uid;
            theDate = System.DateTime.Now.ToString("MM/dd/yyyy");

            saveFile = Application.persistentDataPath + "/" + uid + "gamedata.csv";
            Debug.Log("File is saved at:" + saveFile);
            sw = File.AppendText(saveFile);
           sw.Write(gameData.ParticipantID+";");
            gameData.Date = theDate;
            sw.Write(gameData.Date+";");
            sw.Close();
        }
        sw = File.AppendText(saveFile);
        //sw.Write("\n" + user_input.text);
        sw.Close();
    }



    public void readFile()
    {
        // Does the file exist?
        if (File.Exists(saveFile))
        {
            // Read the entire file and save its contents.
            string fileContents = File.ReadAllText(saveFile);

            // Deserialize the JSON data 
            //  into a pattern matching the GameData class.
            gameData = JsonUtility.FromJson<GameData>(fileContents);
        }
    }

    public void getTime()
    {
        theTime = System.DateTime.Now.ToString("hh:mm:ss");
    }
    public void OnStartSaveFile(string uid)
    {
        gameData.Date = theDate;
        string CurrentDate = JsonUtility.ToJson(gameData.Date);

        getTime();
        gameData.startingTime = theTime;
        string StartTime = JsonUtility.ToJson(gameData.startingTime);

        writeFile(StartTime);
        string ParticipantID = JsonUtility.ToJson(gameData.ParticipantID);
        writeFile(ParticipantID);

        
    }
    public void writeFile(string jsonString)
    {
        // Serialize the object into JSON and save string.
       // string jsonString = JsonUtility.ToJson(gameData);

        // Write JSON to file.
        File.WriteAllText(saveFile, jsonString);
    }
}

