using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPos;
    public Text waveCountdownTimerText;

    private float waitTime = 10f;
    private float countdown = 5f;
    private int waveIndex = 0;

    private void Update(){

        if(countdown <= 0f){

            StartCoroutine(SpawnEnemyWave());
            countdown = waitTime;
        }

        countdown -= Time.deltaTime;

        waveCountdownTimerText.text = Mathf.Round(countdown).ToString();
    }

    private IEnumerator SpawnEnemyWave(){

        waveIndex++;

        for(int i = 0; i < waveIndex; i++){

            SpawnEnemy();
            yield return new WaitForSeconds(1f);

        }
    }

    private void SpawnEnemy(){
        Instantiate(enemyPrefab, spawnPos.position, Quaternion.identity);
    }
}
