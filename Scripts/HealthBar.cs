using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Character character;
    private RectTransform healthTransform;
    private PlayerStats playerStats;
    public CharacterStats stats;
    private Slider slider;
    private Text text;
   
    private void Start()
    {
        GameObject enemy = GameObject.FindWithTag("Enemy");
        healthTransform = GetComponent<RectTransform>();
        GameObject player = GameObject.FindWithTag("Player");
        slider = GetComponentInChildren<Slider>();
        text = GetComponentInChildren<Text>();
        playerStats = player.GetComponentInParent<PlayerStats>();
        stats = enemy.GetComponentInParent<CharacterStats>();
        healthTransform = GetComponent<RectTransform>();
       
        character = GetComponentInParent<Character>();
        
        stats.healthChange += HealthBarUpdate;
       
    }
   
    private void Update()
    {
        HealthBarUpdate();
        


    }
    private  void HealthBarUpdate()
    {
    
        slider.maxValue = stats.maxHealth;
        slider.value = stats.currentHealth;
        if (stats.currentHealth <= 0 || playerStats.currentHealth <= 0)
        {
            slider.gameObject.SetActive(false);
            text.gameObject.SetActive(false);

        }
        else
        {
            slider.gameObject.SetActive(true); 
        }
    }
    private void OnDisable()
    {

        stats.healthChange -= HealthBarUpdate;

    }
}