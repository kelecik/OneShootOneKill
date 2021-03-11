using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAnimation : MonoBehaviour
{
    private Animator playerAnim;
    private Soldier soldier;
    private void Start()
    {
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
                playerAnim.SetBool("Die", soldier.isDeath);
                break;
            case SoldierState.WALK:
                playerAnim.SetBool("Moving", true);
                playerAnim.SetBool("Firing", false);
                playerAnim.SetBool("Die", soldier.isDeath);
                break;
            case SoldierState.DIE:
                playerAnim.SetBool("Moving", false);
                playerAnim.SetBool("Firing", false);
                playerAnim.SetBool("Die", soldier.isDeath);
                break;
        }
    }
}
