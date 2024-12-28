using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Level2GameManager : MonoBehaviour
{

    public AudioSource previousPage;
    public AudioSource click;
    public AudioSource bgMusic;
    public AudioSource detective;
    public AudioSource notification;
    public AudioSource timerNotice;
    public AudioSource correct;
    public Slider musicFXSlider;
    public Slider soundFXSlider;
    public float soundFX;
    public float musicFX;
    private GameObject[] dropdown;
    private int dropCount;
    private int scorePoints;
    public TextMeshProUGUI scoreText;
    public GameObject message1;
    public GameObject message2;
    public GameObject message3;
    public GameObject message4;    
    public float totalTime;
    public bool start;
    public GameObject timeNotice;
    public GameObject wrongNotice;
    public GameObject noAnswerNotice;
    public GameObject toolsNotice;
    public GameObject gameOver;
    public TextMeshProUGUI timerText;
    private float timeRemaining = 60.0f;  // Set timer to 60 seconds (example)
    private bool isTimerRunning = true;  // Flag to control the timer
    public GameObject passed;

    void Start()
    {
        dropdown = GameObject.FindGameObjectsWithTag("Dropdowns");
        dropCount = dropdown.Length;
        Debug.Log(dropCount + " dropdowns left");
        AudioSetup();
        scorePoints = 0;
        start = false;
        totalTime = 300;
        Time.timeScale = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        TitleGameManager.soundFX = soundFXSlider.value;
        TitleGameManager.musicFX = musicFXSlider.value;
        SoundManagement();
        Debug.Log(scorePoints);
        StartCoroutine(Chatsequence());
        ToolsNotice();
        timerText.text = totalTime.ToString();
        TimerSetup();
    }

    // Function to play click sound upon clicking next button
    public void Click()
    {
        click.Play();
    }

    // Function to play pageflip sound upon clicking back button
    public void PreviousAudio()
    {
        previousPage.Play();
    }

    //Music playing in the title menu (Title scene)
    public void BGMusic()
    {
        bgMusic.Play();
    }
    public void DetectiveMode()
    {
        detective.Play();
    }

    public void TimerNoticeSound()
    {
        timerNotice.Play();
    }

    public void CorrectSound()
    {
        correct.Play();
    }

    public void Warning()
    {
        notification.Play();
    }

    //function to Quit Game to desktop
    public void QuitGame()
    {
        Application.Quit();
    }

    //Function to load Level scene
    public void LoadLevel()
    {
        SceneManager.LoadScene("Level 2");
        GameStart();
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level 2");
        GameStart();
    }

    //Sound settings mapped to sliders in the options menu
    public void SoundManagement()
    {
        bgMusic.volume = TitleGameManager.musicFX;
        previousPage.volume = TitleGameManager.soundFX;
        click.volume = TitleGameManager.soundFX;
        detective.volume = TitleGameManager.soundFX;
        notification.volume = TitleGameManager.soundFX;
        correct.volume = TitleGameManager.soundFX;
    }

    //Function to reload Title Scene
    public void LoadTitleScene()
    {
        SceneManager.LoadScene("Title Scene");
    }
    public void Scorer()
    {
        scorePoints++;
        scoreText.text = "Right Choices: " + scorePoints;
    }

    public void Success()
    {
        if (dropCount == 0)
        {
            Debug.Log("Success");
        }
    }
    void AudioSetup()
    {
        soundFX = TitleGameManager.soundFX;
        musicFX = TitleGameManager.musicFX;
        soundFXSlider.value = soundFX;
        musicFXSlider.value = musicFX;
    }

    public void Notice()
    {
        Warning();
    }

    public void Mistake()
    {
        Warning();
    }


    IEnumerator Chatsequence()
    {
        if (start == true)
        {
            message1.SetActive(true);
            yield return new WaitForSeconds(1);
            message2.SetActive(true);
            yield return new WaitForSeconds(2);
            message3.SetActive(true);
            yield return new WaitForSeconds(1);
            message4.SetActive(true);                       
        }
    }
    public void Progress()
    {
        if (scorePoints > 2)
        {
            Passed();
        }

        else
        {
            GameOver();
        }
    }
    public void Passed()
    {
        passed.SetActive(true);
        Time.timeScale = 0;        
    }

    void UpdateTimerDisplay()
    {
        // Format the time as minutes:seconds (e.g., 01:30)
        float minutes = Mathf.Floor(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void TimerSetup()
    {
        // Check if the timer is running
        if (isTimerRunning)
        {
            // Decrease the timer by time passed in each frame (deltaTime)
            timeRemaining -= Time.deltaTime;

            // If time is up, stop the timer and trigger game over logic
            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                isTimerRunning = false;  // Stop the timer
                // You can trigger any game over actions here, such as:
                GameOver();
            }

            else if (timeRemaining <= 60)
            {
                TimeNotice();
            }

            // Update the UI text with the remaining time
            UpdateTimerDisplay();
        }

    }

    public void GameStart()
    {
        start = true;
        Time.timeScale = 1.0f;
    }
    public void Pause()
    {
        Time.timeScale = 0.0f;
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
    }

    public void NoAnswerNotice()
    {
        Warning();
        noAnswerNotice.SetActive(true);
    }
    public void TimeNotice()
    {
        Warning();
        timeNotice.SetActive(true);
    }
    public void WrongAnswerNotice()
    {
        Warning();
        noAnswerNotice.SetActive(true);
    }
    public void ToolsNotice()
    {
        if (start)
        {
            Warning();
            toolsNotice.SetActive(true);
        }
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0;
    }
}

    
