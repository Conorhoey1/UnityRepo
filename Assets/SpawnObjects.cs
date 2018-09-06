using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnObjects : MonoBehaviour
{


    // BASIC SPAWN(NEED MORE Advanced)
    // This allows me to spawn a prefab , no limit (FIX)
    // CUrsor and cube not 100% (FIX)
  // BUG illegal postion and randomally places object

   public PlaceBuilding placeBuilding;
   private Transform currentBuilding;
    public static bool hasPlaced;
    public  bool removeObject = false;
    // public static bool viewObject = false;

    //Random rnd = new Random();


    public  string objectHit;





    public LayerMask buildingsMask;
  //  public Camera cameraSpawn;
    //Camera camera = GetComponent<Camera>();


    public PlayersArea playersArea;
   

    //Random

    //Unity special system random  - Random rnd = new Random() did not have .Next
    public System.Random rnd = new System.Random();

    private float clickTime = 0;
  //  private float clickThreshold = 1f;
    private int clickCount;

   

    void Update()
    {

        ValidInstance();

    }

    public void ValidInstance()
    {
        try
        {
            if (PlayersArea.validInstantiate == true )
            {
                SpawnPrefabMethod();

             //   if (Input.GetMouseButtonDown(0))
             //   {

                //    clickCount++;

                //    if (clickCount == 2)
                 //   {
                        ViewObjectSelected();
                 ///       clickCount = 0;
                 //   }
              //  }
              //  else
              //  {

              //      StartCoroutine(TickDown());

              //  }


            }


        }

        catch (System.NullReferenceException ex)
        {
            Debug.Log("Methods not active");
        }

    }

    public void ViewObjectInstatiate()
    { 

        

        //if(PlayerArea.validUserWantsToSell)
        
           // ViewObjectSelected(); //User able to view object stats/ coins worth of object 
        //if(PlayerArea.validUserWantsToSell)


    }





    public void SpawnPrefabMethod()
    {

        //-------------------- FIX THIS ---------------
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

            // Refer -https://www.youtube.com/watch?v=OuqThz4Zc9c

    }


    public void ViewObjectSelected()
    {


 

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

       




        if (Input.GetMouseButtonDown(0))
         {

           
            clickCount++;
            clickTime = Time.time;

            //if (clickCount >=2 && Time.time < clickCount + clickThreshold)
            if (clickCount >= 3)
            {


           

           // clickTime = 0;

            if (Physics.Raycast(ray, out hit))
                {
                    BoxCollider bc = hit.collider as BoxCollider;

                    if (bc != null)
                    {

                        if (hit.collider.gameObject.tag == "Building")
                        {
                         

                            hit.collider.gameObject.GetComponent<PlaceBuilding>().SetSelected(true);


                            objectHit = gameObject.GetComponent<PlaceBuilding>().name; //Finds the name of the object the user clicks on 
                            clickCount = 0;
                       
                            Debug.Log("ATTTTTTTTTTTTTTTTT");
                            playersArea.onClickViewObject();

                            if (removeObject == true)
                            {
                                Destroy(bc.gameObject);
                            }

                            // }
                        }
                        else
                        {
                            Debug.Log("NOS");
                        }



                    }
                }

            }

         // if (Time.time > clickTime + clickThreshold)
          //  {
                //clickCount= 0;
                //clickTime = 0;
          //  }


        }


        
    }

   






            //  if (hit.collider.gameObject.tag == "Building")
            //  {
            //Debug.Log("tag");
            //hit.collider.gameObject.GetComponent<PlaceBuilding>().SetSelected(true);
            // }

        

        


    

   

    //Bug - you click on the object
    //


   // public void DestoryObjectSelected()
    //{
        //Destorying a prefab on target

     //   if (Input.GetMouseButtonDown(0))
     //   {
            


      //      RaycastHit hit;
       //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            // if (Physics.Raycast(ray,out hit ,Mathf.Infinity , buildingsMask)) //This is when you touch a building / click on 
      //      if (Physics.Raycast(ray, out hit))
      //      {
        //        BoxCollider bc = hit.collider as BoxCollider;

        //        if (bc != null)
        //        {

           //         if (hit.collider.gameObject.tag == "Building")
           //         {
          //              hit.collider.gameObject.GetComponent<PlaceBuilding>().SetSelected(true);

                        //sell button will be on this gui pop up and it will contain are you sure?
                     //   if (PlaceBuilding.isSelectedView == true)
                       // {
                       //     playersArea.onClickViewObject();
                      //  }

                        //Then
            //            Destroy(bc.gameObject);
           //         }
                  
           //     }

            

                //  if (hit.collider.gameObject.tag == "Building")
                //  {
                //Debug.Log("tag");
                //hit.collider.gameObject.GetComponent<PlaceBuilding>().SetSelected(true);
                // }

        //    }

           

    //    }
   // }


  

    public bool islegalPosition() // collider test
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


    public void SetItemWaterWell(GameObject WaterWell)
    {
        Debug.Log(WaterWell.name);
        hasPlaced = false;

        currentBuilding = ((GameObject)Instantiate(WaterWell)).transform;
        placeBuilding = currentBuilding.GetComponent<PlaceBuilding>();
    }

    public void SetItemCrops(GameObject CropsPrefab)
    {
        Debug.Log(CropsPrefab.name);
        hasPlaced = false;

        currentBuilding = ((GameObject)Instantiate(CropsPrefab)).transform;
        placeBuilding = currentBuilding.GetComponent<PlaceBuilding>();
    }

    public void SetItemCow(GameObject CowPrefab)
    {
        Debug.Log(CowPrefab.name);
        hasPlaced = false;

        currentBuilding = ((GameObject)Instantiate(CowPrefab)).transform;

        placeBuilding = currentBuilding.GetComponent<PlaceBuilding>();

    }

    public void SetItemShop(GameObject ShopPrefab)
    {
        Debug.Log(ShopPrefab.name);
        hasPlaced = false;

        currentBuilding = ((GameObject)Instantiate(ShopPrefab)).transform;

        placeBuilding = currentBuilding.GetComponent<PlaceBuilding>();

    }
}

