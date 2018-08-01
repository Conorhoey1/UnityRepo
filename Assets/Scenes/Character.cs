using UnityEngine;
using System.Collections;
using UnityEngine.UI;


[System.Serializable]

public class Character : MonoBehaviour
{
    //ToDo

   
    // Timers needs to be offline / app closed + save
    // variables cannot go over 100
    // disable script Method
    // player view to player area , make certain labels invisible 
    // Button for way back to player view


    // Player stats could we have them in every scene after playerview wil be less problems
    // Custom  player starts like a small bar at the top (small font for now?)

    // StatManager will be used for everything

        // Area player owns - start town 
        //Position camera 

     



    private static string characterName;
    private static string gender;

    //Stats
    public static int Health;
    public static int Hunger;
    public static int Thirst;
    public static int Respect; // Respect of his tribe/area
    public static int Happiness;
    public static int PlayerLevel;
    public static int PlayerCoin;

    //Area Variables
    public static string areaName; // need a input box when user unlocks an area
    public static int currentPopulation;
    public static int areaLevel;
    public static string areaType;
    public static int areaHappiness;

    //Player XP - different levels require a certain amount of XP
    public static int RequiredXP; // Required amount - used to set different amounts for higher Levels
    public static int currentXP; // This the Current Player XP Amount

    //Labels
    public Text NameText;
    public Text HealthText;
    public Text HungerText;
    public Text ThirstText;
    public Text RespectText;
    public Text HappinessText;
    public Text PlayerLevelText;
    public Text PlayerCoinText;

    //Labels
    public Text areaText;
    public Text areaLevelText;
    public Text populationText;
    public Text areaTypeText;


    //Scripts
    public CharacterCreator ch;
    public StatManager stats;
    // public SpawnObjects spawn;
    public PlayersArea pa;

    //Camera
    public GameObject sceneCam;

    public float strength = 0.5f; // how fast it moves
    


    void Start()
    {
        characterName = CharacterCreator.characterName;
        gender = CharacterCreator.gender;

       //Stats
       // Health = CharacterCreator.startingHealth = 100;
       // Hunger = CharacterCreator.startingHunger = 100;
       // Thirst = CharacterCreator.startingThirst = 100;
       // Respect = CharacterCreator.startingRespect = 100;
       // Happiness = CharacterCreator.startingHappiness = 100;
       // PlayerLevel = CharacterCreator.startingPlayerLevel = 1;
       // PlayerCoin = CharacterCreator.startingPlayerCoin = 1000; // TEST AMOUNT GIVEN

        //spawn = gameObject.GetComponent<SpawnObjects>();

        sceneCam = GameObject.Find("Main Camera");

    }



    void Update()
    {
       

        setName();
       //getName();

        setHealth();
       //getHealth();

        setHunger();
       //getHunger();

        setThirst();
       //getThirst();

        setRespect();
       //getRespect();

        setHappiness();
       //getHappiness();

        setPlayerLevel();
       //getPlayerLevel();

        setPlayerCoin();
        //getPlayerCoin();

        setAreaName();

        setAreaLevel();

        setAreaPopulation();

        setAreaType();

        disableSpawnScript();
        MoveCamera();


    }

    public void setName()
    {

        PlayerPrefs.SetString("characterName" , characterName);

        NameText.text = "Name: " + CharacterCreator.characterName.ToString();

        PlayerPrefs.Save();
    }

    public void getName()
    {
        string characterName = PlayerPrefs.GetString("characterName");
    }

    public void setHealth()
    {
        PlayerPrefs.SetInt("Health" , Health);

    
        HealthText.text = "Health: " + CharacterCreator.currentHealth.ToString();

        PlayerPrefs.Save();
    }

    public void getHealth()
    {
        int Health = PlayerPrefs.GetInt("Health");
    }

    public void setHunger()
    {

        PlayerPrefs.SetInt("Hunger", Hunger);

        HungerText.text = "Hunger: " + CharacterCreator.currentHunger.ToString();

        PlayerPrefs.Save();
    }

    public void getHunger()
    {
        int Hunger = PlayerPrefs.GetInt("Hunger");
    }

    public void setThirst()
    {
        PlayerPrefs.SetInt("Thirst", Thirst);

        ThirstText.text = "Thirst: " + CharacterCreator.currentThirst.ToString();

        PlayerPrefs.Save();
    }

    public void getThirst()
    {
        int Thirst = PlayerPrefs.GetInt("Thirst");
    }


    public void setRespect()
    {
        PlayerPrefs.SetInt("Respect", Respect);

        //startingRespect = PlayerPrefs.GetInt("Respect");
        RespectText.text = "Respect: " + CharacterCreator.currentRespect.ToString();

        PlayerPrefs.Save();
    }

