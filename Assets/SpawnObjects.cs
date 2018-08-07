using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{


    // BASIC SPAWN(NEED MORE Advanced)
    // This allows me to spawn a prefab , no limit (FIX)
    // CUrsor and cube not 100% (FIX)
    // User is able to click anywhere in the screen which is not good

   public PlaceBuilding placeBuilding;
   private Transform currentBuilding;
   public bool hasPlaced;
 

    public LayerMask buildingsMask;
    //public Camera camera;
    //Camera camera = GetComponent<Camera>();


    public PlayersArea playersArea;

    public void Start()
    {
        //Camera camera = GetComponent<Camera>();

    }

    public void Update()
    {

        if(PlayersArea.validInstantiate == true )
        {
            SpawnPrefabMethod();
        }

       
       
    }


    public void SpawnPrefabMethod()
    {
        //try fix  position of prefab as its too much right of the cursor


        Camera camera = GetComponent<Camera>();

        Vector3 m = Input.mousePosition;
        m = new Vector3(m.x, m.y, transform.position.y);
        Vector3 p = camera.ScreenToWorldPoint(m);

        if (currentBuilding != null && !hasPlaced)

            currentBuilding.position = new Vector3(p.x, 0, p.z);


        if (Input.GetMouseButtonDown(0))
        {

            if (islegalPosition())
            {
                // Only place object if its legal placement as in not on top of another.
                hasPlaced = true;
            }

        }





        //THIS is the part were you can select the object we need to do this eventually not 100% working 
        //--------------------------------
        //   else
        //  {

        // Refer -https://www.youtube.com/watch?v=OuqThz4Zc9c

        //  Vector3 m = Input.mousePosition;
        //   m = new Vector3(m.x, m.y, transform.position.y);
        // Vector3 p = camera.ScreenToWorldPoint(m);


        //     if(Input.GetMouseButtonDown(0))
        //    {
        //        RaycastHit hit = new RaycastHit();
        //         Ray ray = new Ray(new Vector3(p.x,8,p.z),Vector3.down);

        //   if(Physics.Raycast(ray,out hit ,Mathf.Infinity , buildingsMask)) //This is when you touch a building / click on 
        //      {
        //   Debug.Log(hit.collider.name);
        //     }
        //   }
        // } 


        //  }

    }

    bool islegalPosition() // collider test
    {

        if (placeBuilding.colliders.Count > 0)
        {
            return false;
        }

        return true;

    }


    public void SetItem(GameObject hut)
    {
       Debug.Log(hut.name);
       hasPlaced = false;

       currentBuilding = ((GameObject)Instantiate(hut)).transform;
       placeBuilding = currentBuilding.GetComponent<PlaceBuilding>();
    }


    public void SetItemWaterWell(GameObject waterWell)
    {
        Debug.Log(waterWell.name);
        hasPlaced = false;

        currentBuilding = ((GameObject)Instantiate(waterWell)).transform;
        placeBuilding = currentBuilding.GetComponent<PlaceBuilding>();
    }

}