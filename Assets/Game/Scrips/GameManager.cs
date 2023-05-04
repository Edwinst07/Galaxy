using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public bool gameOver = true;
    [SerializeField]
    private GameObject player;
    private UIManager _uiManager;

    // Start is called before the first frame update
    void Start()
    {
        _uiManager = Component.FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(player, Vector3.zero, Quaternion.identity);
                gameOver = false;
                _uiManager.HideTitleScreen();
            }
        }
        else
        {
            Time.timeScale = 1;
        }


        
    }
}