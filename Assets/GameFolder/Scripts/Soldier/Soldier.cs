using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Soldier : MonoBehaviour
{
    public static Soldier instance;
    [HideInInspector]
    public SoldierState soldierState = SoldierState.NONE;

    public SoldierMovementAI soldierMovement;
    public SoldierAttackAI soldierAttackAI;
    public SoldierAnimation soldierAnimation;
    public SoldierDeterminationAI soldierDeterminationAI;

    private void Update()
    {
        DecideState();
    }

    void DecideState() // to decide SoldierState
    {
        if(soldierDeterminationAI.nearstObjectContainer.Length > 0)
        {
            soldierState = SoldierState.ATTACK;
        }
        else
        {
            soldierState = SoldierState.NONE;
        }
    }
}

