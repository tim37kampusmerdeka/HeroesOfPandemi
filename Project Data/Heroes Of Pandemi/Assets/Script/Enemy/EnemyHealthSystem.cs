using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class EnemyHealthSystem : MonoBehaviour
{
    public float MaxHealth;
    public float Health = 0f;
    public int scoreValue = 100;
    public bool OnEnemyDead = false;

    public EnemyMovement enemyMovement;

    public UnityArmatureComponent anim;

    //bool isPlayingAnim = false;

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
        if (Health >= 0)
        {
            Health -= damage;
            StartCoroutine(Hit());
        }
        else
        {
            if (!OnEnemyDead)
            {
                PlayingAnim("enemy_dead");
                OnDead();
                OnEnemyDead = true;
                GameManager.Instance.scoreManager.score += scoreValue;
            }
        }
    }

    IEnumerator Hit()
    {
        //GetComponent<SpriteRenderer>().color = Color.red;
        anim.animation.Play(("enemy_getHit"), 1);
        yield return new WaitForSeconds(0.25f);
        PlayingAnim("enemy_walk");
        //GetComponent<SpriteRenderer>().color = Color.white;
    }

    void OnDead()
    {
        enemyMovement.OnDead(0.25f);
    }

    void PlayingAnim(string animName)
    {
        anim.animation.FadeIn(animName, 0.2f, 0);
    }
}
