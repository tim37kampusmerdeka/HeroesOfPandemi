using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [Header("Attack Parameters")]
    public float speed;
    public float cooldown;
    public float damage;        
    
    void Update()
    {
        transform.Translate(-transform.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<EnemyHealthSystem>().ReduceHealth(10);
            this.gameObject.SetActive(false);
        }
    }
}
