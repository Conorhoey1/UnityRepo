using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;


[System.Serializable]

public class PlayersArea : MonoBehaviour
{
    //Scene
    //Map 

    // TImers run in all scenes 

    //Todo
    //PlayerArea to PlayerView- still has a bug


    //This script will be used to generate an area for the player in which they run/own
    //A town will have stats such population etc
    //Rules
    //levels 
    //Roles  , government , building 




    //Scripts
    public CharacterCreator characterCreator; // Creator Script
    public Character ch; // Character Script
    public SpawnObjects spawnObjects;
    public StatManager statsManager;
    public UpgradeBuilds upgradeBuild;
    public PlaceBuilding placeBuilding;
    public AreaResources areaResources;



    //-----Player Area UI AND VARIABLES----

    //Labels - Player Area 
    public Text areaText;
    public Text areaLevelText;
    public Text populationText;
    public Text areaTypeText;

    //Area Variables
    public static string areaName; // need a input box when user unlocks an area
    public static int currentPopulation;
    public static int areaLevel;
    public static string areaType;
    public static int areaHappiness;
    public static int areaExpenses;
    public static int areaIncome;




    //------Area Resources-------Food - UI
    public Button CollectMilkBtn; //Collect Cow Milk Btn

    public GameObject AreaStoragePanel; // Panel
    public Text CowCounterText;//Used for storage list
    public Text MilkCounterText; //Used for storage list
    public InputField InputSell;//Input
    public Button SellBtn;
    public Text TotalSellingAmount;

    public Button CloseStorageBtn;//close 
    public Button GoToStorageBtn;//open








    //Area Resources - Water
    public string Watertype { get; set; } // well?? , river>?
    public int WaterLevel { get; set; }
    public int WaterAmount { get; set; }

    //------------Area Resources - Food------------------
    public string Foodtype { get; set; } // well?? , river>?
    public int FoodLevel { get; set; }
    public int FoodAmount { get; set; }

    //Purchase
    public static bool valid = false;
    public static bool validInstantiate = false;


    public int PriceOfAsset { get; set; }

    //House - Variables
    public int houseCounter { get; set; }

    //Water Well - Variables
    public int waterWellCounter { get; set; }

    //Crops - Variables
    public int cropsCounter { get; set; }

    //Shop - Variables
    public int shopCounter { get; set; }

    //Player Stats
    public static int PlayerCoin;

    //Building Prefabs/GameObjects
    public GameObject hut;

    //Water Prefabs/GameObjects
    public GameObject WaterWell;

    //Crop Prefabs/GameObjects
    public GameObject CropsPrefab;


    //Crops Prefabs/GameObjects
    public GameObject ShopPrefab;

    //-------------Animal - Cow ------------------

    public GameObject CowPrefab;//Animal

    public static int TotalMilkStorage; //Used for the storage list
    public static int numberofCows = 0; // Used for the storage list // Counter
    public static bool d;

    //--------------------------------------------

    //Moving camera position  - PlayerArea to PlayerView
    public static int movement;
    public static bool triggerPlayerView;
    public static bool triggerPlayerArea;

    public GameObject GoToPlayerViewBtn;
    public GameObject GoToPlayerAreaBtn;

    //Cameras
    public static int cameraPosition;
    public Camera SpawnObjects;
    public Camera PlayerViewCamera;


    //Purchase UI 
    public Button PurchaseBtn;
    public GameObject PurchaseList; //Panel
    public Text ObjectTypeText;
    public Text DescriptionText;
    public Text CostText;
    public Button YesPurchaseBtn;
    public Button NoPurchaseBtn;
    public bool BtnClicked;

    //Click Object - View Object
    public GameObject ObjectViewPanel;
    public Text ObjectnameText;
    public Text SellAmountText;
    public Button SellObjectBtn;
    

    //Selling Variables - Resources
    public static int numberOfCowsSelling;
    public static int numberOfMilkSelling;




    //Variables for Object Effects
    public string ObjectType { get; set; } //Name - identifier
    public string Text { get; set; } // Used for DescriptionText Label
    public int Cost { get; set; } //Used for cost label
    public int EffectOnStatHealth { get; set; }
    public int EffectOnStatHunger { get; set; }
    public int EffectOnStatThirst { get; set; }
    public int EffectOnStatRespect { get; set; }
    public int EffectOnStatAreaHappiness { get; set; }
    public int EffectOnStatPopulation { get; set; }
    public int EffectOnStatCoin { get; set; }
    public int coinTransactionAmount { get; set; } //This will be used when selling an object 