    public void getRespect()
    {
        int Respect = PlayerPrefs.GetInt("Respect");
    }


    public void setHappiness()
    {
        PlayerPrefs.SetInt("Happiness", Happiness);

        // startingHappiness =  PlayerPrefs.GetInt("Happiness");
        HappinessText.text = "Happiness: " + CharacterCreator.currentHappiness.ToString();

        PlayerPrefs.Save();
    }

    public void getHappiness()
    {
        int Happiness = PlayerPrefs.GetInt("Happiness");
    }


    public void setPlayerLevel()
    {
        PlayerPrefs.SetInt("PlayerLevel", PlayerLevel);

        PlayerLevelText.text = "Player Level:" + CharacterCreator.currentPlayerLevel.ToString();

        //XP generation so that its based on winning challenges or something?
        //check rule so like what you can build / unlock at your players level

        PlayerPrefs.Save();

    }

    public void getPlayerLevel()
    {
        int PlayerLevel = PlayerPrefs.GetInt("PlayerLevel");
    }


    public void setPlayerCoin()
    {
        PlayerPrefs.SetInt("PlayerCoin", PlayerCoin);
        

        PlayerCoinText.text = "Coins: " + CharacterCreator.currentPlayerCoin.ToString();
        //Coin generation how to earn
        //check rule so like what you can build / purchase with the amount of coins your player has 

        PlayerPrefs.Save();

    }
    
    public void getPlayerCoin()
    {
        int PlayerCoin = PlayerPrefs.GetInt("PlayerCoin");
    }


    public void setAreaPopulation()
    {
        PlayerPrefs.SetInt("Population", currentPopulation);

        populationText.text = "Population:" + CharacterCreator.currentPopulation.ToString();

        //XP generation so that its based on winning challenges or something?
        //check rule so like what you can build / unlock at your players level

        PlayerPrefs.Save();

    }
    public void getAreaPopulation()
    {
       int currentPopulation = PlayerPrefs.GetInt("Population");
    }

    public void setAreaName()
    {
        PlayerPrefs.SetString("areaName", areaName);

        areaText.text = "Area Name: " + CharacterCreator.areaName.ToString(); //should we change this name , Text Name

        PlayerPrefs.Save();
    }

    public void getAreaName()
    {
        string areaName = PlayerPrefs.GetString("AreaName");
    }


    public void setAreaLevel()
    {
       PlayerPrefs.SetInt("AreaLevel", areaLevel);

       areaLevelText.text = "Area Level: " + CharacterCreator.areaLevel.ToString();
        PlayerPrefs.Save();
    }

   public void getAreaLevel()
   {
        int areaLevel = PlayerPrefs.GetInt("AreaLevel");
   }

    public void setAreaType()
    {
       PlayerPrefs.SetString("areaType", CharacterCreator.areaType);

       areaTypeText.text = "Area Type: " + CharacterCreator.areaType.ToString();

       PlayerPrefs.Save();
    }

    public void getAreaType()
    {
        string areaType = PlayerPrefs.GetString("areaType");
    }

    public void setAreaHappiness()
    {
        PlayerPrefs.SetInt("AreaHappiness", areaHappiness);

        areaLevelText.text = "Area Happiness: " + CharacterCreator.areaHappiness.ToString();
        PlayerPrefs.Save();
    }

    public void getAreaHappiness()
    {
        int areaHappiness = PlayerPrefs.GetInt("AreaHappiness");
    }


    public void onSubmit()
    {

        //THIS IS A TEST METHOD 
        Health = CharacterCreator.startingHealth - 1;
        Debug.Log(Health);

        Hunger = CharacterCreator.startingHunger - 1;
        Debug.Log(Hunger);

        Thirst = CharacterCreator.startingThirst - 1;
        Debug.Log(Thirst);

        Respect = CharacterCreator.startingRespect - 1;
        Debug.Log(Respect);

        Happiness = CharacterCreator.startingHappiness - 1;
        Debug.Log(Happiness);
        
        setHealth();
        setHealth();
        setHunger();
        setThirst();
        setRespect(); // COuld be the problem maybe only in start
        setHappiness();

        stats.increasePlayerLevel();
        stats.increasePlayerCoin();


    }

   



    public void disableSpawnScript()
    {
        // SpawnObjects
        //Not workings
       // spawn.enabled = false; //disable the script when escape is pressed
    }

    public void MoveCamera()
    {
       Vector3 cameraPosition = new Vector3(0f, 0f, 0f);
       sceneCam.transform.position = Vector3.Lerp(transform.position, cameraPosition, strength);
    }
   
}

