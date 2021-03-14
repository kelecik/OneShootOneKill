using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SoldierMovementAI : MonoBehaviour
{

    [SerializeField] private SoldierMovementAISettings soldierInfoAsset;


    private float time;
    private Transform currentTarget;

    [Space]
    [Header("Components")]
    private Soldier soldier;
    private NearCheck nearCheck;
    private NavMeshAgent navmesh;

    private void Start()
    {
        soldier = GetComponent<Soldier>();
        nearCheck = GetComponent<NearCheck>();
        navmesh = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        SoldierDirection();
        SoldierMovement();
    }
    void SoldierDirection()
    {
        if (soldier.goodSoldierState == GoodSoldierState.ATTACK)
        {
            if (nearCheck.Enemy != null)
            {
                transform.LookAt(nearCheck.Enemy.transform.position, Vector3.up);
            }
        }
    }

    void SoldierMovement()
    {
        if (soldier.goodSoldierState == GoodSoldierState.WALK)
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                soldierInfoAsset.trenchCount = Random.Range(0, soldierInfoAsset.TrenchList.Count);
                Transform target = soldierInfoAsset.TrenchList[soldierInfoAsset.trenchCount].transform;
                currentTarget = target;
                time = soldierInfoAsset.walkFrequency;
            }
            navmesh.destination = currentTarget.position;
        }

        if (soldier.goodSoldierState != GoodSoldierState.WALK)
        {
            navmesh.isStopped = true;
        }
        else
        {
            navmesh.isStopped = false;
        }
    }
}