using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    //public PlayerMovement myPlayer; no longer needed, we change the score differently now
    private int score = 0;

    public TextMeshProUGUI highScoreDisplay;
    public TextMeshProUGUI scoreDisplay;

    public float endTime = 30f;

    const string DIR_DATA = "/Data/";
    const string FILE_HIGH_SCORE = "highScore.txt";
    string PATH_HIGH_SCORE;

    public const string PREF_HIGH_SCORE = "hsScore";

    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            Debug.Log("Score Changed");
            if (score > HighScore)
            {
                HighScore = score;
            }
        }
    }

    int highScore;
    public int HighScore
    {
        get
        {
            //highScore = PlayerPrefs.GetInt(PREF_HIGH_SCORE);
            return highScore;
        }
        set
        {
            highScore = value;

            Directory.CreateDirectory(Application.dataPath + DIR_DATA);
            File.WriteAllText(PATH_HIGH_SCORE, "" + HighScore);

            //PlayerPrefs.SetInt(PREF_HIGH_SCORE, highScore);
        }

    }

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PATH_HIGH_SCORE = Application.dataPath + DIR_DATA + FILE_HIGH_SCORE;
        highScoreDisplay.enabled = false;
        //myPlayer = FindObjectOfType<PlayerMovement>(); no longer used to update score

        if (File.Exists(PATH_HIGH_SCORE))
        {
            HighScore = Int32.Parse(File.ReadAllText(PATH_HIGH_SCORE));
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.text = "Score: " + Score;
        highScoreDisplay.text = "High Score: " + HighScore;

        endTime -= Time.deltaTime; //subtrating delta time from time variable to count down time to 0
        if (endTime <= 0.0f)
        {
            if (highScoreDisplay != null)
            {
                highScoreDisplay.enabled = true;
            }
        }
    }
}