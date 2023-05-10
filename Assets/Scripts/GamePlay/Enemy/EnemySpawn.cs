using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public int timeLimit = 30;
    private float _spawnDelay;
    public float spawnDelay;
    public GameObject bossPrefab;
    private void Start() {
        _spawnDelay = spawnDelay;
        StartCoroutine(TimeCountDown());
    }
    private void Update() {
        // StartCoroutine(SpawnEnemy());
        _spawnDelay -= Time.deltaTime;
        if(timeLimit > 0 && _spawnDelay <= 0 && EnemyPool.instance.GetPooledEnemy() != null)
        {
            StartCoroutine(SpawnEnemy());
            _spawnDelay = spawnDelay;
        }

        if(timeLimit <= 0)
        {
            EnemyPool.instance.DisableEnemies();
            StopCoroutine(SpawnEnemy());
        }
    }
    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(spawnDelay);
        GameObject _enemy = EnemyPool.instance.GetPooledEnemy();
        if(_enemy != null)
        {
            Vector2 spawnPos = PlayerController.instance.GetPosPlayer();
            spawnPos += Random.insideUnitCircle.normalized * 5;

            _enemy.transform.position = spawnPos;
            _enemy.SetActive(true);
        }
    }
    IEnumerator TimeCountDown(){
        while(timeLimit > 0)
        {
            yield return new WaitForSeconds(1f);
            timeLimit--;
            if(timeLimit < 2)
            {
                AudioManager.instance.PlaySFX("Warning");
            }
            if(timeLimit <= 0)
            {
                Vector2 spawnPos = PlayerController.instance.GetPosPlayer();
                spawnPos = Random.insideUnitCircle.normalized * 5;
                GameObject eyeBoss = Instantiate(bossPrefab, spawnPos, Quaternion.identity);
            }
            UIGameManager.instance.UpdateTime(IntToTime(timeLimit));
        }
        
    }
    public string IntToTime(int time){
        float minutes = Mathf.Floor(time / 60);
        float seconds = Mathf.RoundToInt(time % 60);
        return minutes.ToString("00") + " : " + seconds.ToString("00");
    }
}
