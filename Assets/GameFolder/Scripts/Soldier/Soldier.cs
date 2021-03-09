using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Soldier : MonoBehaviour
{
    private SoldierState soldierState = SoldierState.NONE;
    [SerializeField]
    SoldierMovementAI soldierMovement;
    [SerializeField]
    SoldierAttackAI soldierAttackAI;
    [SerializeField]
    SoldierAnimation soldierAnimation;
    [SerializeField]
    SoldierDeterminationAI soldierDeterminationAI;
}

