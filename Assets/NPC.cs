using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{

    public NavMeshAgent navigation;
    public Transform currentTarget;
    public Transform[] targets;
    private int i = 0;
    GameObject myTarget;


    // Start is called before the first frame update
    void Start()
    {
        navigation = this.GetComponent<NavMeshAgent>();
        //System.Array.Reverse(targets);
        myTarget = GameObject.Find("Direction");
       
        navigation.destination = myTarget.transform.GetChild(i).position;

        //-------------------------------------------------------------------



    }


    void Update()
    {
        var dist = Vector3.Distance(myTarget.transform.GetChild(i).position, transform.position);
        currentTarget = myTarget.transform.GetChild(i);

        if (dist < 5)
        {
            if (i < targets.Length - 1)
            { 
                i++;

                navigation.destination = myTarget.transform.GetChild(i).position; 
            }
        }

    }

}