    //Variables for Object Effects
    // public string WaterObjectType { get; set; } //Name - identifier
    //public string WaterText { get; set; } // Used for DescriptionText Label


    //List for Purchase Objects
    List<PlayersArea> purchaseWaterObjects = new List<PlayersArea>();
    List<PlayersArea> purchaseBuildingObjects = new List<PlayersArea>();
    List<PlayersArea> purchaseCropsObjects = new List<PlayersArea>();
    List<PlayersArea> purchaseAnimalObjects = new List<PlayersArea>();
    List<PlayersArea> purchaseShopObjects = new List<PlayersArea>();


    int index;
    int pos;
    bool validSell = false;

    // Use this for initialization
    void Start()
    {

        //spawnObjects = GameObject.FindObjectOfType<SpawnObjects>();
        possiblePurchases();
    }

    // Update is called once per frame
    void Update()
    {

        //statsManager.CheckLevelUp();
        PlayerViewCamera.gameObject.SetActive(false);

        setAreaName();

        setAreaLevel();

        setAreaPopulation();

        setAreaType();

        setResourceCow();

        setResourceMilk();

        getInputSellAmountsValue();

        setAreaExpenses(); // NEEDS STILL TO BE SAVED!!!
    }


    //------------AREA VARIABLES SET AND GET ---------

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


    public void setResourceCow()
    {
        PlayerPrefs.SetInt("AreaCow", numberofCows);

        CowCounterText.text = "Area Cow " + numberofCows.ToString();

    }

    public void getResourceCow()
    {
        int numberofCows = PlayerPrefs.GetInt("AreaCow");
    }

    public void setResourceMilk()
    {
        PlayerPrefs.SetInt("AreaMilk", TotalMilkStorage);

        MilkCounterText.text = "Area Milk " + TotalMilkStorage.ToString();

    }

    public void getResourceMilk()
    {
        int TotalMilkStorage = PlayerPrefs.GetInt("AreaMilk");
    }

    public void setAreaExpenses()
    {
        PlayerPrefs.SetInt("AreaExpenses", areaExpenses);

        // MilkCounterText.text = "Area Milk " + TotalMilkStorage.ToString();

    }

    public void getAreaExpenses()
    {
        int areaExpenses = PlayerPrefs.GetInt("AreaExpenses");
    }


    public void setAreaIncome()
    {
        PlayerPrefs.SetInt("AreaIncome", areaIncome);

        // MilkCounterText.text = "Area Milk " + TotalMilkStorage.ToString();

    }

    public void getAreaIncome()
    {
        int areaIncome = PlayerPrefs.GetInt("AreaIncome");
    }



    //----------------------------------------PURCHASE OBJECTS--------------------------------------------

    //This will be used to instatiate PurchaseList when purchase button is clicked
    //List of buttons will appear
    public void menuPurchaseList()
    {
        PurchaseList.gameObject.SetActive(true);

        PurchaseBtn.gameObject.SetActive(false);
    }

    //This will retieve the object type and text and display below
    public void onClickViewWellPurchase() //Water Well View
    {
        PurchaseBtn.gameObject.SetActive(false);

        ObjectTypeText.text = purchaseWaterObjects[0].ObjectType.ToString(); // Name of the object

        DescriptionText.text = purchaseWaterObjects[0].Text.ToString(); //Description

        CostText.text = purchaseWaterObjects[0].Cost.ToString(); //Cost

        //Confirm purchase which will be a Tick button and No for a X button

        YesPurchaseBtn.gameObject.SetActive(true);

        YesPurchaseBtn.onClick.AddListener(resetGUI); //Remove UI components method

        YesPurchaseBtn.onClick.AddListener(validateWaterPurchase); //Spawn Prefab Method

        NoPurchaseBtn.gameObject.SetActive(true);

        NoPurchaseBtn.onClick.AddListener(resetGUI); //Remove UI components method

    }

    //This will retieve the object type and text and display below
    public void onClickViewHutPurchase() //Hut View
    {
        PurchaseBtn.gameObject.SetActive(false);

        ObjectTypeText.text = purchaseBuildingObjects[0].ObjectType.ToString(); // Name of the object

        DescriptionText.text = purchaseBuildingObjects[0].Text.ToString(); //Description

        CostText.text = purchaseBuildingObjects[0].Cost.ToString(); //Cost 

        //Confirm purchase which will be a Tick button and No for a X button

        YesPurchaseBtn.gameObject.SetActive(true);

        YesPurchaseBtn.onClick.AddListener(resetGUI); //Remove UI components method

        YesPurchaseBtn.onClick.AddListener(validateHousePurchase); //Spawn Prefab Method

        NoPurchaseBtn.gameObject.SetActive(true);

        NoPurchaseBtn.onClick.AddListener(resetGUI); //Remove UI components method

    }


