using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAttackAI : MonoBehaviour
{
    [SerializeField]
    float time;
    [SerializeField]
    GameObject firePos;
    private Soldier soldier;
    [SerializeField] private SoldierAttackAISettings soldierAttackAsset;

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
        if (soldier.goodSoldierState == GoodSoldierState.ATTACK)
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                GameObject bullet = Instantiate(soldierAttackAsset.bulletPrefab, firePos.transform.position, transform.rotation);
                Rigidbody bodyBullet = bullet.GetComponent<Rigidbody>();
                bodyBullet.velocity = transform.TransformDirection(0, 0, 40);
                time = soldierAttackAsset.fireFrequency;
                SoundManager.PlaySound("fireSound");
            }
        }
    }
}