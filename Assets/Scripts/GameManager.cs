using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool levelCompleted;

    public GameObject GameOverPanel;
    public GameObject LevelCompletedPanel;

    public static int currentLevelIndex;
    public static int numberOfPassedBlocks;

    public Slider progressSlider;
    public static int playerColor; //red0, green1, blue2

    public static string playerTag;

    void Awake()
    {
        currentLevelIndex = PlayerPrefs.GetInt("currentLevelIndex", 1);
        playerTag = PlayerPrefs.GetString("playerTag", "Green");
        playerColor = PlayerPrefs.GetInt("playerColor", 1);
    }


    void Start()
    {
        Time.timeScale = 1;
        numberOfPassedBlocks = 0;
        gameOver = levelCompleted = false;
    }

    void Update()
    {
        //Current Level Info
        /* currentLevelText.text = currentLevelIndex.ToString();
        nextLevelText.text = (currentLevelIndex + 1).ToString(); */
        
        //Progress Bar
        int progress = numberOfPassedBlocks * 100 / FindObjectOfType<BlockSpawner>().numberOfBlocks;
        progressSlider.value = progress;

        //Levels
        if (gameOver == true)
        {
            Time.timeScale = 0;
            GameOverPanel.SetActive(true);

            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene(1);
            }
        }

        if (levelCompleted == true)
        {
            Time.timeScale = 0;
            LevelCompletedPanel.SetActive(true);

            if (Input.GetButtonDown("Fire1"))
            {
                PlayerPrefs.SetInt("currentLevelIndex", currentLevelIndex + 1);
                SceneManager.LoadScene(1);
            }
        }
    }
}
