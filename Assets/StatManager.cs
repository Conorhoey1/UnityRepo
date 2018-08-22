using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    //Used for updating stat values


    //THIS IS A TEMP TIMER AS IT DOES NOT STORE WHEN THE USER QUITS
    // JUST TO GET THINGS MOVING 

    public static float ReduceHungerTimeLeft = 10.0f; //seconds // Reduce
    public static float ReduceThirstTimeLeft = 10.0f; //seconds // Reduce

    public static float IncreaseHungerTimeLeft = 20.0f; //seconds 
    public static float IncreaseThirstTimeLeft = 20.0f; //seconds 
    public static float IncreaseCowMilkTimeLeft = 20.0f; //seconds 


    public static bool setWaterWellTimer = false;
    public static bool setCropsTimer = false;
    public static bool setCowMilkTimer = false;


    public CharacterCreator cc;
    public Character ch;
    public PlayersArea pha;
    public AreaResources areaR;


    public void Update()
    {

        reduceHungerMethod();
        reduceThirstMethod();

        if(setWaterWellTimer == true)
        {
            increaseThirstMethod();
        }

        if(setCropsTimer == true)
        {
            increaseHungerMethod();
        }
        if(setCowMilkTimer == true)
        {
            MilkCowTimerMethod();
        }


    }

    //Other scenes can use this 
    //BUG - in times left within debug

    public void reduceHungerMethod()
    {
        //  bool repeat = false; //THis will repeat all reduce functions - only need this once as calling Update();

        ReduceHungerTimeLeft -= Time.deltaTime;

        Debug.Log("Time Left:" + Mathf.Round(ReduceHungerTimeLeft)); //Test - Correct

        if (ReduceHungerTimeLeft <= 0)
        {
            Debug.Log("timer done");

            CharacterCreator.currentHunger = CharacterCreator.currentHunger - 1; // Subtract Hunger




            ch.setHunger(); // Set Label Method

            ReduceHungerTimeLeft = ReduceHungerTimeLeft + 10.0f; // Reset Timer


           

        }

       


    }



    //Other scene can use this 
    //BUG - in times left within debug
    public void reduceThirstMethod()
    {
        ReduceThirstTimeLeft -= Time.deltaTime;

        Debug.Log("Time Left:" + Mathf.Round(ReduceThirstTimeLeft)); //Test - Correct

        if (ReduceThirstTimeLeft <= 0)
        {
            Debug.Log("timer done ");

            CharacterCreator.currentThirst = CharacterCreator.currentThirst - 1; // Subtract Hunger

            ch.setThirst(); // Set Label Method

            ReduceThirstTimeLeft = ReduceThirstTimeLeft + 10.0f; // Reset Timer

        }
    }


    //Other scenes can use this - used for crop Object?
    //BUG - in times left within debug
    public void increaseHungerMethod()
    {
        IncreaseHungerTimeLeft -= Time.deltaTime;

        setCropsTimer = true;

        Debug.Log("Time Left HUNGER:" + Mathf.Round(IncreaseHungerTimeLeft)); //Test - Correct

        if (IncreaseHungerTimeLeft <= 0)
        {
            Debug.Log("timer done");

            CharacterCreator.currentHunger = CharacterCreator.currentHunger + 20; // Add Hunger
            CharacterCreator.currentXP = CharacterCreator.currentXP + 100;

            ch.setHunger(); // Set Label Method

            IncreaseHungerTimeLeft = IncreaseHungerTimeLeft + 20.0f; // Reset Timer

        }
    }

    //Other scenes can use this - used for water source Object?
    //BUG - in times left within debug
    public void increaseThirstMethod()
    {
       
        IncreaseThirstTimeLeft -= Time.deltaTime;

        setWaterWellTimer = true;

        Debug.Log("Time Left THIRST:" + Mathf.Round(IncreaseThirstTimeLeft)); //Test - Correct

        if (IncreaseThirstTimeLeft <= 0)
        {
            Debug.Log("WE R IN!!!!!!!!!");

            // waterWellThirstIncrease(); //Add Thirst
            CharacterCreator.currentThirst = CharacterCreator.currentThirst + 20;
            CharacterCreator.currentXP = CharacterCreator.currentXP + 100;


            ch.setThirst(); // Set Label Method

            IncreaseThirstTimeLeft = IncreaseThirstTimeLeft + 20.0f; // Reset Timer

        }
    }

    //Other scenes can use this - used for crop Object?
    //BUG - in times left within debug
    public void MilkCowTimerMethod()
    {
        IncreaseCowMilkTimeLeft -= Time.deltaTime;

        setCowMilkTimer = true;

        Debug.Log("Time Left HUNGER:" + Mathf.Round(IncreaseCowMilkTimeLeft)); //Test - Correct

        if (IncreaseCowMilkTimeLeft <= 0)
        {
            Debug.Log("timer done");


            CharacterCreator.currentXP = CharacterCreator.currentXP + 10;


            setCowMilkTimer = false; //Stop timer until milk is collect

            pha.CollectBtn(); // Spawn Collect button


        }
    }




















    public void increasePlayerLevel()
    {

        CharacterCreator.currentPlayerLevel = CharacterCreator.currentPlayerLevel + 1;
        ch.setPlayerLevel();

    }

    public void increasePlayerCoin()
    {
        CharacterCreator.currentPlayerCoin = CharacterCreator.currentPlayerCoin + 1;
        ch.setPlayerCoin();
    }


    public void cropsIncreaseHunger()
    {
        CharacterCreator.currentHunger = CharacterCreator.currentHunger + 2; // increase Hunger Stat
        CharacterCreator.currentXP = CharacterCreator.currentXP + 100;

    }

    public void increaseAreaLevel()
    {
        CharacterCreator.areaLevel = CharacterCreator.areaLevel + 1;
        
    }

    public void areaIncreaseHappiness()
    {
        CharacterCreator.areaHappiness = CharacterCreator.areaHappiness + 2; // increase Hunger Stat
        CharacterCreator.currentXP = CharacterCreator.currentXP + 100;

    }

    public void PlayerLevelCheck()
    {

        Debug.Log("yo1");
        //Level  1 or all levels???
        // Basic need to make it more difficult
        //1-20 is done but we may need to change requiredXP amounts

        //Level 1-5
        if (CharacterCreator.currentPlayerLevel >= 1 && CharacterCreator.currentPlayerLevel <= 5)
        {
            Debug.Log("yo2");
            CharacterCreator.RequiredXP = 100;
            CheckLevelUp();

        }
        //Level 6-10
        else if (CharacterCreator.currentPlayerLevel >= 6 && CharacterCreator.currentPlayerLevel <= 10)
        {
            CharacterCreator.RequiredXP = 200;
            CheckLevelUp();
        }

        else if (CharacterCreator.currentPlayerLevel >= 11 && CharacterCreator.currentPlayerLevel <= 19)
        {
            CharacterCreator.RequiredXP = 300;
            CheckLevelUp();
        }
        //Level 20- ....
        else if (CharacterCreator.currentPlayerLevel >= 20)
        {
            CharacterCreator.RequiredXP = 400;
            CheckLevelUp();
        }

    }

    public void CheckLevelUp()
    {

        //Checks if player has enough XP to level up
        if (CharacterCreator.currentXP == CharacterCreator.RequiredXP)
        {
            CharacterCreator.currentPlayerLevel = CharacterCreator.currentPlayerLevel + 1;
            ch.setPlayerLevel();
            Debug.Log(CharacterCreator.currentPlayerLevel);//Test
            CharacterCreator.currentXP = 0;//Reset currentXP


        }
        else
        {
            Debug.Log("Not enough to level up");
        }

    }



    public void PopulationIncrease()
    {
        CharacterCreator.currentPopulation = CharacterCreator.currentPopulation + 5;//Test Amount
        ch.setAreaPopulation();

    }

    public void PopulationCheck()
    {
        //Settlement
        if (CharacterCreator.currentPopulation >= 1 && CharacterCreator.currentPopulation <= 3)
        {

            //Valid - Are they sure?
            //  validateAreaType();
          
            //Create
            //   PopulationIncrease();
           

            //Set Area type
            CharacterCreator.areaType = "Settlement";
         
            ch.setAreaType();


        }
        //Village
        else if (CharacterCreator.currentPopulation >= 4 && CharacterCreator.currentPopulation <= 20)
        {
            //Valid - Are they sure?
            // validateAreaType();

            //Create

            //Set Area type
            CharacterCreator.areaType = "Village";
            ch.setAreaType();

        }
        //Town
        else if (CharacterCreator.currentPopulation >= 11 && CharacterCreator.currentPopulation <= 30)
        {
            //Valid - Are they sure?
            // validateAreaType();

            //Create

            //Set Area type
            CharacterCreator.areaType = "Town";
            ch.setAreaType();
        }
        //City
        else if (CharacterCreator.currentPopulation >= 21 && CharacterCreator.currentPopulation <= 30)
        {
            //Valid - Are they sure?
            // validateAreaType();

            //Create

            //Set Area type
            CharacterCreator.areaType = "City";
            ch.setAreaType();
        }
        //Country
        else
        {
         
        }
    }
}


    //Check if they want to as upgrading Area will result in new Taxes and expense
 //   public void validateAreaType()
   // {
        //MessageBox or Label that appears listing the advantages and the disadvantages

        
  //  }


//}
