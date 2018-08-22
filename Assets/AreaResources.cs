using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaResources : MonoBehaviour
{


    //This will give animals all variables , we will alos use this to view resources which the area can use 
    //The area can have like a low stock of bread or milk 
    //We could have a new scene of all this page - Not using this SCRIPT
    //if you dont have these resources the population can go hungry and people get unhappy etc

    //---- Animal Variables : Cow ----
    List<AreaResources> CowObjects = new List<AreaResources>(); //Cow List array

    //Cow Variables 
    public int AnimalNo { get; set; } virtual// identifier
    public string AnimalType { get; set; } //Name 
    public int AnimalHealth { get; set; }
    public int AnimalHunger { get; set; }
    public int AnimalThirst { get; set; }
    public int CoinValue { get; set; } //This value can go up and you can sell -- U need to work this out
    public int MilkAmount { get; set; }// This is the amount they can produce

    public int TotalMilkStorage { get; set; } // You can then sell it 

    public static int numberofCows = 0; // For the list to show the user

    //Scripts
    public StatManager stats;

    // Use this for initialization
    void Start ()
    {
       
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void addCowToArray()
    {
        int i = 1;// loop once as only 1 cow


        //for loop 
        for(i= 0; i <=1; i++ )
        {
            //add 1 to int numberOfCows
            //we can use animalNo as an identifier
            CowObjects.Add(new AreaResources { AnimalNo = numberofCows + 1 ,AnimalType = "Cow", AnimalHealth = 100, AnimalHunger = 100, AnimalThirst  =100 , CoinValue = 100 , MilkAmount = 5});

        }

       

        //Start timer for milk generation
       stats.MilkCowTimerMethod();

        //SAVE NEEDED
    }

    //This will generate the milkAmount
    public void totalCowMilk()
    {
        
        TotalMilkStorage = TotalMilkStorage + CowObjects[0].MilkAmount * numberofCows; //collection amount calculation

        //Reset Timer
        StatManager.setCowMilkTimer = true;
        StatManager.IncreaseCowMilkTimeLeft = StatManager.IncreaseCowMilkTimeLeft + 20.0f; //Add time to the timer


    }
}
