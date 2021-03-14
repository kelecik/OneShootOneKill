using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GoodSoldierState
{
    WALK,
    ATTACK,
    DİE
}

public class Soldier : MonoBehaviour
{
    public GoodSoldierState goodSoldierState = GoodSoldierState.WALK;
    private NearCheck nearCheck;
    private SoldierLifeStatus mySoldierLifeStatus;

    private void Start()
    {
        nearCheck = GetComponent<NearCheck>();
        mySoldierLifeStatus = GetComponent<SoldierLifeStatus>();
    }

    private void Update()
    {
        DeterminationState();
    }


    void DeterminationState()
    {
        if(nearCheck.Enemy != null && nearCheck.isOtherAlive && mySoldierLifeStatus.isAlive)
        {
            goodSoldierState = GoodSoldierState.ATTACK;
        }
        else if (nearCheck.Enemy == null && mySoldierLifeStatus.isAlive)
        {
            goodSoldierState = GoodSoldierState.WALK;
        }
        else if (!mySoldierLifeStatus.isAlive)
        {
            goodSoldierState = GoodSoldierState.DİE;
            nearCheck.Enemy = null;
        }
    }
}
