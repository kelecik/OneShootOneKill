using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{

    PlayerAnimationController animationController;
    PlayerInventoryController inventory;
    float time = 2;
    private void Start()
    {
        animationController = GetComponent<PlayerAnimationController>();
        inventory = GetComponent<PlayerInventoryController>();

    }
    private void OnTriggerEnter(Collider other)
    {
        {
            if (other.gameObject.CompareTag("MedKit"))
            {
                inventory.MedkitCollected();//collecing medkit ++
                Destroy(other.gameObject);//destroymedkit





            }
            if (other.gameObject.CompareTag("Bullet"))//TODO: add particule
            {
                Destroy(other.gameObject);
                gameObject.GetComponent<PlayerManager>().OnGameover?.Invoke(); //game over
            }
        }
    }



    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 9 && other.GetComponent<Soldier>().isDeath && inventory.Medkit > 0)//soldier
        {
            //TODO: if idleda ise heal it
            print("Healing...");

            time -= Time.deltaTime;
            if (time < 0)
            {
                print("HEAL İTT");
                other.GetComponent<Soldier>().Respawn?.Invoke();
                inventory.UseMedkit();
                //Debug.LogWarning(medkit + "Medkit");
            }
            //other.dirilt


            print(other.gameObject.tag);
            animationController.ChangeAnimation(AnimationState.Healing);
            //animationController.CloseWalkAnimation();

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 9)//soldier
        {
            //TODO: if idleda ise heal it


            //other.dirilt

            time = 2;
            animationController.ChangeAnimation(AnimationState.Idle);

        }
    }

}
