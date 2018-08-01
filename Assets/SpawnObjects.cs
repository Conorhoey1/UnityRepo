using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{


    // BASIC SPAWN(NEED MORE Advanced)
    // This allows me to spawn a prefab , no limit (FIX)
    // CUrsor and cube not 100% (FIX)
    // User is able to click anywhere in the screen which is not good



    Vector3 mousePosition, targetPosition;
    public Transform House;

    float distance = 50f;

    public void Update()
    {

        //To get the current mouse position
        mousePosition = Input.mousePosition;

        //Convert the mousePosition according to World position
        targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, distance));

        //Set the position of targetObject
        House.position = targetPosition;

        //Debug.Log(mousePosition+"   "+targetPosition);


        //If Left Button is clicked
        if (Input.GetMouseButtonUp(0))
        {
            //create the instance of targetObject and place it at given position.
            Instantiate(House, House.transform.position, House.transform.rotation);
        }


    }

}