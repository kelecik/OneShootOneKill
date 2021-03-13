using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadSoldierAttackAI : MonoBehaviour
{
    [SerializeField]
    float fireFrequency;
    float time;
    [SerializeField]
    GameObject prefabs, firePos;
    private BadSoldier badSoldier;
    private BadSoldierDeterminationAI badSoldierDeterminationAI;
    private void Start()
    {
        badSoldier = GetComponent<BadSoldier>();
        badSoldierDeterminationAI = GetComponent<BadSoldierDeterminationAI>();
    }
    private void Update()
    {
        Attack();
    }
    void Attack()
    {
        if (badSoldier.BadSoldierState == SoldierState.ATTACK)
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