    //This will retieve the object type and text and display below
    public void onClickViewCropsPurchase() //Crops View
    {
        PurchaseBtn.gameObject.SetActive(false);

        ObjectTypeText.text = purchaseCropsObjects[0].ObjectType.ToString(); // Name of the object

        DescriptionText.text = purchaseCropsObjects[0].Text.ToString(); //Description

        CostText.text = purchaseCropsObjects[0].Cost.ToString(); //Cost of Purchase

        //Confirm purchase which will be a Tick button and No for a X button

        YesPurchaseBtn.gameObject.SetActive(true);

        YesPurchaseBtn.onClick.AddListener(resetGUI); //Remove UI components method

        YesPurchaseBtn.onClick.AddListener(validateCropsPurchase); //Spawn Prefab Method

        NoPurchaseBtn.gameObject.SetActive(true);

        NoPurchaseBtn.onClick.AddListener(resetGUI); //Remove UI components method

    }

    //This will retieve the object type and text and display below
    public void onClickViewCowPurchase() //Crops View
    {
        PurchaseBtn.gameObject.SetActive(false);

        ObjectTypeText.text = purchaseAnimalObjects[0].ObjectType.ToString(); // Name of the object

        DescriptionText.text = purchaseAnimalObjects[0].Text.ToString(); //Description

        CostText.text = purchaseAnimalObjects[0].Cost.ToString();  // Cost

        //Confirm purchase which will be a Tick button and No for a X button

        YesPurchaseBtn.gameObject.SetActive(true);
       
        YesPurchaseBtn.onClick.AddListener(resetGUI); //Remove UI components method

        YesPurchaseBtn.onClick.AddListener(validateCowPurchase); //Spawn Prefab Method

        NoPurchaseBtn.gameObject.SetActive(true);

        NoPurchaseBtn.onClick.AddListener(resetGUI); //Remove UI components method

    }

    //This will retieve the object type and text and display below
    public void onClickViewShopPurchase() //Water Well View
    {
        PurchaseBtn.gameObject.SetActive(false);

        ObjectTypeText.text = purchaseShopObjects[0].ObjectType.ToString(); // Name of the object

        DescriptionText.text = purchaseShopObjects[0].Text.ToString(); //Description

        CostText.text = purchaseShopObjects[0].Cost.ToString();

        //Confirm purchase which will be a Tick button and No for a X button

        YesPurchaseBtn.gameObject.SetActive(true);

        YesPurchaseBtn.onClick.AddListener(resetGUI); //Remove UI components method

        YesPurchaseBtn.onClick.AddListener(validateShopPurchase); //Spawn Prefab Method

        NoPurchaseBtn.gameObject.SetActive(true);

        NoPurchaseBtn.onClick.AddListener(resetGUI); //Remove UI components method

    }

    public void onClickViewObject()
    {

       //View Object UI 
        ObjectViewPanel.gameObject.SetActive(true);
        ObjectnameText.gameObject.SetActive(true);
        SellAmountText.gameObject.SetActive(true);
        SellObjectBtn.gameObject.SetActive(true);

        ObjectnameText.text = spawnObjects.objectHit.ToString();

        //   bool buildingList;

        //  int position = Array.IndexOf(purchaseBuildingObjects,spawnObjects.objectHit );

        //  if (spawnObjects.objectHit.Contains("Hut"))
        //    {
        //         SellAmountText.text = purchaseBuildingObjects[0].Cost.ToString();
        //              // SellAmountText.text = purchaseCropsObjects[i].EffectOnStatCoin.ToString()
        //  }


        //  for loop the arrays?
        // if(... || ...)


        retrieveObjectDetails(); 

     


     


        SellObjectBtn.onClick.AddListener(SellTransactionCoin);
    }

        

    //OnClick of the object this will set text and get the objects data
    
