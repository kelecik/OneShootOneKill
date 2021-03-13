using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAnimation : MonoBehaviour
{
    private Animator playerAnim;
    private SoldierLifeStatus soldierLifeStatus;
    private Soldier soldier;
    private void Start()
    {
        soldierLifeStatus = GetComponent<SoldierLifeStatus>();
        soldier = GetComponent<Soldier>();
        playerAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        PlayerAnimation();
    }

    void PlayerAnimation()
    {
        switch (soldier.soldierState)
        {
            case SoldierState.ATTACK:
                playerAnim.SetBool("Moving", false);
                playerAnim.SetBool("Firing", true);
                playerAnim.SetBool("Die", soldierLifeStatus.isDeath);
                break;
            case SoldierState.WALK:
                playerAnim.SetBool("Moving", true);
                playerAnim.SetBool("Firing", false);
                playerAnim.SetBool("Die", soldierLifeStatus.isDeath);
                break;
            case SoldierState.DIE:
                playerAnim.SetBool("Moving", false);
                playerAnim.SetBool("Firing", false);
                playerAnim.SetBool("Die", soldierLifeStatus.isDeath);
                break;
        }
    }
}
