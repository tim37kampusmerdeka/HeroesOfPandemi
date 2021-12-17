using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class PlayerShoot : MonoBehaviour
{
    public UnityEngine.Transform shootingPos;
    float time;
    private PoolManagers _pool;
    private UnityArmatureComponent animator;
    [SerializeField] WeaponScript weapon;
    void Start()
    {
        _pool = GameObject.FindObjectOfType<PoolManagers>();
        animator = GetComponent<UnityArmatureComponent>();
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

        if (Input.GetKeyDown(KeyCode.L) && !GameManager.Instance.isGameOver)
        {
            for (int i = 0; i < _pool.bulletList.Count; i++)
            {
                animator.animation.Play(("PlayerShooting_alternative2"), 1);
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
