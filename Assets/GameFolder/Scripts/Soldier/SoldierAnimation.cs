using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAnimation : MonoBehaviour
{
    private Animator playerAnim;
    private void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        PlayerAnimation();
    }

    void PlayerAnimation()
    {
        switch (Soldier.instance.soldierState)
        {
            case SoldierState.ATTACK:
                playerAnim.SetBool("Moving", false);
                playerAnim.SetBool("Firing", true);
                playerAnim.SetBool("Die", Soldier.instance.health);
                break;
            case SoldierState.WALK:
                playerAnim.SetBool("Moving", true);
                playerAnim.SetBool("Firing", false);
                playerAnim.SetBool("Die", Soldier.instance.health);
                break;
            case SoldierState.DIE:
                playerAnim.SetBool("Moving", false);
                playerAnim.SetBool("Firing", false);
                playerAnim.SetBool("Die", Soldier.instance.health);
                break;
        }
    }
}
