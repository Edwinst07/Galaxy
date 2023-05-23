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
    public GameObject titleScreen;
    [SerializeField]
    private GameObject panelPause;

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
        titleScreen.SetActive(false);
        score = 0;
        scoreText.text = "Score: 0";
    }

    public void showPausePanel(){

        panelPause.SetActive(true);
    }

    public void hidePausePanel(){

        panelPause.SetActive(false);
    }

    public void resume(){

        hidePausePanel();
        Time.timeScale = 1;

    }

    public void backToMainMenu(){

        SceneManager.LoadScene("Main_Menu");
    }

}
