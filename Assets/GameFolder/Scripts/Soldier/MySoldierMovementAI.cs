using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MySoldierMovementAI : MonoBehaviour
{
    [SerializeField]
    List<Transform> trenchList = new List<Transform>();
    int trenchCount;
    float time;
    [SerializeField]
    float timeFrequency;
    Transform currentTarget;
    [Space]
    [Header("Components")]
    private MySoldier mySoldier;
    private NearCheck nearCheck;
    private NavMeshAgent navmesh;


    private void Start()
    {
        mySoldier = GetComponent<MySoldier>();
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
        if(mySoldier.goodSoldierState == GoodSoldierState.ATTACK)
        {
            if(nearCheck.Enemy != null)
            {
                transform.LookAt(nearCheck.Enemy.transform.position, Vector3.up);
            }     
        }
    }

    void SoldierMovement()
    {
        if(mySoldier.goodSoldierState == GoodSoldierState.WALK)
        {
            time -= Time.deltaTime;
            if(time < 0)
            {
                trenchCount = Random.Range(0, trenchList.Count);
                Transform target = trenchList[trenchCount].transform;
                currentTarget = target;
                time = timeFrequency;
            }
            navmesh.destination = currentTarget.position;
        }
        
        if(mySoldier.goodSoldierState != GoodSoldierState.WALK)
        {
            navmesh.isStopped = true;
        }
        else
        {
            navmesh.isStopped = false;
        }
    }
}
