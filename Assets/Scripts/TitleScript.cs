using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{

    public void playGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void guideGame()
    {
        Application.Quit();
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
