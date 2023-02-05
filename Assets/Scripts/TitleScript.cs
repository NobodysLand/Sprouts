using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    public GameObject audioEffects;

    public void playGame()
    {
        audioEffects.GetComponent<AudioScript>().playOk();
        SceneManager.LoadScene("MainGame");
    }

    public void guideGame()
    {
        audioEffects.GetComponent<AudioScript>().playOk();
        Application.Quit();
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("TitleGame");
    }

}
