using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan = null;
    Transform targetEnemy = null;
    public float attackRange = 10f;

    public Waypoint baseWaypoint;

    // Update is called once per frame
    void Update()
    {

        setTargetEnemy();
        if(targetEnemy)
        {
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        }
        else
        {
            shoot(false);
        }

    }

    private void setTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if(sceneEnemies.Length == 0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach( EnemyDamage testEnemy in sceneEnemies )
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }

        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform transformA, Transform transformB)
    {
        var distToA = Vector3.Distance(transform.position, transformA.position);
        var distToB = Vector3.Distance(transform.position, transformB.position);

        if(distToA < distToB)
        {
            return transformA;
        }

        return transformB;
    }




    private void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position,gameObject.transform.position);
        if (distanceToEnemy <= attackRange)
        {

            shoot(true);
            
        }
        else
        {
            shoot(false);
        }
    }

    private void shoot(bool isActive)
    {
        var emissionModule = GetComponentInChildren<SimpleProjectileSpawn>();
        emissionModule.isEnabled = isActive;
    }

}
