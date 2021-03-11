using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAnimation : MonoBehaviour
{
<<<<<<< Updated upstream
    // Start is called before the first frame update
    void Start()
    {
        
=======
    private Animator playerAnim;
    private Soldier soldier;
    private void Start()
    {
        soldier = GetComponent<Soldier>();
        playerAnim = GetComponent<Animator>();
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        
=======
        PlayerAnimation();
    }

    void PlayerAnimation()
    {
        switch (soldier.soldierState)
        {
            case SoldierState.ATTACK:
                playerAnim.SetBool("Moving", false);
                playerAnim.SetBool("Firing", true);
                playerAnim.SetBool("Die", soldier.health);
                break;
            case SoldierState.WALK:
                playerAnim.SetBool("Moving", true);
                playerAnim.SetBool("Firing", false);
                playerAnim.SetBool("Die", soldier.health);
                break;
            case SoldierState.DIE:
                playerAnim.SetBool("Moving", false);
                playerAnim.SetBool("Firing", false);
                playerAnim.SetBool("Die", soldier.health);
                break;
        }
>>>>>>> Stashed changes
    }
}
