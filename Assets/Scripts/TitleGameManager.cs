using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleGameManager : MonoBehaviour
{

    public AudioSource nextPage;
    public AudioSource previousPage;
    public AudioSource bgMusic;
    public Slider musicFXSlider;
    public Slider soundFXSlider;
    public static float soundFX = 0.7f;
    public static float musicFX = 0.3f;
    public float initialsoundFX;
    public float initialmusicFX;

    // Start is called before the first frame update
    void Start()
    {
        initialmusicFX = musicFX;
        initialsoundFX = soundFX;
        soundFXSlider.value = initialsoundFX;
        musicFXSlider.value = initialmusicFX;
    }

    // Update is called once per frame
    void Update()
    {
        soundFX = soundFXSlider.value;
        musicFX = musicFXSlider.value;
        SoundManagement();
    }
    public void StopBgMusic()
    {
        bgMusic.Pause();
    }

    public void NextAudio()
    {
        nextPage.Play();
    }

    public void PreviousAudio()
    {
        previousPage.Play();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("Level");
    }
    public void SoundManagement()
    {
        bgMusic.volume = musicFX;
        nextPage.volume = soundFX;
        previousPage.volume = soundFX;
    }


}


