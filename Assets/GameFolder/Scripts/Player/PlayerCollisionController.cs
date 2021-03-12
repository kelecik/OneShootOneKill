using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    private int medkit = 0;
    PlayerAnimationController animationController;
    float time = 2;
    private void Start()
    {
        animationController = GetComponent<PlayerAnimationController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        {
            if (other.gameObject.CompareTag("MedKit"))
            {
                medkit++;
                print("medkit=" + medkit);
                Destroy(other.gameObject);//destroymedkit
                                          //collecing medkit ++
                                          //playerprefs kullanılabilir

            }
            if (other.gameObject.CompareTag("Soliter"))
            {
                //TODO: if idleda ise heal it


                //other.dirilt

                //if (time < 0)
                //{
                //    GameObject bullet = Instantiate(prefabs, firePos.transform.position, transform.rotation);
                //    Rigidbody rbBullet = bullet.GetComponent<Rigidbody>();
                //    rbBullet.velocity = transform.TransformDirection(0, 0, 40);
                //    time = fireFrequency;
                //}


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
        if (other.gameObject.CompareTag("Soliter") && other.GetComponent<Soldier>().isDeath && medkit > 0)
        {
            //TODO: if idleda ise heal it

            time -= Time.deltaTime;
            if (time < 0)
            {
                other.GetComponent<Soldier>().Respawn?.Invoke();
                medkit--;
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
        if (other.gameObject.CompareTag("Soliter"))
        {
            //TODO: if idleda ise heal it


            //other.dirilt

            time = 2;
            print(other.gameObject.tag);
            animationController.ChangeAnimation(AnimationState.Idle);

        }
    }

}
