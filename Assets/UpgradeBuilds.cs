using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]


//Upgrade for all Houses/Roads
public class UpgradeBuilds : MonoBehaviour
{


    //Scripts
    public CharacterCreator ch;
    public StatManager stats;
    // public SpawnObjects spawn;
    public PlayersArea pa;


    //Labels
   // public Text estateNameText;
  //  public Text roadNameText;

    //House - Estate Upgrade
    public static string estateName;
    public static int estatePopulation;
    public static string roadName; //Street/road name  Need to decide
    public static int estateLevel; // This could determine if the estate becomes a village/ town - With population also 

    // Use this for initialization
    public void Start ()
    {
		
	}
	
	// Update is called once per frame
	public void Update ()
    {
        setEstateName();

        setRoadName();

        setEstatePopulation();
	}

    //Estate Name
    public void setEstateName()
    {
        PlayerPrefs.SetString("estateName", estateName);

      //  estateNameText.text = "Estate Name: " + estateName.ToString();
        PlayerPrefs.Save();
    }

    public void getEstateName()
    {
        string estateName = PlayerPrefs.GetString("EstateName");
    }

    //Road Name
    public void setRoadName()
    {
        PlayerPrefs.SetString("RoadName", roadName);

        //roadNameText.text = "Road Name: " + roadName.ToString();
        PlayerPrefs.Save();
    }

    public void getRoadName()
    {
        string roadName = PlayerPrefs.GetString("RoadName");
    }


    //Estate Population
    public void setEstatePopulation()
    {
        PlayerPrefs.SetInt("estatePopulation", estatePopulation);

       // estatePopulationText.text = "Estate Population: " + estatePopulation.ToString();
        PlayerPrefs.Save();
    }

    public void getEstatePopulation()
    {
        string estatePopulation = PlayerPrefs.GetString("EstatePopulation");
    }


    //Estate Level
    public void setEstateLevel()
    {
        PlayerPrefs.SetInt("estateLevel", estateLevel);

        // estatePopulationText.text = "Estate Population: " + estatePopulation.ToString();
        PlayerPrefs.Save();
    }

    public void getEstateLevel()
    {
        string estateLevel = PlayerPrefs.GetString("EstateLevel");
    }

    public void UpgradeHouseBuild()
    {
        //Currently you can only build 12 houses
        //Upgrade after 12 is an estate which all the user to create estate name
        //However the areaLevel most be a certain stage in order to unlock this upgrade
        //Purchase and Create
        //Reset houseCounter(CharacterCreator) , to allow more houses to be built

        //Create Estate Objec
        // --Spawn prefab 
        // --Road prefab

        //Display Text box to allow user to assign string to variable - string estateName;

        //Display Text box to allow user to assign string to variable - string roadName;

        //Benefits of estate - Increase Happiness due to a community
        stats.areaIncreaseHappiness();

        //Make this disappear and appear when user clicks on the object/prefab   -  ---- We could use a button for now



    }

}
