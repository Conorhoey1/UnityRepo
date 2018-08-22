using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]

public class PlayersArea : MonoBehaviour
{ 
    //Scene
    //Map 
    //Can we get player stat at the top?
    // TImers run in all scenes 

        //Todo
        //PlayerArea to PlayerView- still has a bug
        //Position of prefabs has a bug able to do legal postions

    //This script will be used to generate an area for the player in which they run/own
    //A town will have stats such population etc
    //Rules
    //levels 
    //Roles  , government , building 

    //We allow the user to  click a position on the screen in which they want to spawn an object
    //They should be only able to spawn the object if they purchase the object
    // we have method which tracks the mouse and the position but this will allow them to click at anytime, so we need to stop this only avaible when...


    //Scripts
    public CharacterCreator characterCreator; // Creator Script
    public Character ch; // Character Script
    public SpawnObjects spawnObjects;
    public StatManager statsManager;
    public UpgradeBuilds upgradeBuild;
    public PlaceBuilding placeBuilding;
    public AreaResources areaResources;

  

    //Area Resources - Water
    public string Watertype { get; set; } // well?? , river>?
    public int WaterLevel { get; set; }
    public int WaterAmount { get; set; }

    //------------Area Resources - Food------------------
    public string Foodtype { get; set; } // well?? , river>?
    public int FoodLevel { get; set; }
    public int FoodAmount { get; set; }

    //------Area Resources-------Food - UI
    public Button CollectMilkBtn; //Collect Cow Milk Btn

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

    //Player Stats
    public static int PlayerCoin;

    //Building Prefabs/GameObjects
    public GameObject hut;

    //Water Prefabs/GameObjects
    public GameObject WaterWell;

    //Crops Prefabs/GameObjects
    public GameObject CropsPrefab;

    //Animal Prefab/GameObjects
    public GameObject CowPrefab;//Animal


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
    public Button YesPurchaseBtn;
    public Button NoPurchaseBtn;
    public bool BtnClicked;


    //Variables for Object Effects
    public string ObjectType { get; set; } //Name - identifier
    public string Text { get; set; } // Used for DescriptionText Label
    public int EffectOnStatHealth { get; set; }
    public int EffectOnStatHunger { get; set; }
    public int EffectOnStatThirst { get; set; }
    public int EffectOnStatRespect { get; set; }
    public int EffectOnStatAreaHappiness { get; set; }
    public int EffectOnStatPopulation { get; set; }
    public int EffectOnStatCoin { get; set; }



    //Variables for Object Effects
    // public string WaterObjectType { get; set; } //Name - identifier
    //public string WaterText { get; set; } // Used for DescriptionText Label


    //List for Purchase Objects
    List<PlayersArea> purchaseWaterObjects = new List<PlayersArea>();
    List<PlayersArea> purchaseBuildingObjects = new List<PlayersArea>();
    List<PlayersArea> purchaseCropsObjects = new List<PlayersArea>();
    List<PlayersArea> purchaseAnimalObjects = new List<PlayersArea>();





    // Use this for initialization
    void Start()
    {

        spawnObjects = GameObject.FindObjectOfType<SpawnObjects>();
        possiblePurchases();
    }

    // Update is called once per frame
    void Update()
    {

        //statsManager.CheckLevelUp();
        PlayerViewCamera.gameObject.SetActive(false);

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

        //Confirm purchase which will be a Tick button and No for a X button

        YesPurchaseBtn.gameObject.SetActive(true);

        YesPurchaseBtn.onClick.AddListener(CreateWaterWell); //Spawn Prefab Method

        YesPurchaseBtn.onClick.AddListener(resetGUI); //Remove UI components method

        NoPurchaseBtn.gameObject.SetActive(true);

        NoPurchaseBtn.onClick.AddListener(resetGUI); //Remove UI components method

    }

    //This will retieve the object type and text and display below
    public void onClickViewHutPurchase() //Hut View
    {
        PurchaseBtn.gameObject.SetActive(false);

        ObjectTypeText.text = purchaseBuildingObjects[0].ObjectType.ToString(); // Name of the object

        DescriptionText.text = purchaseBuildingObjects[0].Text.ToString(); //Description

        //Confirm purchase which will be a Tick button and No for a X button

        YesPurchaseBtn.gameObject.SetActive(true);

        YesPurchaseBtn.onClick.AddListener(buildHouse); //Spawn Prefab Method

        YesPurchaseBtn.onClick.AddListener(resetGUI); //Remove UI components method

        NoPurchaseBtn.gameObject.SetActive(true);

        NoPurchaseBtn.onClick.AddListener(resetGUI); //Remove UI components method

    }


