using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 10;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] Text healthText = null;
    private Image heartFills;
    

    private void Start()
    {
        
        healthText.text = health.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        health = health - healthDecrease;
        healthText.text = health.ToString();

    }


}
