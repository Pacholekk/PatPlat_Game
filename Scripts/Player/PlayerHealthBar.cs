using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    private Character character;
    private RectTransform healthTransform;
    public CharacterStats stats;
    
    private Slider slider;
    private Image healthBarImage;
    
    private void Start()
    {
        healthTransform = GetComponent<RectTransform>();
        character = GetComponentInParent<Character>();
       

        slider = GetComponentInChildren<Slider>();
        
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            stats = player.GetComponent<CharacterStats>();
        }
        stats.healthChange += HealthBarUpdate;
        
        healthBarImage = slider.GetComponentInChildren<Image>();
    }
 
    private void Update()
    {
        HealthBarUpdate();
        if (stats != null)
        {
            HealthBarUpdate();
        }
        else
        {
            Debug.LogError("Stats is null, cannot update health bar!");
        }



    }
    private void HealthBarUpdate()
    {
        slider.maxValue = stats.maxHealth;
        slider.value = stats.currentHealth;
  
    }
    private void OnDisable()
    {


        stats.healthChange -= HealthBarUpdate;

    }
}