﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;

public class SoldierMovementAI : MonoBehaviour 
{
    [SerializeField]
    List<GameObject> trenchList = new List<GameObject>();
    private Transform target;
    private Soldier soldier;
    float time;
    [SerializeField]
    float patrolFrequency;
    private int trench;
    private NavMeshAgent navmeshAgent;

    private void Start()
    {
        soldier = GetComponent<Soldier>();
        navmeshAgent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        NPCDirection();
        NPCMovementFrequency();        
    }
    void NPCDirection()
    {
        if (soldier.soldierState == SoldierState.ATTACK)
        {
            transform.LookAt(Soldier.instance.soldierDeterminationAI.nearstObjectContainer[0].transform.position, Vector3.up);
        }
    }

    void NPCMovementFrequency()
    {
        if (!soldier.isDeath && soldier.soldierState == SoldierState.WALK)
        {
            time -= Time.deltaTime;
            if(time < 0)
            {
                trench = Random.Range(0, trenchList.Count);
                Transform targetPos = trenchList[trench].transform;
                target = targetPos;
                time = patrolFrequency;
            }           
        }
        if (soldier.isDeath)
        {
            navmeshAgent.isStopped = true;
        }
        else if (!soldier.isDeath && soldier.soldierState != SoldierState.ATTACK)
        {
            navmeshAgent.isStopped = false;
            navmeshAgent.destination = target.position;
        }
    }
}