using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public static EnemyPool instance;
    public List<GameObject> enemyList;
    public int amoutEnemy;
    public GameObject enemyPrefab;

    private void Awake() {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Start() {
        InitEnemy();
    }
    private void InitEnemy()
    {
        for(int i = 0; i < amoutEnemy;i++ )
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            enemyList.Add(enemy);
        }
    }
    public void DisableEnemies(){
        for(int i = 0; i < enemyList.Count; i++)
        {
            // Destroy(enemyList[i]);
            enemyList[i].SetActive(false);
        }
    }
    public GameObject GetPooledEnemy(){
        for(int i = 0; i < enemyList.Count; i++) {
            if(!enemyList[i].activeInHierarchy)
            {
                return enemyList[i];
            }   
        }
        return null;
    }
}