    public void retrieveObjectDetails()
    {
      
        coinTransactionAmount = 0;

        for (int i = 0; i < purchaseBuildingObjects.Count; i++)
        {
            if (spawnObjects.objectHit == purchaseBuildingObjects[i].ObjectType)
            {
                i = pos;
                SellAmountText.text = purchaseBuildingObjects[pos].Cost.ToString();

                coinTransactionAmount = purchaseBuildingObjects[pos].Cost;

          

                validSell = true;


            }
        }

        for (int i = 0; i < purchaseCropsObjects.Count; i++)
        {
            if (spawnObjects.objectHit == purchaseCropsObjects[i].ObjectType)
            {
                i = pos;
                SellAmountText.text = purchaseCropsObjects[pos].Cost.ToString();

                coinTransactionAmount = purchaseCropsObjects[pos].Cost;

                

                validSell = true;

            }
        }

        for (int i = 0; i < purchaseAnimalObjects.Count; i++)
        {
            if (spawnObjects.objectHit == purchaseAnimalObjects[i].ObjectType)
            {
                i = pos;

                SellAmountText.text = purchaseAnimalObjects[pos].Cost.ToString();

                coinTransactionAmount = purchaseAnimalObjects[pos].Cost;

               
                validSell = true;
            }
        }

        for (int i = 0; i < purchaseShopObjects.Count; i++)
        {
            if (spawnObjects.objectHit == purchaseShopObjects[i].ObjectType)
            {
                i = pos;

                SellAmountText.text = purchaseShopObjects[pos].Cost.ToString();

                coinTransactionAmount  = purchaseShopObjects[pos].Cost;

          
                validSell = true;

            }
        }

        for (int i = 0; i < purchaseWaterObjects.Count; i++)
        {
            if (spawnObjects.objectHit == purchaseWaterObjects[i].ObjectType)
            {
                i = pos;
                SellAmountText.text = purchaseWaterObjects[pos].Cost.ToString();
                Debug.Log(coinTransactionAmount);


                coinTransactionAmount = purchaseWaterObjects[pos].Cost; // This will set the amount that the user receives and is used in the sell transaction

                
                validSell = true;

            }
        }

    }

    //OnClick Sell btn will run this method
    public void SellTransactionCoin()
    {

        if(validSell == true)
        {
            CharacterCreator.currentPlayerCoin = CharacterCreator.currentPlayerCoin + coinTransactionAmount; 
            ch.setPlayerCoin();
            validSell = false;
            resetGUI();

            spawnObjects.removeObject = true;

        }
        else if(validSell == false)
        {
            //Messagebox needed
            Debug.Log("Unable to sell , please select a object to sell");

            validSell = false;
            resetGUI();
        }

 
        
    }
        




    //---------------------------------------------------------------------------------------------------------------------------------
    //This method will be used to close purchase list depending on the button they press as this could be used for a top right X button
    public void resetGUI()
    {
        BtnClicked = true;

        PurchaseList.gameObject.SetActive(false);

        PurchaseBtn.gameObject.SetActive(true);

        YesPurchaseBtn.onClick.RemoveAllListeners();

        NoPurchaseBtn.onClick.RemoveAllListeners();

        //ViewObject UI
        ObjectViewPanel.gameObject.SetActive(false);
        ObjectnameText.gameObject.SetActive(false);
        SellAmountText.gameObject.SetActive(false);
        
        SellObjectBtn.gameObject.SetActive(false);

        validSell = false; // Reset Sell btn / Ability to sell
    }


    //----------------------------------------------------------------------------------------------------------------------------------



    public void possiblePurchases()
    {

        //This will be used to set all objects
        //this is be link to a button so like they can choose from the list
        //Each object will have set values store in array list

        //Possible Objects to purchase

        //WaterWell
        //Upgrades for house
        //Stores
        //Church
        //Road
        //Crops 
        //Animals 
        //Sheds
        //fences
        //Plants
        //Technology 
        //Army
        //Weapons

        //------------Possible Purchases--------


        //------Animal List------
        purchaseAnimalObjects.Add(new PlayersArea { ObjectType = "Cow", Text = "This is a cow -" , Cost = EffectOnStatCoin = 50, EffectOnStatAreaHappiness = 5 });


        //---Water Object List---
        purchaseWaterObjects.Add(new PlayersArea { ObjectType = "Water Well", Text = "This is a water well that can be used to ....... " , Cost = EffectOnStatCoin = 100, EffectOnStatAreaHappiness = 5 });



        //------Plants / Plant Crops List------
        purchaseCropsObjects.Add(new PlayersArea { ObjectType = "Crops", Text = " .. , , effects = ..." , Cost = EffectOnStatCoin = 10, EffectOnStatAreaHappiness = 5 });


        //-----------------------------Building List-----------------------

        //Build Hut
        purchaseBuildingObjects.Add(new PlayersArea { ObjectType = "Hut", Text = " Hut ... - effects .... ", Cost =  EffectOnStatCoin = 25, EffectOnStatAreaHappiness = 5 });
        
        //General Store
        purchaseShopObjects.Add(new PlayersArea { ObjectType = "General Store", Text = " .. , Regalar income however there is a cost as you must pay your employees" , Cost =  150 , EffectOnStatCoin = 150, EffectOnStatAreaHappiness = 5 });

    }




