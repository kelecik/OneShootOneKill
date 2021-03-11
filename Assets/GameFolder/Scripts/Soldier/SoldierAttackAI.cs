using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAttackAI : MonoBehaviour
{
    float fireFrequency;
<<<<<<< Updated upstream
=======
    float time;
    [SerializeField]
    GameObject prefabs, firePos;
    private Soldier soldier;
    private void Update()
    {
        Attack();
    }
>>>>>>> Stashed changes
    void Attack()
    {
        if(soldier.soldierState == SoldierState.ATTACK)
        {
            
        }
    }

    void FireFrequency()
    {

    }
}
