using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SoldierMovementAI : MonoBehaviour 
{
    [SerializeField]
    Transform pos;
    private void Update()
    {
        NPCDirection();
    }
    void NPCDirection()
    {
        if (Soldier.instance.soldierState == SoldierState.ATTACK)
        {
            transform.LookAt(Soldier.instance.soldierDeterminationAI.nearstObjectContainer[0].transform.position, Vector3.up);
            Debug.Log("bakıyorum şuan");
        }

        if(Soldier.instance.soldierState == SoldierState.WALK)
        {
            transform.LookAt(pos.position, Vector3.up);
            transform.DOLocalMove(pos.position, 15);
        }
        else
        {
            DOTween.Kill(transform);
        }
    }
}
