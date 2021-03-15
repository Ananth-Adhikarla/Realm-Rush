using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 1f;
    [SerializeField] EnemyMovement enemyPrefab = null;
    [SerializeField] Transform enemyParent = null;
    [SerializeField] Text spawnedEnemies = null;
    int score;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemies());
        spawnedEnemies.text = score.ToString(); 
    }

    IEnumerator RepeatedlySpawnEnemies()
    {
        
        while (true)
        {
            AddScore();
            var enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemy.transform.parent = enemyParent.transform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }

    }

    void AddScore()
    {
        score++;
        spawnedEnemies.text = score.ToString();

    }
}
