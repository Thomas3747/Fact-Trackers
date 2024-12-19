using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioSource nextPage;
    public AudioSource previousPage;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
}
