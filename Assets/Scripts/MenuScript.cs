using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void Button_PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Button_ExitGame() 
    {
        Application.Quit();
    }
}
