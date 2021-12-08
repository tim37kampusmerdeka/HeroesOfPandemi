using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //Inisiasi variabel yang dibutuhkan
    public float speed = 1f;
    
    private Transform pullObject;
    private float delay;

    void Update()
    {
        Move();
    }
    //
    void Move()
    {
        transform.Translate(-transform.right * speed * Time.deltaTime);
    }

    public IEnumerator TurnOffEnemy(Transform pullObject, float delay)
    {
        this.pullObject = pullObject;
        this.delay = delay;

        yield return new WaitForSeconds(delay);
        gameObject.transform.SetParent(pullObject);
        gameObject.SetActive(false);

    }

    public void OnDead(float delay)
    {
        StopAllCoroutines();
        StartCoroutine(TurnOffEnemy(pullObject, delay));        
    }
}
