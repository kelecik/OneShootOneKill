using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAnimation : MonoBehaviour
{
    private Animator playerAnim;
    private SoldierLifeStatus mySoldierLifeStatus;
    private Soldier mySoldier;
    private void Start()
    {
        mySoldierLifeStatus = GetComponent<SoldierLifeStatus>();
        mySoldier = GetComponent<Soldier>();
        playerAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        PlayerAnimation();
    }

    void PlayerAnimation()
    {
        switch (mySoldier.goodSoldierState)
        {
            case GoodSoldierState.ATTACK:
                playerAnim.SetBool("Moving", false);
                playerAnim.SetBool("Firing", true);
                playerAnim.SetBool("Die", false);
                break;
            case GoodSoldierState.WALK:
                playerAnim.SetBool("Moving", true);
                playerAnim.SetBool("Firing", false);
                playerAnim.SetBool("Die", false);
                Debug.Log("buraya girdi");
                break;
            case GoodSoldierState.DİE:
                playerAnim.SetBool("Moving", false);
                playerAnim.SetBool("Firing", false);
                playerAnim.SetBool("Die",true);
                break;
        }
    }
}
