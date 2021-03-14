using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySoldierAttackAI : MonoBehaviour
{
    [SerializeField]
    float fireFrequency;
    float time;
    [SerializeField]
    GameObject prefabs, firePos;
    private MySoldier mySoldier;
    private void Start()
    {
       mySoldier = GetComponent<MySoldier>();
    }
    private void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (mySoldier.goodSoldierState == GoodSoldierState.ATTACK)
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                GameObject bullet = Instantiate(prefabs, firePos.transform.position, transform.rotation);
                Rigidbody rbBullet = bullet.GetComponent<Rigidbody>();
                rbBullet.velocity = transform.TransformDirection(0, 0, 40);
                time = fireFrequency;
                SoundManager.PlaySound("fireSound");
            }
        }
    }
}
