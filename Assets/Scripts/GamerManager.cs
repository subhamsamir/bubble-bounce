using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems; 

public class GamerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool gameOver;
    public static bool levelCompleted;
    public static bool IsGameStarted;
    public static bool mute = false;


    public GameObject gameOverpane;
    public GameObject Levelcompletepane;
    public GameObject gamePlayPanel;
    public GameObject startMenuPanel;

    public static int currentLevelIndex;
    public Slider gameProgressSlider;
    public TextMeshProUGUI currentLevelText;
    public TextMeshProUGUI nextLevelText;

    public static int numberOfPassedRings;

    private void Awake()
    {
        currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 1);
    }


    void Start()
    {
        Time.timeScale = 1;
        numberOfPassedRings = 0;
        IsGameStarted = gameOver = levelCompleted = false;
    }

    // Update is called once per frame
    void Update()
    {
        //update ui
        currentLevelText.text = currentLevelIndex.ToString();
        nextLevelText.text = (currentLevelIndex + 1).ToString();

        int progress = numberOfPassedRings * 100 / FindObjectOfType<helixManager>().numberofRings;
        gameProgressSlider.value = progress;

        if (Input.GetMouseButtonDown(0) && !IsGameStarted)
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            IsGameStarted = true;
            gamePlayPanel.SetActive(true);
            startMenuPanel.SetActive(false);

        }

        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverpane.SetActive(true);

            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("Level"); 
            }
        }

        if (levelCompleted)
        {
            Time.timeScale = 0;
            Levelcompletepane.SetActive(true);

            if (Input.GetButtonDown("Fire1"))
            {
                PlayerPrefs.SetInt("CurrentLevelIndex", currentLevelIndex + 1);
                SceneManager.LoadScene("Level");
            }
        }
    }
}
