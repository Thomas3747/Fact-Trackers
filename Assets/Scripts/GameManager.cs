using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public AudioSource previousPage;
    public AudioSource click;
    public AudioSource bgMusic;
    public AudioSource detective;
    public AudioSource notification;
    public AudioSource timerNotice;
    public AudioSource error;
    public AudioSource correctAnswer;
    public AudioSource messageTone;
    public Slider musicFXSlider;
    public Slider soundFXSlider;
    public float soundFX;
    public float musicFX;
    private GameObject[] dropdown;
    private int dropCount;
    private int scorePoints;
    private int attempts;
    public TextMeshProUGUI attemptText;
    public TextMeshProUGUI scoreText;
    public GameObject message1;
    public GameObject message2;
    public GameObject message3;
    public GameObject message4;
    public GameObject message5;
    public GameObject message6;
    public GameObject passed;
    public GameObject messageNotification;
    public Button tools;
    public float totalTime;
    public bool chatStart = false;
    public GameObject timeNotice;
    public GameObject wrongAnswerNotice;
    public GameObject noAnswerNotice;
    public GameObject toolsNotice;
    public GameObject gameOver;
    public TextMeshProUGUI timerText;
    private float timeRemaining = 180.0f;  // Set timer to 60 seconds (example)
    private bool isTimerRunning = true;  // Flag to control the timer
    public bool detectiveMode = false;
    public float fourSeconds = 4;
    public float threeSeconds = 3;
    public float twoSeconds = 2;
    public float oneSecond = 1;

    // Start is called before the first frame update
    void Start()
    {
        AudioSetup();
        scorePoints = 0;
        totalTime = 300;
        Time.timeScale = 0.0f;
        chatStart = false;
        StartCoroutine(StartHint());
    }

    // Update is called once per frame
    void Update()
    {
        TitleGameManager.soundFX = soundFXSlider.value;
        TitleGameManager.musicFX = musicFXSlider.value;
        SoundManagement();
        StartCoroutine(Chatsequence());
        timerText.text = totalTime.ToString();
        TimerSetup();
        ModeChecker();
    }

    IEnumerator StartHint()
    {
        yield return new WaitForSeconds(twoSeconds);
        MessageTone();
        messageNotification.SetActive(true);
        yield return new WaitForSeconds(fourSeconds);
        toolsNotice.SetActive(true);
        notification.Play();        
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
    //function to play once, the detective mode sound
    public void DetectiveMode()
    {
        detective.Play();        
        detectiveMode = true;
    }

    public void MessageTone()
    {
        messageTone.Play();
    }

    public void NormalMode()
    {
        Click();
        detectiveMode = false;
    }

    public void ModeChecker()
    {
        if(detectiveMode == true)
        {
            dropdown = GameObject.FindGameObjectsWithTag("Dropdowns");
            dropCount = dropdown.Length;            
        }
    }
    //function to play once, the "time running out" sound
    public void TimerNoticeSound()
    {
        timerNotice.Play();
    }
    //function to play once, the correct answer sound
    public void CorrectSound()
    {
        correctAnswer.Play();        
    }
    //function to play once, the warning sound
    public void Warning()
    {
        notification.Play();
    }

    //function to Quit Game to desktop
    public void QuitGame()
    {
        Application.Quit();
    }

    //Function to load Level scene (main level 1)
    public void LoadLevel()
    {
        SceneManager.LoadScene("Level");
        GameStart();
    }
    //Function to load Level 2 scene (main level 2)
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
        correctAnswer.volume = TitleGameManager.soundFX;
        error.volume = TitleGameManager.soundFX;
        messageTone.volume = TitleGameManager.soundFX;
    }

    //Function to reload Title Scene
    public void LoadTitleScene()
    {
        SceneManager.LoadScene("Title Scene");
    }
    //Function to update score when a correct answer is given
    public void Scorer()
    {
        scorePoints++;
        scoreText.text = "Right Choices: " + scorePoints;
        Attempts();
    }

    public void Attempts()
    {
        attempts++;
        attemptText.text = "/ " + attempts;
    }

    public void Success()
    {
        if (dropCount == 0)
        {
            Debug.Log("Success");
        }
    }
    //Audio control settings
    void AudioSetup()
    {
        soundFX = TitleGameManager.soundFX;
        musicFX = TitleGameManager.musicFX;
        soundFXSlider.value = soundFX;
        musicFXSlider.value = musicFX;
    }
    //function to play once, the notice sound
    public void Notice()
    {
        Warning();
    }
    //function to play once, the wrong answer sound
    public void Mistake()
    {
        error.Play();
    }
    public void ChatStart()
    {
        chatStart = true;
    }

    //function to control the flow of messages in your chat room
    IEnumerator Chatsequence()
    {
        if (chatStart == true)
        {            
            message1.SetActive(true);            
            message2.SetActive(true);
            yield return new WaitForSeconds(oneSecond);            
            message3.SetActive(true);
            yield return new WaitForSeconds(oneSecond);            
            message4.SetActive(true);
            yield return new WaitForSeconds(oneSecond);            
            message5.SetActive(true);
            yield return new WaitForSeconds(oneSecond);            
            message6.SetActive(true);
            tools.interactable = true;            
        }
    }

    //function to check if player can progress to the next level
    //Scorepoints must be greater than 2 to pass which is equivalent to value of the variable twoSeconds
    public void Progress()
    {
        if (detectiveMode == true)

        {
            if (attempts == 3)
            {
                if (scorePoints > twoSeconds)
                {
                    Passed();
                }

                else if (scorePoints < twoSeconds)
                {
                    GameOver();
                }
            }

            else
            {
                timeNotice.SetActive(false);
                noAnswerNotice.SetActive(false);
                toolsNotice.SetActive(false);
                NoAnswerNotice();
            }
        }

        else
        {
            timeNotice.SetActive(false);
            noAnswerNotice.SetActive(false);
            noAnswerNotice.SetActive(false);
            ToolsNotice();
        }
    }

    //function to progress player to next level upon button click
    public void Passed()
    {
        passed.SetActive(true);
    }
    //Game Timer setup
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

            else if (timeRemaining < 60 && timeRemaining > 0)
            {
                TimeNotice();
            }

            // Update the UI text with the remaining time
            UpdateTimerDisplay();
        }

    }

    public void GameStart()
    {
        Time.timeScale = 1.0f;
        chatStart = false;
    }

    //This function stops the flow of time in the Game
    public void Pause()
    {
        Time.timeScale = 0.0f;
    }

    //This function restores the flow of time in the Game 
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
        Mistake();        
        noAnswerNotice.SetActive(false);
        toolsNotice.SetActive(false);
        timeNotice.SetActive(false);
    }
    public void ToolsNotice()
    {
        Warning();
        toolsNotice.SetActive(true);
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0;
    }
}
