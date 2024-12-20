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
    }
    
    void ScoreChecker1()
    {
        drop = gameObject.GetComponent<TMP_Dropdown>();
        if (gameObject.name == "Dropdown 1" && drop.value == 1)
        {
            gameManager.Scorer();
            gameObject.SetActive(false);
        }
        else if (gameObject.name == "Dropdown 1" && drop.value == 0)
        {
            gameManager.Notice();
        }

        else if (gameObject.name == "Dropdown 3" && drop.value == 1)
        {
            Debug.Log("Correct");
            
            gameObject.SetActive(false);
        }

    }
}
