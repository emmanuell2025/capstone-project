using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterStats))]
public class PlayerHealthBar : MonoBehaviour
{
    public Slider healthBar;
    CharacterStats playerHealth;
    

     void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
        healthBar.wholeNumbers = true;
    }
    private void Update()
    {
        
        GetComponent<CharacterStats>().OnHealthChanged += OnHealthChanged;
    }

    void OnHealthChanged(int maxHealth, int currentHealth)
    {
        float healthPercent = (float)currentHealth / maxHealth;
        healthBar.value = currentHealth;
    }

     
}