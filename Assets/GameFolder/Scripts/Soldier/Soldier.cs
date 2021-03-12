using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(SoldierMovementAI), typeof(SoldierAttackAI), typeof(SoldierAnimation))]
[RequireComponent(typeof(SoldierDeterminationAI))]
public class Soldier : MonoBehaviour
{
    public static Soldier instance;
    public SoldierState soldierState = SoldierState.NONE;
    private SoldierMovementAI soldierMovement;
    private SoldierAttackAI soldierAttackAI;
    private SoldierAnimation soldierAnimation;
    public SoldierDeterminationAI soldierDeterminationAI
    {
        get; private set;
    }
    public UnityEvent Respawn;
    public bool isDeath;
    private void Awake() { instance = this; }
    public int health = 100;

    private void Start()
    {
        #region GetCompanents
        soldierMovement = GetComponent<SoldierMovementAI>();
        soldierAttackAI = GetComponent<SoldierAttackAI>();
        soldierAnimation = GetComponent<SoldierAnimation>();
        soldierDeterminationAI = GetComponent<SoldierDeterminationAI>();

        #endregion

        #region Events
        Respawn.AddListener(RespawnValidator);
        Respawn.AddListener(RespawnState);

        #endregion
    }

    private void RespawnValidator()
    {
        isDeath = false;
        health = 100;
    }

    private void RespawnState()
    {
        soldierState = SoldierState.WALK;
    }

    private void Update()
    {
        DecideState();
        HealthStatus();
    }
    void DecideState() // to decide SoldierState
    {
        if (soldierDeterminationAI.nearstObjectContainer.Length > 0 && !isDeath)
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

    void HealthStatus()
    {
        if(health < 1)
        {
            isDeath = true;
        }
    }
}

