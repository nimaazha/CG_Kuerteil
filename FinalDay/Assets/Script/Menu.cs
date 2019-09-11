using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    
    /*
     * this class provides the functions to main menu 
     */

    public void Play()
    {
        SceneManager.LoadScene(1);
        
        //Set Cursor to not be visible
        Cursor.visible = false;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
