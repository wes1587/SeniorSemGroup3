using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void playGame()
    {
        //load next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1); 
    }

    public void quitGame()
    {
        Debug.Log("It worked!");
        Application.Quit();
    }
}
