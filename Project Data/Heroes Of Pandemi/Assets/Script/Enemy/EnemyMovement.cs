using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //
    public float speed = 0.7f;

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
        yield return new WaitForSeconds(delay);
        gameObject.transform.SetParent(pullObject);
        gameObject.SetActive(false);

    }
}
