using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class Dropdowns : MonoBehaviour
{
    private TMP_Dropdown drop;
    public GameManager gameManager;
    private int scorePoints;
    public TextMeshProUGUI scoreText;
    public GameObject wrongNotice;
    public GameObject noAnswerNotice;

    // Start is called before the first frame update
    void Start()
    {
        drop = gameObject.GetComponent<TMP_Dropdown>();
        gameManager = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreChecker1();
        ScoreChecker2();
        ScoreChecker3();
    }

    public void ScoreChecker1()
    {
        drop = gameObject.GetComponent<TMP_Dropdown>();
        if (gameObject.name == "Dropdown 1" && drop.value == 1)
        {
            Scorer();
            gameObject.SetActive(false);
        }
        else if (gameObject.name == "Dropdown 1" && drop.value == 0)
        {
            NoAnswerNotice();
        }

        else if (gameObject.name == "Dropdown 1" && drop.value == 2)
        {
            WrongAnswerNotice();
            gameObject.SetActive(false);
        }
    }

    public void ScoreChecker2()
    {
        drop = gameObject.GetComponent<TMP_Dropdown>();
        if (gameObject.name == "Dropdown 2" && drop.value == 1)
        {
            Scorer();
            gameObject.SetActive(false);
        }
        else if (gameObject.name == "Dropdown 2" && drop.value == 0)
        {
            NoAnswerNotice();
        }

        else if (gameObject.name == "Dropdown 2" && drop.value == 2)
        {
            WrongAnswerNotice();
            gameObject.SetActive(false);
        }
    }

    public void ScoreChecker3()
    {
        drop = gameObject.GetComponent<TMP_Dropdown>();
        if (gameObject.name == "Dropdown 2" && drop.value == 1)
        {
            WrongAnswerNotice();
            gameObject.SetActive(false);
        }
        else if (gameObject.name == "Dropdown 2" && drop.value == 0)
        {
            NoAnswerNotice();
        }

        else if (gameObject.name == "Dropdown 2" && drop.value == 2)
        {
            Scorer();
            gameObject.SetActive(false);
        }
    }

    public void Scorer()
    {
        scorePoints++;
        scoreText.text = "Right Choices: " + scorePoints;
    }
    public void NoAnswerNotice()
    {
        
        noAnswerNotice.SetActive(true);
    }
    public void WrongAnswerNotice()
    {
        
        noAnswerNotice.SetActive(true);
    }
}
