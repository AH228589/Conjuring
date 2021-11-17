using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Loads the main level
    public void NextLevel()
    {
        SceneManager.LoadScene("Game");
    }

    //Brings up the options menu
    public void GameOptions()
    {
        return;
    }

    //Quits the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
