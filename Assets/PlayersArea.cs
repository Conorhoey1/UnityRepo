﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]

public class PlayersArea : MonoBehaviour
{
    //Scene
    //Map 
    //Can we get player stat at the top?
    // TImers run in all scenes 
   




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
   // public SpawnObjects spawnObjects;
    public StatManager statsManager;
    public UpgradeBuilds upgradeBuild;

    



    //Area Variables
    //public static string areaName; // need a input box when user unlocks an area
    //public static int AreaLevel;
    //public static int Population;
    //public static string areaType;

    //Area Resources - Water
    public string Watertype { get; set; } // well?? , river>?
    public int WaterLevel { get; set; }
    public int WaterAmount { get; set; }
    
    //Area Resources - Food
    public string Foodtype { get; set; } // well?? , river>?
    public int FoodLevel { get; set; }
    public int FoodAmount { get; set; }

    


    //Purchase
    public int PriceOfAsset { get; set; }


    //House - Variables
    public int houseCounter { get; set; }
    

    //Water Well - Variables
    public int waterWellCounter { get; set; }

    //Crops - Variables
    public int cropsCounter { get; set; }



    //Player Stats
    public static int PlayerCoin;


    






    // new PlayersArea(){ Watertype =" Water Well ", WaterAmount = 2 , PriceOfAsset = 10},

    // new PlayersArea(){ Watertype =" Water.. ", WaterLevel = 2 , WaterAmount = 3 , PriceOfAsset = 5}




    // Use this for initialization
    void Start()
    {
     //  areaName = CharacterCreator.areaName;
       // AreaLevel = CharacterCreator.AreaLevel = 1;
        //Population = CharacterCreator.Population = 1;// 1???
       // areaType = CharacterCreator.areaType = "";
          // creates 3 then quits??

       // setAreaName();
      //  setAreaLevel();
      //  setPopulation();
      //  setAreaType();

      //  GameObject pa = new GameObject();
      //  pa.AddComponent<PlayersArea>();
    }

    // Update is called once per frame
    void Update()
    {
       

        //statsManager.CheckLevelUp();
    }

    
    public void buildHouse()
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

        bool valid = false;

        houseCounter++;

        string userInput = "";

        Debug.Log("House selected");

        if (houseCounter > 12)
        {
            Debug.Log("Unable to build , you can only have 5 houses at this areas level ");

            //Would you like to upgrade these houses to an estate for 1300 Coins

            //Benefits - Community spirt and happiness increase
            Debug.Log("Would you like to upgrade these houses to an estate for 1300 Coins");


            //User input but we want it to be a button yes or no buttons
            if(userInput == "Yes") 
            {
                //Yes
                CharacterCreator.currentPlayerCoin = CharacterCreator.currentPlayerCoin - 1300;

                //Upgrade House build
                upgradeBuild.UpgradeHouseBuild();
            }
            else if(userInput == "No")
            {
                //No
                Debug.Log("Purchase cancelled");
            }
            
                
            
    

        }

        else
        {


            //Purchase + funds Check
            if (CharacterCreator.currentPlayerCoin >= 10)
            {
                CharacterCreator.currentPlayerCoin = CharacterCreator.currentPlayerCoin - 10;
                ch.setPlayerCoin();

                valid = true;
                Debug.Log("House purchase");
            }
            else
            {
                Debug.Log("Not enough funds - 10 coins are needed");
            }

            //Purchase confirmation + Creation 

            //Creation of house(Prefab graphic)
            //Timer of how often water gens
        }

        if (valid == true)
        {

            Debug.Log("creating House");
            // Create well on screen --TODO!!!


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
            statsManager.waterWellThirstIncrease();
            statsManager.PlayerLevelCheck();

        }


       
    }

    public void storeWaterFeatures()
    {
        //Area Level 1 - Build Water Well
        // need conditions for cost etc
        //PlayersArea water1 = new PlayersArea();
       // water1.Watertype = "Water Well";
       // water1.WaterLevel = 1;
       // water1.WaterAmount = 3;
       // water1.PriceOfAsset = 10;

       // waterList.Add(water1);


        //Area Level 2 - Build ....
        //PlayersArea water2 = new PlayersArea();
       // water2.Watertype = "Water 2";
        //water2.WaterLevel = 2;
        //water2.WaterAmount = 6;
       // water2.PriceOfAsset = 20;

       // waterList.Add(water2);
       
      //  PlayersArea waterWell = waterList[0];
       // PlayersArea waterSource2 = waterList[1];

        //Debug.Log("Current Balance " + coin);

      //  coin = coin - water1.PriceOfAsset; //change amount? // Reduce amount

       // character.setPlayerCoin();

      //  Debug.Log("New balance is " + coin);
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
                CharacterCreator.currentPlayerCoin = CharacterCreator.currentPlayerCoin - 10;
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
            statsManager.cropsIncreaseHunger();
            statsManager.PlayerLevelCheck();

        }



    }

    public void checkFoodStatus()
    {
        //is there enough for the population
        //Increase work
    }


  



}
