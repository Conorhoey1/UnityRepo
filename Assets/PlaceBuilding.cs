using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceBuilding : MonoBehaviour
{
    [HideInInspector]
    public List<Collider> colliders = new List<Collider>(); // Use this for initialization
    public static bool isSelectedView = false;
    public static bool isSelected = false;

    //BUG WITH LEGAL POSITION 

    void OnGUI()
    {
        
    
        if ( isSelected == true)
        {
            //GUI.Button(new Rect(100, 200, 100, 30), name);

            isSelectedView = true; // this will make it true that the user wants to see the object

            //Getting the info that the user wants 
        }
    }
  
        
    

    //Check for colliders 
    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Building")
        {
            colliders.Add(c);
             
        }
    }

    //Check for colliders 
    void OnTriggerExit(Collider c)
    {
        if (c.tag == "Building")
        {
            colliders.Remove(c);
        }
    }

   public void SetSelected(bool s)
    {
        isSelected = s;

    }
}
