using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSystem : MonoBehaviour
{
    public GameObject healthbarPrefab;
    public int maxHealth = 100, health;
    public Slider healthSlider;
    public Text barText;

    void Start()
    {
        // Set Health, text bar dan slider
        health = maxHealth;
        healthSlider.value = health;
        barText.text = health + "/" + maxHealth;

        //Invoke void trydamage
        //InvokeRepeating("TryDamage", 5, 0.1f);
    }
    void OnPlayerDead(bool dead = false)
    {
        if (dead)
        {
            this.gameObject.SetActive(false);
            healthbarPrefab.SetActive(false);
        }
    }
    void TakeDamage(int amount)
    {
        health -= amount;
        healthSlider.value = health;
        barText.text = health + "/" + maxHealth;
        if (health <= 0)
        {
            OnPlayerDead(true);
        }
    }
    //Test Damage
    void TryDamage()
    {
        TakeDamage(1);
    }

}
