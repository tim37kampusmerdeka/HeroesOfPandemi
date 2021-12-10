using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class EnemyShoot : MonoBehaviour
{
    float time;
    private PoolEnemyBullets pool;

    public UnityArmatureComponent anim;

    [SerializeField] EnemyBullet enemyBullet;

    void Start()
    {        
        pool = GameObject.FindObjectOfType<PoolEnemyBullets>();
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time > enemyBullet.cooldown)
        {
            Firing();
            time = 0;
        }
    }
    void Firing()
    {
        PlayingAnim("enemy_shooting");
        EnemyBullet bullet = Instantiate(enemyBullet, gameObject.transform.position, gameObject.transform.rotation);
    }

    void PlayingAnim(string animName)
    {
        anim.animation.Play(animName);
    }
}
