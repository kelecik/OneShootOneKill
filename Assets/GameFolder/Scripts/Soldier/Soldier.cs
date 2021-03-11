using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Soldier : MonoBehaviour
{
    public static Soldier instance;
    public SoldierState soldierState = SoldierState.NONE;
    public SoldierMovementAI soldierMovement;
    public SoldierAttackAI soldierAttackAI;
    public SoldierAnimation soldierAnimation;
    public SoldierDeterminationAI soldierDeterminationAI;
    //------SOLDİER STATUS---------//
    public bool isDeath;
    private void Awake() { instance = this; }
    private void Update()
    {
        DecideState();
    }
    void DecideState() // to decide SoldierState
    {
        if(soldierDeterminationAI.nearstObjectContainer.Length > 0 && !isDeath)
        {
            soldierState = SoldierState.ATTACK;
        }
        else if (soldierDeterminationAI.nearstObjectContainer.Length == 0 && !isDeath)
        {
            soldierState = SoldierState.WALK;
        }
        else if (isDeath)
        {
            soldierState = SoldierState.DIE;
        }
    }
}

