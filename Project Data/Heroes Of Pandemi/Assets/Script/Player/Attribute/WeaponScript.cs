using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public float speed = 500, atkSpeed = 0.8f, damage;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rb.velocity = Vector2.right * speed;
        StartCoroutine(SetOff());
    }
    IEnumerator SetOff()
    {
        yield return new WaitForSeconds(3);
        this.gameObject.SetActive(false);
    }
}
