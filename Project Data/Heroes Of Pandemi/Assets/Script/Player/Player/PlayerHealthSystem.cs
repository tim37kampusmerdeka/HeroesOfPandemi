using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DragonBones;

public class PlayerHealthSystem : MonoBehaviour
{
    public GameObject healthbarPrefab;
    public int maxHealth = 100, health;
    public Slider healthSlider;
    public Text barText;
    CharacterController playerMovement;
    private UnityArmatureComponent animator;

    void Start()
    {
        // Set Health, text bar dan slider
        health = maxHealth;
        healthSlider.value = health;
        barText.text = health + "/" + maxHealth;

        animator = GetComponent<UnityArmatureComponent>();
        playerMovement = GetComponent<CharacterController>();
        //Invoke void trydamage
        //InvokeRepeating("TryDamage", 5, 0.1f);
    }
    void OnPlayerDead(bool dead = false)
    {
        if (dead)
        {
            //this.gameObject.SetActive(false);
            animator.animation.Play(("PlayerDead"), 1);
            StartCoroutine(PlayAnimation());
            healthbarPrefab.SetActive(false);
            GameManager.Instance.PlayerCondition(false);
        }
    }
    public void TakeDamage(int amount)
    {
        if (playerMovement.canMove)
        {
            health -= amount;
            healthSlider.value = health;
            barText.text = health + "/" + maxHealth;

            if (health <= 0)
            {
                OnPlayerDead(true);
                playerMovement.canMove = false;
            }else
            {
                animator.animation.Stop(("PlayerWalking_alternative2"));
                animator.animation.Play(("PlayerGethit"), 1);
            }
        }

        
    }
    IEnumerator PlayAnimation()
    {
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);
    }
}
