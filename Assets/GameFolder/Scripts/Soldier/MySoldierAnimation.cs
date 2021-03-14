using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySoldierAnimation : MonoBehaviour
{
    private Animator playerAnim;
    private MySoldierLifeStatus mySoldierLifeStatus;
    private MySoldier mySoldier;
    private void Start()
    {
        mySoldierLifeStatus = GetComponent<MySoldierLifeStatus>();
        mySoldier = GetComponent<MySoldier>();
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
