using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyShipPrefab;

    [SerializeField]
    private GameObject[] powerups;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawnRoutine());
        StartCoroutine(PowerupSpawnRoutine());

    }

    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator EnemySpawnRoutine()
    {

        while (true) 
        {
            yield return new WaitForSeconds(5.0f);
            Instantiate(enemyShipPrefab, new Vector3(Random.Range(-7.94f, 7.99f), 8f, 0), Quaternion.identity);
            
        }
    }

    private IEnumerator PowerupSpawnRoutine()
    {
        while (true)
        {
            int powerupRandom = Random.Range(0, 3);
            Instantiate(powerups[powerupRandom], new Vector3(Random.Range(-7.94f, 7.99f), 8f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }

}
