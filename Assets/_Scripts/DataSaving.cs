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


        saveFile = Application.persistentDataPath + "/Ver2gamedata.csv";
        Debug.Log("File is saved at:" + saveFile);

        if (!File.Exists(saveFile))
        {

            sw = File.AppendText(saveFile);

            sw.WriteLine("ID,"+ "Date","Object,"+ "Time Grab,"+ "Time Released,"+ "First Purchase,"+ "Second Purchase,");
            sw.Close();

        }

        }
    public void GetUserID(){

        theDate = System.DateTime.Now.ToString("MM/dd/yyyy");
        getTime();
        Debug.Log(theDate + theTime);
        // Update the path once the persistent path exists.
        saveFile = Application.persistentDataPath + "/"+userID+"22Septgamedata.csv";
        Debug.Log("File is saved at:" + saveFile);
    }
    public void UpdateStartingData(int uid)
    {
        //store the ID and date first and write
        gameData.isFirstAnswer = false;
        gameData.isLastAnswer = false;
            gameData.ParticipantID = uid;
            gameData.Date = System.DateTime.Now.ToString("MM/dd/yyyy");

           

      /*
        sw = File.AppendText(saveFile);


        sw.WriteLine("ID " + gameData.ParticipantID + ";");
        gameData.Date = theDate;
        sw.WriteLine(gameData.Date + ";");
        //sw.Write("\n" + user_input.text);
        sw.Close();*/
    }

    public void DeletedObject(string ObjectName)
    {
        sw = File.AppendText(saveFile);
        sw.WriteLine("Deleted "+ObjectName + ";");
        getTime();

        sw.WriteLine(theTime + ";");
        sw.Close();

    }

    public void OnCerealGrabbed(string ObjectName)
    {
        sw = File.AppendText(saveFile);
        gameData.ObjectName = ObjectName;
        getTime();
        sw.Write(gameData.ParticipantID + "," + gameData.Date + "," + gameData.ObjectName + "," + theTime + ",");
   
     
        sw.Close();
    }

    public void OnCerealLetGo(string ObjectName) 
    {

        sw = File.AppendText(saveFile);
       // sw.WriteLine(ObjectName + ",");
        getTime();

        sw.Write(theTime + ",");
        //Do an IEnumerator to see if cereal was checked out or not
        sw.Close();
        StartCoroutine(CountdownForCashier());

    }
    //coroutine to see if cereal is first answer or not
    IEnumerator CountdownForCashier()
    {
        yield return new WaitForSeconds(1.5f);
        sw = File.AppendText(saveFile);
        sw.Write(gameData.isFirstAnswer.ToString()+","+gameData.isLastAnswer.ToString()+ "\n");

        sw.Close();
        gameData.isFirstAnswer = false;
        gameData.isLastAnswer = false;
    }

    public void ToggleFirstAnswer(bool FA)
    {
        gameData.isFirstAnswer = FA;
        
    }
    public void ToggleLastAnswer(bool la)
    {
        gameData.isLastAnswer = la;
    }

    public void UpdateFinalData(string FirstAnswer, string SecondAnswer)
    {
        sw = File.AppendText(saveFile);
        sw.WriteLine("Final answer: ");

        sw.WriteLine(FirstAnswer + ";");
        sw.WriteLine(SecondAnswer + ";"); 
        getTime();
        gameData.checkOutTime = theTime;
        sw.WriteLine(gameData.checkOutTime + ";");
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