    //-----------------------------Methods to call for Objects------------------------------------------

    public void validateHousePurchase()
    {
        //--------TODO-------
        //Area levels will have different rights to build and more to unlock
        //UPgrades
        //e.g area level 1 until 2 = 5 wells 
        //ADD MORE 

        //bool valid = false;


        Debug.Log("House selected");
        if(houseCounter >= 0 && houseCounter <=3)
        {
            buildHouse();
        }

        else if (houseCounter >= 4 && CharacterCreator.currentPlayerLevel >=2)
        {

            Debug.Log("Granted access");

            buildHouse();
  
        }
        else
        {
            //Messagebox
            Debug.Log("Unable to purchase at this player Level");
        }

    }


        public void buildHouse() //Change name to hut or something more generic
        {
        //This is called when user wants to build house
        // Must have 50 coins
        // call method spawnObjects which creates prefab
        //Within spawnObjects it will be active all the time so set it to false;
        // Only allow 1 object to be placed.

        //Set amount of house
        //One house allows 3 people?


        bool valid = false;
        Debug.Log("House selected");


            //Would you like to upgrade these houses to an estate for 1300 Coins

            //Benefits - Community spirt and happiness increase
            //  Debug.Log("Would you like to upgrade these houses to an estate for 1300 Coins");

            //User input but we want it to be a button yes or no buttons
            //  if(userInput == "Yes") 
            //  {
            //Yes
            //   CharacterCreator.currentPlayerCoin = CharacterCreator.currentPlayerCoin - 1300;

            //Upgrade House build
            //   upgradeBuild.UpgradeHouseBuild();
            // }

            //   else if(userInput == "No")
            // {
            //No
            //     Debug.Log("Purchase cancelled");
            //  }

       

            //Purchase + funds Check
            if (CharacterCreator.currentPlayerCoin >= 10)
            {
                CharacterCreator.currentPlayerCoin = CharacterCreator.currentPlayerCoin - purchaseBuildingObjects[0].EffectOnStatCoin;
                ch.setPlayerCoin();

                valid = true;
                
                Debug.Log("House purchase");
            }
            else
            {
                Debug.Log("Not enough funds - 10 coins are needed");

                valid = false;
            }


            //Timer of how often water gens
        

        if (valid == true) // IF the player has enough funds  -  stats and update stats - Instantiate prefab
        {

            Debug.Log("creating House");



            //Storage - Player Storage/SAVE

            // Population check ?? add people into it?

            statsManager.PopulationCheck();

            //Update AreaType Label - GUI
            setAreaType();

            CharacterCreator.currentPopulation = CharacterCreator.currentPopulation + 1;
            Debug.Log(CharacterCreator.currentPopulation);

            //Update Population Label - GUI
            setAreaPopulation();

            //XP
            CharacterCreator.currentXP = CharacterCreator.currentXP + 100;
            statsManager.PlayerLevelCheck();

            //Increase Area Level
            statsManager.increaseAreaLevel();

            validInstantiate = true; // Allows SpawnObject Script to call method which spawns prefab


            //Create House / Prefab on screen
            spawnObjects.SetItem(hut);
            spawnObjects.name = "Hut";
           

            houseCounter++;


        }

        else // prevents prefab instantiate
        {
            Debug.Log("Unable to spawn due player not having funds");
        }

    }






    //-------------------Water-------------------

    //Game Info: 

    //Variables    

    // Double startingAmount - Starting water amount
    // Int WaterLevel - This will deterine which upgrade they can purchase so that you can just go to automation or something advanced

    //Upgrade Array - Stores Strings so e.g. 5 possible upgrades well , river, purifer??
    //List?? well , cost , amount-  per array 

    // If statement deteremine upgraded water amount and Cost

    //Upgraded Amount


    // button to purchase well 
    // check population
    // if pop = 1 then well is good (Enough to build)
    // check coin - reduce coin(purchase)
    // Once you active water well,  WellwaterGen == true 
    //timer



