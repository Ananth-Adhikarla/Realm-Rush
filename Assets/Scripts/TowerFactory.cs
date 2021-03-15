using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerFactory : MonoBehaviour
{
    int towerLimit = 3;
    [SerializeField] Tower towerPrefab = null;
    [SerializeField] Transform towerParentTransform = null;

    Queue<Tower> towerQueue = new Queue<Tower>();

    //-------------------------------------------------

    EnemySpawn e;

    public Text turretLimit = null;

    private void Start()
    {
        GameObject enemyObject = GameObject.Find("Enemies");
        e = enemyObject.GetComponent<EnemySpawn>();
    }

    private void Update()
    {
        ShowLimit();
        TowerLimit();
    }

    public void TowerLimit()
    {
        if (e.wave1 == true)
        {
            towerLimit = 5;
        }

        if(e.wave2 == true)
        {
            towerLimit = 6;
        }

        if(e.wave3 == true)
        {
            towerLimit = 8;
        }
    }

    public void AddTowerA(Waypoint baseWaypoint)
    {
        int numTowers = towerQueue.Count;

        if (numTowers < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);

        }

        else
        {
            MoveExistingTower(baseWaypoint);
        }

    }


    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        Vector3 pos = new Vector3(baseWaypoint.transform.position.x, 10, baseWaypoint.transform.position.z);

        var newTower = Instantiate(towerPrefab, pos, Quaternion.identity);
        newTower.transform.parent = towerParentTransform.transform;
        baseWaypoint.isPlaceable = false;
        newTower.baseWaypoint = baseWaypoint;
        baseWaypoint.isPlaceable = false;

        towerQueue.Enqueue(newTower);
    }


    private void MoveExistingTower(Waypoint newBaseWaypoint)
    {
        // to make towers spawn on top of surface .
        Vector3 newPos = new Vector3(newBaseWaypoint.transform.position.x, newBaseWaypoint.transform.position.y + 10, newBaseWaypoint.transform.position.z);

        var oldTower = towerQueue.Dequeue();

        oldTower.baseWaypoint.isPlaceable = true;
        newBaseWaypoint.isPlaceable = false;
        oldTower.baseWaypoint = newBaseWaypoint;
        oldTower.transform.position = newPos;

        towerQueue.Enqueue(oldTower);
    }

    public void ShowLimit()
    {
        turretLimit.text = "Limit:" + towerLimit.ToString();
    }
}
