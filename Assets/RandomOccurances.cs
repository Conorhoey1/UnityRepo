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

    //List for Situation - Stores 2 Strings
    List<RandomOccurances> randomOccurances = new List<RandomOccurances>();


    //Unity special system random  - Random rnd = new Random() did not have .Next
    public System.Random ran = new System.Random(); // 

    public void Start ()
    {
        Invoke("AttackOnPlayer", (Random.Range(minRespawn, maxRespawn)));
        Invoke("Situations" , (Random.Range(minRespawn,maxRespawn)));


        SituationMessage.SetActive(false);

        //Possible Situations
        randomOccurances.Add(new RandomOccurances { SituationType = "YEp", Text = "ff" });
        randomOccurances.Add(new RandomOccurances { SituationType = "YEp1", Text = "ff1" });
        randomOccurances.Add(new RandomOccurances { SituationType = "YEp", Text = "ff2" });



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
        int index;
        index = ran.Next(randomOccurances.Count);
        SituationText.text = randomOccurances[index].Text;

    }

    public void YesSituation()
    {
        Debug.Log("THIS IS THE MESSAGE ITS WORKING - Yes to Situations");

        //THis is what happens if they say no to this event above onClick of Yes button


        //Different situations - string value used to determine the situation


        // CharacterCreator.currentHappiness = CharacterCreator.currentHappiness + 5;
    }





    public void NoSituation()
    {
        Debug.Log("THIS IS THE MESSAGE ITS WORKING - NO to Situations");

        //THis is what happens if they say no to this event above onCLick of no button
    }




    




}