    public void validateWaterPurchase()
    {
        //--------TODO-------
        //Area levels will have different rights to build and more to unlock
        //UPgrades
        //e.g area level 1 until 2 = 5 wells 
        //ADD MORE 

        //bool valid = false;


        Debug.Log("Water selected");
        if (waterWellCounter >= 0 && waterWellCounter <= 3)
        {
            CreateWaterWell(); 
        }

        else if (houseCounter >= 4 && CharacterCreator.currentPlayerLevel >= 2)
        {

            Debug.Log("Granted access");

            CreateWaterWell();

        }
        else
        {
            //Messagebox
            Debug.Log("Unable to purchase at this player Level");
        }

    }



    public void CreateWaterWell()
    {
        //--------TODO-------
        //Area levels will have different rights to build and more to unlock
        //e.g area level 1 until 2 = 5 wells 
        //WHAT HAPPENS IF THERE ARE 2 WELLS?

        bool valid = false;


            //Purchase + funds Check
            if (CharacterCreator.currentPlayerCoin >= 10)
            {
                CharacterCreator.currentPlayerCoin = CharacterCreator.currentPlayerCoin - purchaseWaterObjects[0].Cost;



                ch.setPlayerCoin();

                valid = true;
                Debug.Log("Water Well purchase");
            }
            else
            {
                Debug.Log("Not enough funds - 10 coins are needed");
            }

            //Purchase confirmation + Creation 

            //Creation of well (Prefab graphic)
            //Timer of how often water gens
        

        if (valid == true)
        {

            Debug.Log("creating well");
            // Create well on screen --TODO!!!


            //Storage - Player Storage/SAVE

            // add Timer + add water


            Debug.Log("WLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL");

            statsManager.increaseThirstMethod();
            statsManager.PlayerLevelCheck();



            validInstantiate = true; // Allows SpawnObject Script to call method which spawns prefab


            //Create waterWell / Prefab on screen
            spawnObjects.SetItemWaterWell(WaterWell);

            spawnObjects.name = "Water Well";
        }

        else // prevents prefab instantiate
        {
            Debug.Log("Unable to spawn due player not having funds");
        }



    }



    public void checkWaterStatus()
    {
        //Check population

        // if (Population == 1) // Check if population is enough to build
        //   {
        //   Debug.Log("Population is good");

        //  if(coin == 0) // Check coin balance
        // {
        // Debug.Log("Current Balance " + coin);

        //  coin = coin - water1.PriceOfAsset; //change amount? // Reduce amount

        //  character.setPlayerCoin();

        //  Debug.Log("New balance is " + coin);

        //   Update method ch 

        //  }
        // }

    }

    public void waterGeneration()
    {
        /*if(waterGen == true)
        {
            
        }
        */
    }

    public void waterDecrease()
    {

    }




    //------------ Food --------------------------

    //Game Info: 

    //Variables    

    // Double startingAmount - Starting food amount
    // Food-Level - This will deterine which upgrade they can purchase so that you can just go to automation or something advanced

    // Upgrade Array - Stores Strings so e.g. 5 possible upgrades crops , animals etc?
    // If statement deteremine upgraded food amount and Cost

    public void foodGeneration()
    {

    }

    public void validateCropsPurchase()
    {
        //--------TODO-------
        //Area levels will have different rights to build and more to unlock
        //UPgrades
        //e.g area level 1 until 2 = 5 wells 
        //ADD MORE 

        //bool valid = false;


        Debug.Log("Crops selected");
        if (cropsCounter >= 0 && cropsCounter <= 3)
        {
            CreateCrops();
        }

        else if (cropsCounter >= 4 && CharacterCreator.currentPlayerLevel >= 2)
        {

            Debug.Log("Granted access");
            CreateCrops();
        }
        else
        {
            //Messagebox
            Debug.Log("Unable to purchase at this player Level");
        }

    }






