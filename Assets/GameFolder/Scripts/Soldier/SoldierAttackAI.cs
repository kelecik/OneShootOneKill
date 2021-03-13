using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAttackAI : MonoBehaviour
{
    [SerializeField]
    float fireFrequency;
    float time;
    [SerializeField]
    GameObject prefabs, firePos;
    private Soldier soldier;
    private void Start()
    {
        soldier = GetComponent<Soldier>();
    }
    private void Update()
    {
        Attack();
    }

    void Attack()
    {
        if(soldier.soldierState == SoldierState.ATTACK)
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                GameObject bullet = Instantiate(prefabs, firePos.transform.position, transform.rotation);
                Rigidbody rbBullet = bullet.GetComponent<Rigidbody>();
                rbBullet.velocity = transform.TransformDirection(0, 0, 40);
                time = fireFrequency;
            }
        }
    }
}
