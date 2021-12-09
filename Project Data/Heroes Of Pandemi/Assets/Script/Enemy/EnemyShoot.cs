using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    float time;
    private PoolEnemyBullets pool;

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
        EnemyBullet bullet = Instantiate(enemyBullet, gameObject.transform.position, gameObject.transform.rotation);
    }
}
