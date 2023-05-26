using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isCoopMode = false;
    public bool gameOver = true;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject player_1;
    [SerializeField]
    private GameObject player_2;
    private UIManager _uiManager;
    private Animator _pauseMenuAnimator;
    private Pause_Menu _pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        _uiManager = Component.FindObjectOfType<UIManager>();
        //_pauseMenu = Component.FindObjectOfType<Pause_Menu>();
    }

    // Update is called once per frame
    void Update()
    {
        startGame();
        
    }

    private void startGame(){
        if(gameOver)
        {
            
            if (Input.GetKeyDown(KeyCode.Space))
            {

                if(!isCoopMode){
                    Instantiate(player, Vector3.zero, Quaternion.identity);
                }else{
                    Instantiate(player_1, new Vector3(3.37f, 0, 0), Quaternion.identity);
                    Instantiate(player_2, new Vector3(-3.82f, 0, 0), Quaternion.identity);

                }
                
                gameOver = false;
                _uiManager.HideTitleScreen();
                
            }else if(Input.GetKeyDown(KeyCode.Escape)){
                SceneManager.LoadScene("Main_Menu");
            }
        }
        
        if(Input.GetKeyDown("p")){ 

            _uiManager.showPausePanel();
            //_pauseMenu.pauseAnimation();
            Time.timeScale = 0;
        }
       

    }

    void OnLevelWasLoaded(int level){
        string levelName = Application.loadedLevelName;
        //Debug.Log(levelName);

        if(levelName == "Co-op Mode"){

            isCoopMode = true;

        }
    }

}