    //This will retieve the object type and text and display below
    public void onClickViewCropsPurchase() //Crops View
    {
        PurchaseBtn.gameObject.SetActive(false);

        ObjectTypeText.text = purchaseCropsObjects[0].ObjectType.ToString(); // Name of the object

        DescriptionText.text = purchaseCropsObjects[0].Text.ToString(); //Description

        //Confirm purchase which will be a Tick button and No for a X button

        YesPurchaseBtn.gameObject.SetActive(true);

        YesPurchaseBtn.onClick.AddListener(CreateCrops); //Spawn Prefab Method

        YesPurchaseBtn.onClick.AddListener(resetGUI); //Remove UI components method

        NoPurchaseBtn.gameObject.SetActive(true);

        NoPurchaseBtn.onClick.AddListener(resetGUI); //Remove UI components method

    }

    //This will retieve the object type and text and display below
    public void onClickViewCowPurchase() //Crops View
    {
        PurchaseBtn.gameObject.SetActive(false);

        ObjectTypeText.text = purchaseAnimalObjects[0].ObjectType.ToString(); // Name of the object

        DescriptionText.text = purchaseAnimalObjects[0].Text.ToString(); //Description

        //Confirm purchase which will be a Tick button and No for a X button

        YesPurchaseBtn.gameObject.SetActive(true);

        YesPurchaseBtn.onClick.AddListener(createCow); //Spawn Prefab Method

        YesPurchaseBtn.onClick.AddListener(resetGUI); //Remove UI components method

        NoPurchaseBtn.gameObject.SetActive(true);

        NoPurchaseBtn.onClick.AddListener(resetGUI); //Remove UI components method

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
        purchaseAnimalObjects.Add(new PlayersArea { ObjectType = "Cow", Text = "This is a cow - Cost: 100 Coins", EffectOnStatCoin = 100, EffectOnStatAreaHappiness = 5 });


        //---Water Object List---
        purchaseWaterObjects.Add(new PlayersArea { ObjectType = "Well", Text = "This is a water well that can be used to ....... - Cost: 100 Coins", EffectOnStatCoin = 100, EffectOnStatAreaHappiness = 5 });



        //------Plants / Plant Crops List------
        purchaseCropsObjects.Add(new PlayersArea { ObjectType = "Crops", Text = " .. , , effects = ... ,  - Cost: 10 Coins", EffectOnStatCoin = 10, EffectOnStatAreaHappiness = 5 });


        //------Building List------

        //Build Hut
        purchaseBuildingObjects.Add(new PlayersArea { ObjectType = "Hut", Text = " Hut ... - Cost: 50 Coins", EffectOnStatCoin = 50, EffectOnStatAreaHappiness = 5 });
        //General Store
        purchaseBuildingObjects.Add(new PlayersArea { ObjectType = "General Store", Text = " .. , Regalar income however there is a cost as you must pay your employees - Cost: 150 Coins", EffectOnStatCoin = 150, EffectOnStatAreaHappiness = 5 });

    }




    //-----------------------------Methods to call for Objects------------------------------------------

