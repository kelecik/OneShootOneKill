using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMovementAI : MonoBehaviour 
{
<<<<<<< Updated upstream

=======
    [SerializeField]
    Transform pos;
    private Soldier soldier;

    private void Start()
    {
        soldier = GetComponent<Soldier>();
    }
>>>>>>> Stashed changes
    private void Update()
    {
        NPCDirection();
    }
    void NPCDirection()
    {
        if (soldier.soldierState == SoldierState.ATTACK)
        {
            transform.LookAt(Soldier.instance.soldierDeterminationAI.nearstObjectContainer[0].transform.position, Vector3.up);
<<<<<<< Updated upstream
=======
            Debug.Log("bakıyorum şuan");
        }

        if(soldier.soldierState == SoldierState.WALK)
        {
            transform.LookAt(pos.position, Vector3.up);
            transform.DOLocalMove(pos.position, 15);
>>>>>>> Stashed changes
        }
        else if(Soldier.instance.soldierState == SoldierState.WALK)
        {
            // mehmethan
        }
    }
}
