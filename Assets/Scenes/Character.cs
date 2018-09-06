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


    // ---- Graphics ----
    //UI 
    //Prefabs for each object you can build
    //Player prefab
    //Drop down for purchase list
    //Breed animals 
    //Provide milk from cow , sell for money
    //Animals heath or any stats
    //Store animal in shed 
    //Ablity to replace the cow 
    //Shop
    //popup and menus 
    //How to Play
    //Make more neater
    //Variables like health for animals and player cant go over 100 u need to validate this 
    //Choose a country - World map 
    //Country  Island choose = area + prefab



    // ---- Code ----
    // Fix switch camera and be able to go back to playerArea from playerView
    // User input and validation , Error/Crash control
    // Mobile
    //Save Object placement - SaveManager
    //Fishing Mini-Game
    //Better camera angle  - zoom and view object
    //Store animal in fencing / shed
    // ablity to move animals  - Barriers
    //More objects
    //Area Resources -wood , food , water
    //Country - look at graphic description above
    //Save AreaResource lists - need to convert to a  Json file or xml
    //Save object position
    //number you want to sell , arrows to go up and down in value
    //Sell Object - e.g. Building or Destory for a price to upgrade
    //Upgrades of building etc
    
    //RESet GUI WHEN A you open another menu etc
    //BUG WITH LEgAL position 

        

    //-------------Improvements after basic version-------
    //Graphics
    //cleaner code /Clean up folders
    //READ COMMENTS + Notes in phone
    //Arrows for number you want to sell
    //XP Generation and Ranking up system
    //When you reopen the purchase panel the last object you purchase is still displayed but when u click yes it does nothins - we need a reset description
    //AREA LEVELs increase cows etc 
    //UPDATE NAMES OF OBJECT TYPES AND MAKE MORE UNIQUE/Easy to understand - important to change within spawnobjects.name ++ ObjectType + onClickView


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



    //Player XP - different levels require a certain amount of XP
    public static int RequiredXP; // Required amount - used to set different amounts for higher Levels
    public static int currentXP; // This the Current Player XP Amount

    //Labels - Player View
    public Text NameText;
    public Text HealthText;
    public Text HungerText;
    public Text ThirstText;
    public Text RespectText;
    public Text HappinessText;
    public Text PlayerLevelText;
    public Text PlayerCoinText;

  

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
        //checks for updates on stats

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


        //disableSpawnScript();
        //MoveCamera();


    }

    public void setName()
    {

        PlayerPrefs.SetString("characterName" , characterName);

        NameText.text = CharacterCreator.characterName.ToString();

        PlayerPrefs.Save();
    }

    public void getName()
    {
        string characterName = PlayerPrefs.GetString("characterName");
    }

    public void setHealth()
    {
        PlayerPrefs.SetInt("Health" , Health);

    
        HealthText.text = ": " + CharacterCreator.currentHealth.ToString();

        PlayerPrefs.Save();
    }

    public void getHealth()
    {
        int Health = PlayerPrefs.GetInt("Health");
    }

    public void setHunger()
    {

        PlayerPrefs.SetInt("Hunger", Hunger);

        HungerText.text = ": " + CharacterCreator.currentHunger.ToString();

        PlayerPrefs.Save();
    }

    public void getHunger()
    {
        int Hunger = PlayerPrefs.GetInt("Hunger");
    }

    public void setThirst()
    {
        PlayerPrefs.SetInt("Thirst", Thirst);

        ThirstText.text = ": " + CharacterCreator.currentThirst.ToString();

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
        RespectText.text = ": " + CharacterCreator.currentRespect.ToString();

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
        HappinessText.text = ": " + CharacterCreator.currentHappiness.ToString();

        PlayerPrefs.Save();
    }

    public void getHappiness()
    {
        int Happiness = PlayerPrefs.GetInt("Happiness");
    }


    public void setPlayerLevel()
    {
        PlayerPrefs.SetInt("PlayerLevel", PlayerLevel);

        PlayerLevelText.text = "Level:" + CharacterCreator.currentPlayerLevel.ToString();

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
        

        PlayerCoinText.text = ": " + CharacterCreator.currentPlayerCoin.ToString();
        //Coin generation how to earn
        //check rule so like what you can build / purchase with the amount of coins your player has 

        PlayerPrefs.Save();

    }
    
    public void getPlayerCoin()
    {
        int PlayerCoin = PlayerPrefs.GetInt("PlayerCoin");
    }


  


   

   



    //public void disableSpawnScript()
    //{
        // SpawnObjects
        //Not workings
       // spawn.enabled = false; //disable the script when escape is pressed
   // }

   // public void MoveCamera()
   // {
   //    Vector3 cameraPosition = new Vector3(0f, 0f, 0f);
   //    sceneCam.transform.position = Vector3.Lerp(transform.position, cameraPosition, strength);
   // }
   
}

