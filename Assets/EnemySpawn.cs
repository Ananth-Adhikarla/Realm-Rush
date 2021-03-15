using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemySpawn : MonoBehaviour
{
    float gamestart = 5f;
    float nextWave = 30f;
   
    float duckSpawn = 1.5f;
    float catSpawn = 2f;
    float SheepSpawn = 2.2f;
    float penguinSpawn = 4f;



    [SerializeField] GameObject Cat = null;
    [SerializeField] GameObject Duck = null;
    [SerializeField] GameObject Sheep = null;
    [SerializeField] GameObject Penguin = null;

    [SerializeField] Transform enemyParent = null;
    public Text spawnedEnemies = null;
    public Text WaveNumber = null;
    [SerializeField] Snapper startPos = null;

    public int score;

    int waveCount = 0;
    public bool wave1 = false;
    public bool wave2 = false;
    public bool wave3 = false;
    bool finalWave = false;
    bool WaveDone = false;

    EnemyDamage enemy;

    //todo make func for each animal ;

    // Start is called before the first frame update
    void Start()
    {        
        StartCoroutine(SpawnWave());
    }

    private void Update()
    {
        WaveText();
        EndGame();
    }


    IEnumerator SpawnWave()
    {

        // Wait 5 secs before starting Wave 1
        yield return new WaitForSeconds(gamestart);

        waveCount = 1;
        // Start Wave 1
        Wave1();

        // wait 25 secs before start+ing Wave2
        yield return new WaitForSeconds(nextWave);

        wave1 = true;

        waveCount = 2;
        // start wave 2 ducks
        Wave2A();

        // wait 10 secs
        yield return new WaitForSeconds(10f);

        // start wave 2 cats
        Wave2B();

        yield return new WaitForSeconds(nextWave + 5f);

        wave2 = true;

        waveCount = 3;
        //Start Wave3

        Wave3A();

        yield return new WaitForSeconds(14f);

        Wave3B();

        yield return new WaitForSeconds(20f);

        Wave3C();

        yield return new WaitForSeconds(nextWave + 20f);

        wave3 = true;

        waveCount = 4;

        Wave4A();

        yield return new WaitForSeconds(25f);

        Wave4B();

        yield return new WaitForSeconds(20f);

        Wave4C();

        yield return new WaitForSeconds(35.5f);

        Wave4D();
    }

    void Wave1()
    {
        StartCoroutine(SpawnAnimal(Cat, 10 , catSpawn));
    }

    void Wave2A()
    {
        StartCoroutine(SpawnAnimal(Duck, 5 , duckSpawn));
    }

    void Wave2B()
    {
        StartCoroutine(SpawnAnimal(Cat, 10 , catSpawn));
    }

    void Wave3A()
    {
        StartCoroutine(SpawnAnimal(Duck, 10 , duckSpawn));
    }

    void Wave3B()
    {

     StartCoroutine(SpawnAnimal(Cat, 10 , catSpawn));
    }

    void Wave3C()
    {
        StartCoroutine(SpawnAnimal(Sheep, 15 , SheepSpawn));
    }

    void Wave4A()
    {
        StartCoroutine(SpawnAnimal(Duck, 15 , duckSpawn));
    }

    void Wave4B()
    {
        StartCoroutine(SpawnAnimal(Cat, 10 , catSpawn));
    }
    void Wave4C()
    {
        StartCoroutine(SpawnAnimal(Sheep, 15 , SheepSpawn));
    }
    void Wave4D()
    {
        // condition for final wave
        StartCoroutine(SpawnAnimal(Penguin, 5 , penguinSpawn));
        finalWave = true;
    }

    IEnumerator SpawnAnimal(GameObject obj, int num , float secondsBetweenSpawns)
    {
        var count = num ;
        for(int i = 0; i < num; i++)
        {
            MakeAnimal(obj);
            yield return new WaitForSeconds(secondsBetweenSpawns );
        }

        WaveDone = true;
    }

    private void MakeAnimal(GameObject obj)
    {
        Vector3 pos = new Vector3(startPos.transform.position.x, 10, startPos.transform.position.z);
        //AddScore();
        var enemy = Instantiate(obj, pos, obj.transform.rotation);
        enemy.SetActive(true);
        enemy.transform.parent = enemyParent.transform;
    }

    public void AddScore()
    {
        //score ++;
        //print(score);
        spawnedEnemies.text = score.ToString();

    }

    public void WaveText()
    {
        WaveNumber.text = "Wave " +waveCount.ToString();
    }

    public void EndGame()
    {
        var player = GameObject.Find("Environment").GetComponentInChildren<PlayerHealth>();
        var enemiesLeft = GameObject.Find("Enemies").GetComponentInChildren<EnemyDamage>();

        if (player.health <= 0)
        {
            StopAllCoroutines();
            Invoke("FinalScene", 2f);
        }
        else if (finalWave == true && enemiesLeft == null)
        {
            StopAllCoroutines();
            Invoke("FinalScene", 2f);
        }
        else;
        {
            // game goes on do nothing
        }
        
    }

    public void FinalScene()
    {
        SceneManager.LoadScene(2);
    }

}