    public void CreateCrops()
    {
        //--------TODO-------
        //Area levels will have different rights to build and more to unlock
        //e.g area level 1 until 2 = 5 wells 

        // Different upgrades
        // 5 crops plots = a field? but u have to pay for the upgrade. 
        bool valid = false;


        //Purchase + funds Check
        if (CharacterCreator.currentPlayerCoin >= 10)
        {
            CharacterCreator.currentPlayerCoin = CharacterCreator.currentPlayerCoin - purchaseCropsObjects[0].Cost;



            ch.setPlayerCoin();

            valid = true;
            Debug.Log("Crops purchase");
        }
        else
        {
            Debug.Log("Not enough funds - 10 coins are needed");
        }

        if (valid == true)
        {

            Debug.Log("creating crops plot");
            // Create well on screen --TODO!!!


            //Storage - Player Storage/SAVE

            // add Timer + add food
            statsManager.increaseHungerMethod(); // TEMP for now ,  have a variable to change if true hunger + 5 etc
            statsManager.PlayerLevelCheck();


            validInstantiate = true; // Allows SpawnObject Script to call method which spawns prefab


            //Create waterWell / Prefab on screen
            spawnObjects.SetItemCrops(CropsPrefab);
            spawnObjects.name = "Crops";
        }



    }

    public void checkFoodStatus()
    {
        //is there enough for the population
        //Increase work
    }


    public void validateCowPurchase()
    {
        //--------TODO-------
        //Area levels will have different rights to build and more to unlock
        //UPgrades
        //e.g area level 1 until 2 = 5 wells 
        //ADD MORE 

        //bool valid = false;


        Debug.Log("Cow selected");
        if (numberofCows >= 0 && numberofCows <= 3)
        {
            createCow();
        }

        else if (numberofCows >= 4 && CharacterCreator.currentPlayerLevel >= 2)
        {

            Debug.Log("Granted access");
            createCow();
        }
        else
        {
            //Messagebox
            Debug.Log("Unable to purchase at this player Level");
        }

    }

    //--Animal - Cow
    public void createCow()
    {
        //Add cow to the array within the AreaResources 
        //AreaResources CLASS will create the cow and add its details
        //Save GAME 

       valid = false;

       //Purchase + funds Check
       if (CharacterCreator.currentPlayerCoin >= 100)
       {
             CharacterCreator.currentPlayerCoin = CharacterCreator.currentPlayerCoin - purchaseAnimalObjects[0].Cost;
             ch.setPlayerCoin();

             valid = true;
             Debug.Log("Cow purchase");
       }

       else
       {
             Debug.Log("Not enough funds - 100 coins are needed");

             valid = false;
       }


            //Timer of how often water gens
        

       if (valid == true) // IF the player has enough funds  -  stats and update stats - Instantiate prefab
       {

            Debug.Log("creating cow");
            
            //Storage - Player Storage/SAVE
            areaResources.addCowToArray();

            //XP
            CharacterCreator.currentXP = CharacterCreator.currentXP + 100;
            statsManager.PlayerLevelCheck();

            //Increase Area Level
            statsManager.increaseAreaLevel();

            validInstantiate = true; // Allows SpawnObject Script to call method which spawns prefab

            //Create Cow / Prefab on screen
            spawnObjects.SetItem(CowPrefab);
            spawnObjects.name = "Cow";
            numberofCows = numberofCows + 1;

            //CowPrefab.name = numberofCows.ToString();

            setResourceCow();


       }


    }

    public void CollectBtn()
    {
        //Create Button for the user to click to collect milk then the  time restarts.
        //Make it position near location of the Cow object/Prefab

        CollectMilkBtn.gameObject.SetActive(true); // this will make it spawn on the UI and then OnClick totalCowMilk()

        setResourceMilk();

    }

    public void RemoveCollectBtn()
    {

        CollectMilkBtn.gameObject.SetActive(false); // this will make it spawn on the UI and then OnClick totalCowMilk()

    }

    public void StoragePanel()
    {
        //ADvnced version so like buttons with icons food , animael etc 
        //if user click this panel displays..

        AreaStoragePanel.gameObject.SetActive(true);
        MilkCounterText.gameObject.SetActive(true);
        CowCounterText.gameObject.SetActive(true);
        GoToStorageBtn.gameObject.SetActive(false);
        TotalSellingAmount.gameObject.SetActive(true);
        SellBtn.gameObject.SetActive(true);
        InputSell.gameObject.SetActive(true);

        //button to close
        CloseStorageBtn.gameObject.SetActive(true);
        CloseStorageBtn.onClick.AddListener(resetGUI);
    }

    public void StoragePanelInActive()
    {
        AreaStoragePanel.gameObject.SetActive(false);
        MilkCounterText.gameObject.SetActive(false);
        CowCounterText.gameObject.SetActive(false);
        CloseStorageBtn.gameObject.SetActive(false);
        TotalSellingAmount.gameObject.SetActive(false);
        SellBtn.gameObject.gameObject.SetActive(false);
        InputSell.gameObject.SetActive(false);

        //button to reopen (true)
        GoToStorageBtn.gameObject.SetActive(true);
    }

