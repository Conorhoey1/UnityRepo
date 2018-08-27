using System.Collections;
using System.Collections.Generic;

using System.Linq;
using UnityEngine;



[System.Serializable]
public class AreaResources : MonoBehaviour
{



    //This will give animals all variables , we will alos use this to view resources which the area can use 
    //The area can have like a low stock of bread or milk 
    //We could have a new scene of all this page - Not using this SCRIPT
    //if you dont have these resources the population can go hungry and people get unhappy etc

        //Area storage Panel will be used to sell storage for coins to other villages/ countries

    //---- Animal Variables : Cow ----
    public List<AreaResources> CowObjects = new List<AreaResources>(); //Cow List array

    //Cow Variables 

    
    public int AnimalNo { get; set; } // identifier
    public string AnimalType { get; set; } //Name 
    public int AnimalHealth { get; set; }
    public int AnimalHunger { get; set; }
    public int AnimalThirst { get; set; }
    public int CoinValue { get; set; } //This value can go up and you can sell -- U need to work this out -Default always the same is best
    public int MilkAmount { get; set; }// This is the amount they can produce


    public int totalCoins;//used to send coins to playerCoins
    bool validSell = false;


    //Scripts
    public StatManager stats;
    public PlayersArea playerArea;
    public Character character;

    // Use this for initialization
    void Start ()
    {
        //Default
        CowObjects.Add(new AreaResources { AnimalNo = 9, AnimalType = "DefualtCow", AnimalHealth = 100, AnimalHunger = 100, AnimalThirst = 100, CoinValue = 100, MilkAmount = 5 });
    }
	
	// Update is called once per frame
	void Update ()
    {
        SellObject();


        SellInputFieldEmptyException();

        //ss();
       

    }

    //Exception handling - ArgumentOutOfRangeException due to empty input field
    public void SellInputFieldEmptyException()
    {
        try
        {
            //It doesnt matter which element we get as cowValue will always be the same
            totalCoins = PlayersArea.numberOfCowsSelling * CowObjects[0].CoinValue;



            //Display selling amount
            playerArea.TotalSellingAmount.text = totalCoins.ToString();
        }

        catch(System.ArgumentOutOfRangeException ex)
        {
            Debug.Log("EXCEPTION");
        }
        
    }


    
    public void addCowToArray()
    {

        int i = 1;// loop once as only 1 cow

        //for loop 
        for (i = 0; i <= 1; i++)
        {
            //add 1 to int numberOfCows
            //we can use animalNo as an identifier
            CowObjects.Add(new AreaResources { AnimalNo = PlayersArea.numberofCows, AnimalType = "Cow", AnimalHealth = 100, AnimalHunger = 100, AnimalThirst = 100, CoinValue = 100, MilkAmount = 5 });

        }

       //Start timer for milk generation
       stats.MilkCowTimerMethod();

        //SAVE NEEDED

    }

    //This will generate the milkAmount
    public void totalCowMilk()
    {
        //Does this do all the cows? -------CHECK THIS 
        PlayersArea.TotalMilkStorage = PlayersArea.TotalMilkStorage + CowObjects[0].MilkAmount * PlayersArea.numberofCows; //collection amount calculation

        //Reset Timer
        StatManager.setCowMilkTimer = true;
        StatManager.IncreaseCowMilkTimeLeft = StatManager.IncreaseCowMilkTimeLeft + 20.0f; //Add time to the timer
       
        playerArea.RemoveCollectBtn();
    }

    public void SellObject()
    {

        //Selling amount
        //Needs validation
        //PlayersArea.numberOfCowsSelling;
        //PlayersArea.numberOfMilkSelling

       


        //Validate if the user has these assets available
        if(PlayersArea.numberOfCowsSelling > PlayersArea.numberofCows)
        {
            //Need a way to 
            Debug.Log("Unable to process - Selling");
        }
        else if(PlayersArea.numberofCows <= PlayersArea.numberOfCowsSelling)
        {


            //Sell Button will total up the coin amount and add to player balance from all objects so 1 button for all 
      


            CowObjects.RemoveRange(1 , PlayersArea.numberofCows);
            


            //  for(int i = 0; i<= PlayersArea.numberofCows;  i++)
            //  {
            //     Debug.Log(CowObjects[i].AnimalNo);
            //
            //  }

            //test
           // display();











            //Reduce number of cows 
            PlayersArea.numberofCows = PlayersArea.numberofCows - PlayersArea.numberOfCowsSelling;
            playerArea.setResourceCow();
            Debug.Log("in HRERE");

            //find which CowObject to remove - 

            

         //   int max = int.MinValue;

          //  foreach (AreaResources yep in CowObjects)
          //  {
           //     if (yep.AnimalNo > max)
            //    {
           //         max = yep.AnimalNo;
              //  }

         //   }
         //   Debug.Log("this is max" + max);



            validSell = true; //Sell confirm

            //Enable Sell Method and attach to the button OnClick()
            playerArea.SellBtn.onClick.AddListener(OnSellRetieveCoinsMethod);

        }


    }

    

    public void OnSellRetieveCoinsMethod()
    {
        if (validSell == true)
        {



            CharacterCreator.currentPlayerCoin = CharacterCreator.currentPlayerCoin + totalCoins;
            character.setPlayerCoin();


            validSell = false;//Reset Bool
            PlayersArea.numberOfCowsSelling = 0;

            //NEED A WAY TO REMOVE PREFAB NOW
            //END TIMERS
            //CLOSE THE PANEL
            //MORE TESTing

        
            
            //Remove from ObjectList
            //  
            //CowObjects.RemoveAt(highestNum); // need an proper identifer as Animal type wil remove them all ?
      
            
            
            //end timers or 1 timer etc
        }
        else
        {
            Debug.Log("invalid Sell ");

        }
    }

    //Validation Method
    public void disableSell()
    {
        //Need something for the UI?
        Debug.Log("Validation - cannot sell");
    }




    //Save Game
    //  public void saveObjects()
    //{
    //     PlayerPrefs.SetInt("InventoryCount", CowObjects.Count);

    //    for (PlayersArea.numberofCows = 0; PlayersArea.numberofCows < CowObjects.Count; PlayersArea.numberofCows++)
    //  {
    //      PlayerPrefs.SetInt("AnimalNo" + PlayersArea.numberofCows + CowObjects[PlayersArea.numberofCows].AnimalNo);
    //      PlayerPrefs.SetString("AnimalType" + CowObjects[i].AnimalType);
    //
    //        PlayerPrefs.Save();
    //     }

    // }
}
