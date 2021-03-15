using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem deathFX = null;
    [SerializeField] ParticleSystem EndGoal = null;

    public string EnemyName;
    public int score;
    int duckScore = 5;
    int catScore= 10;
    int SheepScore = 15;
    int penguinScore = 25;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Finish")
        {
            SelfDestruct();
        }

    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints <= 0)
        { 
            KilEnemy();
        }
    }

    private void KilEnemy()
    {
        EnemyName = this.gameObject.name;
        EnemyPoints(EnemyName);
        Vector3 pos = new Vector3(transform.position.x, 6, transform.position.z);
        var vfx = Instantiate(deathFX, pos, Quaternion.identity);
        vfx.Play();
        Destroy(vfx.gameObject, vfx.main.duration);
        Destroy(this.gameObject);
    }

    void ProcessHit()
    {
        hitPoints = hitPoints - 1;
        
    }

    public void SelfDestruct()
    {
        Vector3 pos = new Vector3(transform.position.x - 10 , transform.position.y + 50, transform.position.z);
        var vfx = Instantiate(EndGoal, pos, Quaternion.identity);
        vfx.Play();
        Destroy(vfx.gameObject, vfx.main.duration);
        Destroy(this.gameObject);
    }

    public void EnemyPoints(string eName)
    {
        if(eName == "Cat(Clone)" )
        {
            var obj = GameObject.Find("Enemies").GetComponent<EnemySpawn>();
            obj.score += catScore;
            obj.spawnedEnemies.text = "HI " + obj.score.ToString();
        }
        else if (eName == "Duck(Clone)")
        {
            var obj = GameObject.Find("Enemies").GetComponent<EnemySpawn>();
            obj.score += duckScore;
            obj.spawnedEnemies.text = "HI " + obj.score.ToString();
        }

        else if (eName == "sheep(Clone)")
        {
            var obj = GameObject.Find("Enemies").GetComponent<EnemySpawn>();
            obj.score += SheepScore;
            obj.spawnedEnemies.text = "HI " + obj.score.ToString();
        }

        else if (eName == "penguin(Clone)")
        {
            var obj = GameObject.Find("Enemies").GetComponent<EnemySpawn>();
            obj.score += penguinScore;
            obj.spawnedEnemies.text = "HI " + obj.score.ToString();
        }

        else
        {
            print("Nothing to kill");
        }
    }



}