    public void getInputSellAmountsValue()
    {
        //so we will have INT for each resource
        // SellCowInput = int.Parse(numberOfCowsSelling.ToString());

        // SellCowInput.text = int.Parse(numberOfCowsSelling.ToString());

        //numberOfCowsSelling = int.Parse(SellCowInput);


        if (int.TryParse(InputSell.text, out numberOfCowsSelling))
        {
            // Valid input, do something with it.
            numberOfCowsSelling = int.Parse(InputSell.text);
        }
        else
        {
            // Not a number, do something else with it.
            Debug.Log("oo");
        }

    }

    public void validateShopPurchase()
    {
        //--------TODO-------
        //Area levels will have different rights to build and more to unlock
        //UPgrades
        //e.g area level 1 until 2 = 5 wells 
        //ADD MORE 

        //bool valid = false;


        Debug.Log("Shop selected");
        if (shopCounter >= 0 && shopCounter <= 3)
        {
            createShop();
        }

        else if (shopCounter>= 4 && CharacterCreator.currentPlayerLevel >= 2)
        {

            Debug.Log("Granted access");
            createShop();
        }
        else
        {
            //Messagebox
            Debug.Log("Unable to purchase at this player Level");
        }

    }






    public void createShop()
    {
        bool valid = false;

            //Purchase + funds Check
       if (CharacterCreator.currentPlayerCoin >= 10)
       {

          CharacterCreator.currentPlayerCoin = CharacterCreator.currentPlayerCoin - purchaseShopObjects[0].Cost;
          ch.setPlayerCoin();

          valid = true;
          Debug.Log("shop purchase");

       }
       else
       {
          Debug.Log("Not enough funds - 10 coins are needed");
       }

            //Purchase confirmation + Creation 

        if (valid == true)
        {

            Debug.Log("creating shop plot");
            // Create well on screen --TODO!!!


            //Storage - Player Storage/SAVE

            // add Timer + add food??
            statsManager.ShopIncomeTimerMethod();
            statsManager.ShopExpensesTimerMethod();

            //Pay for products / Employees


            //STORE LEVEL - to be able to upgrade


            //START INCOME TIMER
            statsManager.PlayerLevelCheck();


            validInstantiate = true; // Allows SpawnObject Script to call method which spawns prefab


            //Create waterWell / Prefab on screen
            spawnObjects.SetItemShop(ShopPrefab);
            spawnObjects.name = "General Store"; // THIS needs updated on upgrade or change of name 
        }
    }

    //-------------------------Selling Objects -- e.g Buildings ---------------------------------

    //Selling building
    //--Price of sell most be less than bought for 
    //--Any validation 

    //--Remove Prefab
    //--stop any timers
    //--Effect on stats of the area??
    //--Situations if you do this ... 
    //--Confirm Action 
    //--Retrieve money 
    //--Save



    //Destorying so that you can upgrade
    //--Validation
    //--Retieve Money
    //--Remove Prefab
    //--stop any timers
    //--Effect on stats of the area??
    //--Situations if you do this ... 
    //--Confirm Action
    //--Retrieve money 
    //--Save







    //--------------------------Camera------------------------


    //Way back to PlayerArea from movement of different platforms
    public void moveCameraToPlayerArea()
    {
        cameraPosition = cameraPosition + 1;
        Debug.Log(cameraPosition + "YAAAAAAAAAAAAAAAAAAAAAddd");




        if (cameraPosition == 1)
        {

            //Boolean value to determine which platform/View we want
            triggerPlayerArea = true;


            float x = 425f;
            float y = 113f;
            float z = 54f;

            if (triggerPlayerArea == true)
            {
                //Move to PlayerView - Manual
                Camera.main.transform.Translate(x, y, z);
                Camera.main.transform.Rotate(90, 0, 0);

                //PlayerView no longer active
                //PlayerViewCamera.gameObject.SetActive(false);





                //Disable label that are not needed
                populationText.gameObject.SetActive(true);
                areaText.gameObject.SetActive(true);
                areaTypeText.gameObject.SetActive(true);
                areaLevelText.gameObject.SetActive(true);

                //Remove button that triggers this method and will then create a new button 
                GoToPlayerViewBtn.gameObject.SetActive(true);



            }

            else if (cameraPosition >= 2)
            {
                Debug.Log("BOO");


            }

        }



    }
}

