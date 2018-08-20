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
    public string AnimalType { get; set; } //Name - identifier
    public int AnimalHealth { get; set; }
    public int AnimalHunger { get; set; }
    public int AnimalThirst { get; set; }
    public int CoinValue { get; set; } //This value can go up and you can sell -- U need to work this out
    public int MilkAmount { get; set; }// can milk a cow using the timer it will spawn then sell it for coins

    public int numberofCows; // For the list to show the user

    // Use this for initialization
    void Start ()
    {
        AnimalObjects();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}


    public void AnimalObjects()
    {

        //------Animal Cow------
        CowObjects.Add(new AreaResources{ AnimalType = "Cow", AnimalHealth = 100, AnimalHunger = 100, AnimalThirst = 100 , CoinValue = 100 , MilkAmount = 5});


    }

    public void addCowToArray()
    {
        //for loop 
        //Then used to add a cow to the array 
        //add 1 to int numberOfCows
        //Start timer for milk generation
        //SAVe
    }
}
