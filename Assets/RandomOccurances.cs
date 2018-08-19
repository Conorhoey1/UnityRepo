using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomOccurances : MonoBehaviour
{
    public static float minRespawn = 1f;
    public static float maxRespawn = 10f;

    //Scripts
    public CharacterCreator characterCreator; // Creator Script

    //Situation MessageBox
    public GameObject SituationMessage;
    public GameObject MessageBox;
    public Text SituationText;

    //Variables for Situations
    public string SituationType { get; set; } //Name - identifier
    public string Text { get; set; } // Used for SituationText Label
    public int EffectOnStatHealth { get; set; }
    public int EffectOnStatHunger { get; set; }
    public int EffectOnStatThirst { get; set; }
    public int EffectOnStatRespect { get; set; }
    public int EffectOnStatAreaHappiness { get; set; }
    public int EffectOnStatPopulation { get; set; }
    public int EffectOnStatCoin { get; set; }

    //List for Situations 
    List<RandomOccurances> randomOccurances = new List<RandomOccurances>();
    public static int index; //used to get random number


    //Unity special system random  - Random rnd = new Random() did not have .Next
    public System.Random ran = new System.Random(); // 

    public void Start ()
    {
        Invoke("AttackOnPlayer", (Random.Range(minRespawn, maxRespawn)));
        Invoke("Situations" , (Random.Range(minRespawn,maxRespawn)));


        SituationMessage.SetActive(false);

        //Possible Situations- Basic
        randomOccurances.Add(new RandomOccurances { SituationType = "Repair Well", Text = "Can we some money?",EffectOnStatCoin = 10 , EffectOnStatAreaHappiness = 5 , EffectOnStatRespect = 2 });
        randomOccurances.Add(new RandomOccurances { SituationType = "Spare coins", Text = "Can we borrow some money for food?", EffectOnStatCoin = 10, EffectOnStatAreaHappiness = 5, EffectOnStatRespect = 2 });
        randomOccurances.Add(new RandomOccurances { SituationType = "Bonfire night?", Text = "Can we have a bonfire nighT?", EffectOnStatCoin = 20, EffectOnStatAreaHappiness = 5, EffectOnStatRespect = 2 });

        //Custom Occurances - Advanced / Require its own YesMethod not the default


    }


    public override string ToString()
    {
        return SituationType  + Text;
        
    }


    public void AttackOnPlayer()
    {
        float delay = Random.Range(minRespawn, maxRespawn);
       

        //Do stuff
        Invoke("AttackOnPlayer", delay);

        Debug.Log("THIS IS THE MESSAGE ITS WORKING");

        CharacterCreator.currentHealth = CharacterCreator.currentHealth - 10;

        CharacterCreator.currentHappiness = CharacterCreator.currentHappiness - 5;

        //Destory prefabs/homes - they need repairs
        
    }


   public void Situations()
    {
        float delay = Random.Range(minRespawn, maxRespawn);


        //Do stuff
        Invoke("Situations", delay);

        Debug.Log("THIS IS THE MESSAGE ITS WORKING - Situations");

        SituationMessage.SetActive(true);




        //Need a random set of events that switch SituationText
        //an Array of string loops through
        //selects a random string- situation text
        //Which has an attached string  which is then used in YesSituation()

        //Counts number of situations and randomly selects a number and then displays using SituationText and uses the List and the index to get the element
        
        index = ran.Next(randomOccurances.Count);
        SituationText.text = randomOccurances[index].Text;

    }


   
    //Default Add and subtract method - may others may require a Yes method for themselves
    public void YesSituation()
    {
        Debug.Log("THIS IS THE MESSAGE ITS WORKING - Yes to Situations");

        //This is what happens if they say YES to this event above onClick of Yes button
        //Checks if they are relevant to the list
        CharacterCreator.currentHappiness = CharacterCreator.currentHappiness + randomOccurances[index].EffectOnStatAreaHappiness;
        CharacterCreator.currentPlayerCoin = CharacterCreator.currentPlayerCoin - randomOccurances[index].EffectOnStatCoin;
        CharacterCreator.currentThirst = CharacterCreator.currentThirst + randomOccurances[index].EffectOnStatThirst;
        CharacterCreator.currentHealth = CharacterCreator.currentHealth + randomOccurances[index].EffectOnStatHealth;
        CharacterCreator.currentRespect = CharacterCreator.currentRespect + randomOccurances[index].EffectOnStatRespect;
        CharacterCreator.areaHappiness = CharacterCreator.areaHappiness + randomOccurances[index].EffectOnStatAreaHappiness;
        CharacterCreator.currentPopulation = CharacterCreator.currentPopulation + randomOccurances[index].EffectOnStatPopulation;

        SituationMessage.SetActive(false);

    }

    //Default Add and subtract method - may others may require a Yes method for themselves
    public void NoSituation()
    {
        Debug.Log("THIS IS THE MESSAGE ITS WORKING - NO to Situations");

        //THis is what happens if they say NO to this event above onCLick of no button

     
        CharacterCreator.currentHappiness = CharacterCreator.currentHappiness - randomOccurances[index].EffectOnStatAreaHappiness;
        CharacterCreator.currentThirst = CharacterCreator.currentThirst - randomOccurances[index].EffectOnStatThirst;
        CharacterCreator.currentHealth = CharacterCreator.currentHealth - randomOccurances[index].EffectOnStatHealth;
        CharacterCreator.currentRespect = CharacterCreator.currentRespect - randomOccurances[index].EffectOnStatRespect;
        CharacterCreator.areaHappiness = CharacterCreator.areaHappiness - randomOccurances[index].EffectOnStatAreaHappiness;
        CharacterCreator.currentPopulation = CharacterCreator.currentPopulation - randomOccurances[index].EffectOnStatPopulation;

        SituationMessage.SetActive(false);
    }




    




}

