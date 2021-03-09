using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMovementAI : MonoBehaviour 
{

    private void Update()
    {
        NPCDirection();
    }
    void NPCDirection()
    {
        if (Soldier.instance.soldierState == SoldierState.ATTACK)
        {
            transform.LookAt(Soldier.instance.soldierDeterminationAI.nearstObjectContainer[0].transform.position, Vector3.up);
        }
        else if(Soldier.instance.soldierState == SoldierState.WALK)
        {
            // mehmethan
        }
    }
}
