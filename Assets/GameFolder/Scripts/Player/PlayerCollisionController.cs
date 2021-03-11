using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    private int medkit = 2;
    PlayerAnimationController animationController;
    private void Start()
    {
        animationController = GetComponent<PlayerAnimationController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        {
            if (other.gameObject.CompareTag("MedKit"))
            {
                print("medkit");
                medkit++;
                Destroy(other.gameObject);//destroymedkit
                                          //collecing medkit ++
                                          //playerprefs kullanılabilir

            }
            if (other.gameObject.CompareTag("Soliter"))
            {
                //TODO: if idleda ise heal it

                medkit--;
                //other.dirilt


                print(other.gameObject.tag);
                animationController.ChangeAnimation(AnimationState.Healing);

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
        if (other.gameObject.CompareTag("Soliter"))
        {
            //TODO: if idleda ise heal it


            //other.dirilt


            print(other.gameObject.tag);
            animationController.ChangeAnimation(AnimationState.Healing);
            //animationController.CloseWalkAnimation();

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Soliter"))
        {
            //TODO: if idleda ise heal it


            //other.dirilt


            print(other.gameObject.tag);
            animationController.ChangeAnimation(AnimationState.Running);

        }
    }

}
