using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveData
{

    // Refer to http://www.nerdrage.co.uk/tutorials/saving-loading-unity3d-using-c/


    //Stats - Player
    public string name;
    public string gender;

    public int Health;
    public int Hunger;
    public int Thirst;
    public int Respect; // Respect of his tribe/area
    public int Happiness;
    public int PlayerLevel;
    public int PlayerCoin;

    //Stats - Area
    public string areaName;
    public int Population;
    public int areaLevel;
    public string areaType;
    public int AreaHappiness;

    //House - Estate Upgrade
    public string EstateName;
    public int EstateLevel;
    public int EstatePopulation;
    public string RoadName; //Street or road name // Need to decide
    


}

public class SaveGameManager : MonoBehaviour
{

    public FileStream saveFile;
    public SaveData saveData = new SaveData();
    
    //Scripts
    CharacterCreator characterCreator;
    UpgradeBuilds upgradeBuilds;
    PlayersArea playersArea;
    AreaResources areaResources;

    bool fileExists;


    public void Start()
    {
      //  characterCreator = GameObject.FindGameObjectWithTag("CharacterCreator").GetComponent<CharacterCreator>();
    }

    public void ReadPlayerData()
    {       
        //Player Stats - PlayerView
        saveData.name = CharacterCreator.characterName;
        saveData.gender = CharacterCreator.gender;
        saveData.Health = CharacterCreator.currentHealth;
        saveData.Hunger = CharacterCreator.currentHunger;
        saveData.Thirst = CharacterCreator.currentThirst;
        saveData.Respect = CharacterCreator.currentRespect;
        saveData.Happiness = CharacterCreator.currentHappiness;
        saveData.PlayerLevel = CharacterCreator.currentPlayerLevel;
        saveData.PlayerCoin = CharacterCreator.currentPlayerCoin;

        //PlayerArea
        saveData.areaName = CharacterCreator.areaName;
        saveData.areaLevel = CharacterCreator.areaLevel;
        saveData.Population = CharacterCreator.currentPopulation;
        saveData.areaType = CharacterCreator.areaType;
        saveData.AreaHappiness = CharacterCreator.areaHappiness;    
    


        //Upgrade builds
        saveData.EstateName = UpgradeBuilds.estateName;
        saveData.EstateLevel = UpgradeBuilds.estateLevel;
        saveData.EstatePopulation = UpgradeBuilds.estatePopulation;
        saveData.RoadName =  UpgradeBuilds.roadName;


        


    }


    public void SaveGame()
    {
        ReadPlayerData();
        BinaryFormatter bf = new BinaryFormatter();
        saveFile = File.Create(Application.persistentDataPath + "/save.dat"); // Location - C:/”UserName”/ AppData / LocalLow /”YourCompany”/
        bf.Serialize(saveFile, saveData);
        saveFile.Close();
        Debug.Log("Save Created :" + saveFile.Name);
    }


    public void LoadGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        saveFile = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Open);
        saveData = (SaveData)bf.Deserialize(saveFile);
        saveFile.Close();
        WritePlayerData();
        Debug.Log("Save Loaded :" + saveFile.Name);
    }

    public void WritePlayerData()
    {

        CharacterCreator.characterName = saveData.name;
        CharacterCreator.gender = saveData.gender;

        CharacterCreator.currentHealth = saveData.Health;
        CharacterCreator.currentHunger = saveData.Hunger;
        CharacterCreator.currentThirst = saveData.Thirst;
        CharacterCreator.currentRespect = saveData.Respect;
        CharacterCreator.currentHappiness = saveData.Happiness;
        CharacterCreator.currentPlayerLevel = saveData.PlayerLevel;
        CharacterCreator.currentPlayerCoin = saveData.PlayerCoin;

        CharacterCreator.areaName = saveData.areaName;
        CharacterCreator.areaLevel = saveData.areaLevel;
        CharacterCreator.currentPopulation = saveData.Population;
        CharacterCreator.areaType = saveData.areaType;
        CharacterCreator.areaHappiness = saveData.AreaHappiness;

        UpgradeBuilds.estateName = saveData.EstateName;
        UpgradeBuilds.estateLevel = saveData.EstateLevel;
        UpgradeBuilds.estatePopulation = saveData.EstatePopulation;
        UpgradeBuilds.roadName = saveData.RoadName;
    }

    public void CheckSave()
    {
        if (File.Exists(Application.persistentDataPath + "/save.dat"))
        {
            Debug.Log("Save File Found");
            fileExists = true;
        }
        else
        {
            fileExists = false;
            Debug.Log("No save file found");
        }
    }

}
