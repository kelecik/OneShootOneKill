using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadSoldier : MonoBehaviour
{
    public SoldierState BadSoldierState = SoldierState.NONE;
    private BadSoldierDeterminationAI badSoldierDeterminationAI;
    public bool isDeath;
    public int health = 100;

    private void Start()
    {
        badSoldierDeterminationAI = GetComponent<BadSoldierDeterminationAI>();
    }
    private void Update()
    {
        DecideState();
        HealthStatus();
    }
    void DecideState()
    {
        if (badSoldierDeterminationAI.nearstObjectContainer.Length > 0 && !isDeath && !badSoldierDeterminationAI.isNearObjectDeath)
        {
            BadSoldierState = SoldierState.ATTACK;
        }
        else if (badSoldierDeterminationAI.nearstObjectContainer.Length == 0 && !isDeath)
        {
            BadSoldierState = SoldierState.WALK;
        }
        else if (isDeath)
        {
            BadSoldierState = SoldierState.DIE;
        }
    }

    void HealthStatus()
    {
        if (health < 1)
        {
            isDeath = true;
        }
    }
}
