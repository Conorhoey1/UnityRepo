using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



[System.Serializable]
public class CharacterCreator : MonoBehaviour
{

    //Base Class

    public InputField InputName;
    public InputField InputArea;

    public static string characterName;
    public static string gender;

    public static string areaName;
    public static int areaLevel;
    public static int currentPopulation;
    public static string areaType;
    public static int areaHappiness;

    //Stats - Starting
    public static int startingHealth;
    public static int startingHunger;
    public static int startingThirst;
    public static int startingRespect; // Respect of his tribe/area
    public static int startingHappiness;
    public static int startingPlayerLevel;
    public static int startingPlayerCoin;

    //Stats - Current 
    public static int currentHealth;
    public static int currentHunger;
    public static int currentThirst;
    public static int currentRespect; // Respect of his tribe/area
    public static int currentHappiness;
    public static int currentPlayerLevel;
    public static int currentPlayerCoin;

 
    //Player XP - different levels require a certain amount of XP
    public static int RequiredXP; // Required amount - used to set different amounts for higher Levels
    public static int currentXP; // This the Current Player XP Amount


 






    public void onSubmit(string scenename)
    {
        //todo , validation must enter all inputs as game does crash


        //set name
        characterName = InputName.text;

        areaName = InputArea.text;


        //display
        Debug.Log("name " + characterName);

        Debug.Log("Gender is" + gender);

        Debug.Log("name " + characterName);

        Debug.Log("Gender is" + gender);

        Debug.Log("Creating player  -  " + characterName);

        Debug.Log("Area " + areaName);

        Application.LoadLevel(scenename);


        currentHealth = 100;
        currentHunger = 100;
        currentThirst = 100;
        currentRespect = 100;
        currentHappiness = 100;
        currentPlayerLevel = 1;
        currentPlayerCoin = 1000;

        currentPopulation = 1;

        areaLevel = 1;
        areaType = ""; // By yourself
        areaHappiness = 0; // NEED A TIMER!!

    }

    public void onMaleSubmit()
    {
        gender = "Male";
        Debug.Log("Gender: " + gender);
    }

    public void onFemaleSubmit()
    {
        gender = "Female";

        Debug.Log("Gender: " + gender);

    }

   

}
