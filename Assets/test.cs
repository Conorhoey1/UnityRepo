using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour {


    public static int currentPopulation;
    public Text populationText;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        setAreaPopulation();
    }


    public void setAreaPopulation()
    {
        PlayerPrefs.SetInt("Population", currentPopulation);

        populationText.text = "Population:" + CharacterCreator.currentPopulation.ToString();

        //XP generation so that its based on winning challenges or something?
        //check rule so like what you can build / unlock at your players level

        PlayerPrefs.Save();

    }
    public void getAreaPopulation()
    {
        int currentPopulation = PlayerPrefs.GetInt("Population");
    }

}
