using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingScript : MonoBehaviour
{
    public GameObject fish;
   // public Transform fish;

    // Fish Movement Variables
    public static int movespeed = 4;
    public Vector3 userDirection = Vector3.right;
    public static int FishCount = 1;
    public static bool offScreen = false;

    //Unity special system random  - Random rnd = new Random() did not have .Next
    public System.Random ran = new System.Random(); // 

    // Use this for initialization
    void Start () {


    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(userDirection * movespeed * Time.deltaTime);
        ///  Instantiate(fish);
        ///  

        if (FishCount < 10 && offScreen == true)
        {
            {
                Instantiate(fish);
                FishCount++;
                offScreen = false;
                fish.gameObject.SetActive(true);

            }
        }

        else
        {
            Debug.Log("NOOOOSSS");
        }

    }


    void OnBecameInvisible() 
    {
        // This method will destroy this gameobject when off screen
        fish.gameObject.SetActive(false);
        offScreen = true;

    }
}
