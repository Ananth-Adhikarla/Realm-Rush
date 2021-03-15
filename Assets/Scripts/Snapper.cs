using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]

public class Snapper : MonoBehaviour
{

    float gridSize = 20f;



    // Update is called once per frame
    void Update()
    {
        SnapToGrid();


    }

    private void SnapToGrid()
    {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        //snapPos.y = Mathf.RoundToInt(transform.position.y / gridSize) * gridSize;
        transform.position = new Vector3(snapPos.x, 0 , snapPos.z);
    }

}
