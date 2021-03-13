using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SoldierMovementAI), typeof(SoldierAttackAI), typeof(SoldierAnimation))]
[RequireComponent(typeof(SoldierDeterminationAI))]
public class Soldier : MonoBehaviour
{
    public SoldierState soldierState = SoldierState.NONE;
    private SoldierDeterminationAI soldierDeterminationAI;
    private SoldierLifeStatus soldierLifeStatus;

    private void Start()
    {
        #region GetCompanents
        soldierDeterminationAI = GetComponent<SoldierDeterminationAI>();
        soldierLifeStatus = GetComponent<SoldierLifeStatus>();
        #endregion
    }
    private void Update()
    {
        DecideState();
    }
    void DecideState()
    {
        if (soldierDeterminationAI.nearstObjectContainer.Length > 0 && !soldierLifeStatus.isDeath && !soldierDeterminationAI.isNearObjectDeath)
        {
            soldierState = SoldierState.ATTACK;
        }
        else if (soldierDeterminationAI.nearstObjectContainer.Length == 0 && !soldierLifeStatus.isDeath)
        {
            soldierState = SoldierState.WALK;
        }
        else if (soldierLifeStatus.isDeath)
        {
            soldierState = SoldierState.DIE;
        }
    }
}

