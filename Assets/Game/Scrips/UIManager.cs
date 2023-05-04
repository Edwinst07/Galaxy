using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Sprite[] lives;
    [SerializeField]
    private Image livesImageDisplay;
    public Text scoreText;
    public int score = 0;
    [SerializeField]
    private Image intro;
    public GameObject titleScreen;

    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update(){ }

    public void UpdateLives(int currentLives)
    {
        livesImageDisplay.sprite = lives[currentLives];
    }

    public void UpdateScore()
    {
        score += 10;
        scoreText.text = "Score: " + score;
    }

    public void ShowTitleScreen()
    {
        titleScreen.SetActive(true);
    }

    public void HideTitleScreen()
    {
        titleScreen?.SetActive(false);
        score = 0;
        scoreText.text = "Score: 0";
    }

}
