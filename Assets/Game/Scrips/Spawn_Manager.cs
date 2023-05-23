using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyShipPrefab;

    [SerializeField]
    private GameObject[] powerups;
    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager =  Component.FindObjectOfType<GameManager>();

        StartCoroutine(EnemySpawnRoutine());
        StartCoroutine(PowerupSpawnRoutine());

    }

    public void startSpawnRoutines(){

        StartCoroutine(EnemySpawnRoutine());
        StartCoroutine(PowerupSpawnRoutine());
    }

    private IEnumerator EnemySpawnRoutine()
    {

        while (_gameManager.gameOver == false) 
        {
            yield return new WaitForSeconds(5.0f);
            Instantiate(enemyShipPrefab, new Vector3(Random.Range(-7.94f, 7.99f), 8f, 0), Quaternion.identity);
            
        }
    }

    private IEnumerator PowerupSpawnRoutine()
    {
        while (_gameManager.gameOver == false)
        {
            int powerupRandom = Random.Range(0, 3);
            Instantiate(powerups[powerupRandom], new Vector3(Random.Range(-7.94f, 7.99f), 8f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }
    
}
