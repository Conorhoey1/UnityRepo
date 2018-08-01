using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public SaveGameManager saveGameManager;

    public void onCreateBtn(string scenename)
    {
        Application.LoadLevel(scenename);
    }


    public void Save()
    {
       // characterScript.SavePlayer();
        Debug.Log("game saved");
    }

    public void loadGame(string scenename)
    {
        Application.LoadLevel(scenename);
        saveGameManager.LoadGame();

        Debug.Log("game load");
    }

    public void Exit(string scenename)
    {
        Application.LoadLevel(scenename);
    }

    
}
