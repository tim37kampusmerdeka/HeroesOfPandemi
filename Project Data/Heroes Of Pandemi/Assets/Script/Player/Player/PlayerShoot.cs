using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform shootingPos;
    float time;
    Animator animator;
    private PoolManagers _pool;
    [SerializeField] WeaponScript weapon;
    void Start()
    {
        _pool = GameObject.FindObjectOfType<PoolManagers>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= weapon.atkSpeed)
        {
            Shooting();
        }
    }
    void Shooting()
    {
        Vector3 pos = shootingPos.position;
        //pos.x = pos.x + 1;
        //pos.y = pos.y - 0.37f;

        if (Input.GetKeyDown(KeyCode.L))
        {
            for (int i = 0; i < _pool.bulletList.Count; i++)
            {
                if (_pool.bulletList[i].activeInHierarchy == false)
                {
                    _pool.bulletList[i].SetActive(true);
                    _pool.bulletList[i].transform.position = pos;
                    _pool.bulletList[i].transform.rotation = Quaternion.identity;
                    break;
                }
            }
            time = 0;
            //Debug.Log("Shoot");
        }
    }
}
