using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;

public class SoldierMovementAI : MonoBehaviour 
{
    [SerializeField]
    Transform pos;
    [SerializeField]
    List<GameObject> trenchList = new List<GameObject>();
    private Transform target;
    private Soldier soldier;
    float time;
    [SerializeField]
    float patrolFrequency;
    private int trench;
    private NavMeshAgent nvms;

    private void Start()
    {
        soldier = GetComponent<Soldier>();
        nvms = GetComponent<NavMeshAgent>();
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
            nvms.isStopped = true;
        }
        else if (!soldier.isDeath && soldier.soldierState != SoldierState.ATTACK)
        {
            nvms.isStopped = false;
            nvms.destination = target.position;
        }
    }
}