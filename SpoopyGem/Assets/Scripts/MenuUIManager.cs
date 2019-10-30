using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    public enum Scenes
    {
        START,
        MENU,
        GAME,
        END
    }

    public void StartButton()
    {
        SceneManager.LoadScene((int)Scenes.GAME);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
