using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("game_level1",LoadSceneMode.Single);
       

    }

    public void ExitGame()
    {

        Application.Quit();
       
    }
}
