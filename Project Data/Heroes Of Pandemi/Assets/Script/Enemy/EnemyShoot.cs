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
            StartCoroutine(Firing());
            time = 0;
        }
    }
    IEnumerator Firing()
    {
        PlayingAnim("enemy_shooting", 1f);
        EnemyBullet bullet = Instantiate(enemyBullet, gameObject.transform.position, gameObject.transform.rotation);
        yield return new WaitForSeconds(0.8f);
        PlayingAnim("enemy_walk", 1f);
    }

    void PlayingAnim(string animName, float timeScale)
    {
        anim.animation.Play(animName);
        anim.animation.timeScale = timeScale;
    }
}
