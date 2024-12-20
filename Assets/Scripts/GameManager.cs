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
    public Slider musicFXSlider;
    public Slider soundFXSlider;
    public float soundFX;
    public float musicFX;
    private GameObject[] dropdown;
    public GameObject[] notice;
    private int dropCount;
    private int scorePoints;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        dropdown = GameObject.FindGameObjectsWithTag("Dropdowns");
        dropCount = dropdown.Length;
        Debug.Log(dropCount + " dropdowns left");
        AudioSetup();
        scorePoints = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TitleGameManager.soundFX = soundFXSlider.value;
        TitleGameManager.musicFX = musicFXSlider.value;
        SoundManagement();
        Debug.Log(scorePoints);        
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

    //function to Quit Game to desktop
    public void QuitGame()
    {
        Application.Quit();
    }

    //Function to load Level scene
    public void LoadLevel()
    {
        SceneManager.LoadScene("Level");
    }

    //Sound settings mapped to sliders in the options menu
    public void SoundManagement()
    {
        bgMusic.volume = TitleGameManager.musicFX;
        previousPage.volume = TitleGameManager.soundFX;
        click.volume = TitleGameManager.soundFX;
        detective.volume = TitleGameManager.soundFX;
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
        Instantiate(notice[0], gameObject.transform);
    } 
}
