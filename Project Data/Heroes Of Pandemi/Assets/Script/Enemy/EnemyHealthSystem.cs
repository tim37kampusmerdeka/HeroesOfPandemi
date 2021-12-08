using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    public float MaxHealth;
    public float Health = 0f;
    public int scoreValue = 100;
    public bool OnEnemyDead = false;
    public EnemyMovement enemyMovement;

    void OnEnable()
    {
        Health = MaxHealth;
        OnEnemyDead = false;
    }

    void Start()
    {
        Health = MaxHealth;
        OnEnemyDead = false;
    }

    public void ReduceHealth(int damage)
    {        
        if (Health > 0)
        {
            Health -= damage;
            StartCoroutine(Hit());
        }
        else
        {
            if (!OnEnemyDead)
            {
                OnDead();
                OnEnemyDead = true;
                GameManager.Instance.scoreManager.score += scoreValue;
            }
        }
    }

    IEnumerator Hit()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    void OnDead()
    {
        enemyMovement.OnDead(0.1f);
    }
}
