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
            if (other.gameObject.CompareTag("Bullet"))
            {
                Destroy(other.gameObject);
                gameObject.GetComponent<PlayerManager>().OnGameover?.Invoke();
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 9 && !other.GetComponent<MySoldierLifeStatus>().isAlive && inventory.Medkit > 0)//soldier
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                other.GetComponent<MySoldierLifeStatus>().health = 100;
                inventory.UseMedkit();
            }
            animationController.ChangeAnimation(AnimationState.Healing);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            time = 2;
            animationController.ChangeAnimation(AnimationState.Idle);
        }
    }
}
