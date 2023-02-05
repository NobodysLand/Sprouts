using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float panSpeed = 10f;

    public GameObject overlay;
    public GameObject map;
    public GameObject optionsModal;
    public GameObject guideModal;
    private GameObject territoryManager;
    private GameObject finaltree;
    public bool dragging = false;

    private float timer = 0;
    public float remaningTime = 300;

    private void Awake()
    {
        territoryManager = GameObject.Find("TerritoryManager");
        finaltree = GameObject.Find("FinalTree");
    }
    void Update()
    {
        timer += Time.deltaTime;
        endGame();
        RectTransform mapRectTransform = map.GetComponent<RectTransform>();
        float screenLimit = 0;
        if (mapRectTransform.localScale.x == 1)
            screenLimit = (0.8f * mapRectTransform.localScale.x);
        if (mapRectTransform.localScale.x == 2)
            screenLimit = (1.6f * mapRectTransform.localScale.x);
        if (mapRectTransform.localScale.x == 3)
            screenLimit = (1.8f * mapRectTransform.localScale.x);

        mapLimit(mapRectTransform, screenLimit);
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            float value = mapRectTransform.localScale.x + (Input.GetAxis("Mouse ScrollWheel") * panSpeed);

            if (value > 3)
                value = 3;
            if (value < 1)
                value = 1;

            mapRectTransform.localScale = new Vector3(value, value, value);
        }

        if (Input.GetMouseButton(0) && !dragging) // right mouse button
        {
            var newPosition = new Vector3();
            newPosition.x = (Input.GetAxis("Mouse X") * panSpeed * Time.deltaTime) * -1;
            newPosition.y = (Input.GetAxis("Mouse Y") * panSpeed * Time.deltaTime) * -1;
            // translates to the opposite direction of mouse position.
            mapRectTransform.Translate(-newPosition);
            mapLimit(mapRectTransform, screenLimit);
        }
    }

    private void mapLimit(RectTransform mapRectTransform, float screenLimit)
    {
        if (mapRectTransform.position.x > screenLimit)
        {
            mapRectTransform.position = new Vector3(screenLimit, mapRectTransform.position.y, mapRectTransform.position.z);
        }
        if (mapRectTransform.position.x < -screenLimit)
        {
            mapRectTransform.position = new Vector3(-screenLimit, mapRectTransform.position.y, mapRectTransform.position.z);
        }
        if (mapRectTransform.position.y > screenLimit)
        {
            mapRectTransform.position = new Vector3(mapRectTransform.position.x, screenLimit, mapRectTransform.position.z);
        }
        if (mapRectTransform.position.y < -screenLimit)
        {
            mapRectTransform.position = new Vector3(mapRectTransform.position.x, -screenLimit, mapRectTransform.position.z);
        }
    }

    public void pauseGame()
    {
        if (Time.timeScale == 1)
        {
            overlay.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            overlay.SetActive(false);
            Time.timeScale = 1;
        }

    }

    public void guideGame()
    {
        if (guideModal.activeSelf)
        {
            guideModal.SetActive(false);
            return;
        }
        guideModal.SetActive(true);
    }

    public void configGame()
    {
        if (optionsModal.activeSelf)
        {
            optionsModal.SetActive(false);
            return;
        }
        optionsModal.SetActive(true);

    }

    public void mainMenu()
    {
        SceneManager.LoadScene("TitleGame");
    }

    public void quit()
    {
        Application.Quit();
    }

    public void endGame()
    {
        if(timer > 74)
        {
            GetComponent<AudioSource>().pitch += 0.2f;
            remaningTime -= timer;
            timer = 0;
        }

        if(remaningTime < 0)
        {
            SceneManager.LoadScene("GameOver");
        }

    }

    public void winGame()
    {
        if (finaltree.GetComponent<Territory>().territoryTaken)
        {
            SceneManager.LoadScene("EndGame");
        }
    }

}
