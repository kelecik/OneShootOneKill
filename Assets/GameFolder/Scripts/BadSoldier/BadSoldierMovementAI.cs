using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BadSoldierMovementAI : MonoBehaviour
{
    [SerializeField]
    List<GameObject> trenchList = new List<GameObject>();
    private Transform target;
    private BadSoldier badSoldier;
    private BadSoldierDeterminationAI badSoldierDeterminationAI;
    float time;
    [SerializeField]
    float patrolFrequency;
    private int trench;
    private NavMeshAgent navmeshAgent;

    private void Start()
    {
        badSoldierDeterminationAI = GetComponent<BadSoldierDeterminationAI>();
        badSoldier = GetComponent<BadSoldier>();
        navmeshAgent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        NPCDirection();
        NPCMovementFrequency();
    }
    void NPCDirection()
    {
        if (badSoldier.BadSoldierState == SoldierState.ATTACK)
        {
            transform.LookAt(badSoldierDeterminationAI.nearstObjectContainer[0].transform.position, Vector3.up);
        }
    }

    void NPCMovementFrequency()
    {
        if (!badSoldier.isDeath && badSoldier.BadSoldierState == SoldierState.WALK)
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                trench = Random.Range(0, trenchList.Count);
                Transform targetPos = trenchList[trench].transform;
                target = targetPos;
                time = patrolFrequency;
            }
        }
        if (badSoldier.isDeath)
        {
            navmeshAgent.isStopped = true;
        }
        else if (!badSoldier.isDeath && badSoldier.BadSoldierState != SoldierState.ATTACK)
        {
            navmeshAgent.isStopped = false;
            navmeshAgent.destination = target.position;
        }
        else if (badSoldier.BadSoldierState == SoldierState.ATTACK)
        {
            navmeshAgent.isStopped = true;
        }
    }
}