    public void buildHouse() //Change name to hut or something more generic
    {
        //This is called when user wants to build house
        // Must have 50 coins
        // call method spawnObjects which creates prefab
        //Within spawnObjects it will be active all the time so set it to false;
        // Only allow 1 object to be placed.

        //Set amount of house
        //One house allows 3 people?

        //--------TODO-------
        //Area levels will have different rights to build and more to unlock
        //e.g area level 1 until 2 = 5 wells 

        //bool valid = false;

        houseCounter++;

        // string userInput = "";

        Debug.Log("House selected");

        if (houseCounter > 12)
        {
            Debug.Log("Unable to build , you can only have 5 houses at this areas level ");

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

        }

        else
        {

            //Purchase + funds Check
            if (CharacterCreator.currentPlayerCoin >= 10)
            {
                CharacterCreator.currentPlayerCoin = CharacterCreator.currentPlayerCoin - purchaseWaterObjects[0].EffectOnStatCoin;
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
        }

        if (valid == true) // IF the player has enough funds  -  stats and update stats - Instantiate prefab
        {

            Debug.Log("creating House");



            //Storage - Player Storage/SAVE

            // Population check ?? add people into it?

            statsManager.PopulationCheck();

            //Update AreaType Label - GUI
            ch.setAreaType();

            CharacterCreator.currentPopulation = CharacterCreator.currentPopulation + 1;
            Debug.Log(CharacterCreator.currentPopulation);

            //Update Population Label - GUI
            ch.setAreaPopulation();

            //XP
            CharacterCreator.currentXP = CharacterCreator.currentXP + 100;
            statsManager.PlayerLevelCheck();

            //Increase Area Level
            statsManager.increaseAreaLevel();

            validInstantiate = true; // Allows SpawnObject Script to call method which spawns prefab


            //Create House / Prefab on screen
            spawnObjects.SetItem(hut);




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

    public void CreateWaterWell()
    {
        //--------TODO-------
        //Area levels will have different rights to build and more to unlock
        //e.g area level 1 until 2 = 5 wells 
        //WHAT HAPPENS IF THERE ARE 2 WELLS?

        bool valid = false;



        waterWellCounter++;

        Debug.Log("Water Well selected");

        if (waterWellCounter > 5)
        {
            Debug.Log("Unable to build , you can only have 5 water wells at this areas level ");
        }
        else
        {


            //Purchase + funds Check
            if (CharacterCreator.currentPlayerCoin >= 10)
            {
                CharacterCreator.currentPlayerCoin = CharacterCreator.currentPlayerCoin - 10;


                
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
        }

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

    public void CreateCrops()
    {
        //--------TODO-------
        //Area levels will have different rights to build and more to unlock
        //e.g area level 1 until 2 = 5 wells 

        // Different upgrades
        // 5 crops plots = a field? but u have to pay for the upgrade. 
        bool valid = false;



        cropsCounter++;

        Debug.Log("Crops selected");

        if (cropsCounter > 5)
        {
            Debug.Log("Unable to perfrom crops action , you can only have 5 crops at this areas level ");
        }
        else
        {


            //Purchase + funds Check
            if (CharacterCreator.currentPlayerCoin >= 10)
            {
                CharacterCreator.currentPlayerCoin = CharacterCreator.currentPlayerCoin - 10; //=-.CoinList[54]
                ch.setPlayerCoin();

                valid = true;
                Debug.Log("crop plot purchase");
            }
            else
            {
                Debug.Log("Not enough funds - 10 coins are needed");
            }

            //Purchase confirmation + Creation 

            //Creation of well (Prefab graphic)
            //Timer of how often water gens
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

        }



    }

    public void checkFoodStatus()
    {
        //is there enough for the population
        //Increase work
    }


    //--Animal - Cow
    public void createCow()
    {
        //Add cow to the array within the AreaResources 
        //AreaResources CLASS will create the cow and add its details
        //Save GAME 
        //

        //






        //AreaResources.numberofCows++;

        // string userInput = "";

        Debug.Log("House selected");

        if (AreaResources.numberofCows > 12)
        {
            Debug.Log("Unable to build , you can only have 5 cows at this areas level ");

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

        }

        else
        {

            //Purchase + funds Check
            if (CharacterCreator.currentPlayerCoin >= 100)
            {
                CharacterCreator.currentPlayerCoin = CharacterCreator.currentPlayerCoin - purchaseAnimalObjects[0].EffectOnStatCoin;
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
        }

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



            //Create House / Prefab on screen
            spawnObjects.SetItem(CowPrefab);


        }


    }

    public void CollectBtn()
    {
        //Create Button for the user to click to collect milk then the  time restarts.
        //Make it position near location of the Cow object/Prefab

        CollectMilkBtn.gameObject.SetActive(true); // this will make it spawn on the UI and then OnClick totalCowMilk()
    }











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
                ch.populationText.gameObject.SetActive(true);
                ch.areaText.gameObject.SetActive(true);
                ch.areaTypeText.gameObject.SetActive(true);
                ch.areaLevelText.gameObject.SetActive(true);

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

