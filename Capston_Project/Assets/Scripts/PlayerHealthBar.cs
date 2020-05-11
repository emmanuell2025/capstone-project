using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterStats))]
public class PlayerHealthBar : MonoBehaviour
{
    public Slider healthBar;
    

     void Start()
    {
        healthBar.wholeNumbers = true;
    }
    private void Update()
    {
        
        GetComponent<CharacterStats>().OnHealthChanged += OnHealthChanged;
    }

    void OnHealthChanged(int maxHealth, int currentHealth)
    {
        healthBar.value = currentHealth;
        
    }

     
}