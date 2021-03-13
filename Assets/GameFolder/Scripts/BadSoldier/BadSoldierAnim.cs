using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadSoldierAnim : MonoBehaviour
{
    private Animator playerAnim;
    private BadSoldier badSoldier;
    private void Start()
    {
        badSoldier = GetComponent<BadSoldier>();
        playerAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        PlayerAnimation();
    }

    void PlayerAnimation()
    {
        switch (badSoldier.BadSoldierState)
        {
            case SoldierState.ATTACK:
                playerAnim.SetBool("Moving", false);
                playerAnim.SetBool("Firing", true);
                playerAnim.SetBool("Die", badSoldier.isDeath);
                break;
            case SoldierState.WALK:
                playerAnim.SetBool("Moving", true);
                playerAnim.SetBool("Firing", false);
                playerAnim.SetBool("Die", badSoldier.isDeath);
                break;
            case SoldierState.DIE:
                playerAnim.SetBool("Moving", false);
                playerAnim.SetBool("Firing", false);
                playerAnim.SetBool("Die", badSoldier.isDeath);
                break;
        }
    }
}
