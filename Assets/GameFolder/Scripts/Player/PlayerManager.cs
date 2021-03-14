using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerInputController), typeof(PlayerAnimationController), typeof(PlayerMoveController))] //scripts
[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]  //physics
[RequireComponent(typeof(PlayerCollisionController))]  //physics
[RequireComponent(typeof(PlayerInventoryController))]  //Inventory



public class PlayerManager : MonoBehaviour
{
    private PlayerInputController InputController;
    private PlayerMoveController MoveController;
    private PlayerAnimationController AnimationController;
    private PlayerCollisionController CollisionDetection;


    public UnityEvent OnGameover;


    private void Start()
    {
        #region GetCompanents
        InputController = gameObject.GetComponent<PlayerInputController>();
        MoveController = gameObject.GetComponent<PlayerMoveController>();
        AnimationController = gameObject.GetComponent<PlayerAnimationController>();
        CollisionDetection = gameObject.GetComponent<PlayerCollisionController>();

        #endregion

        InputController.MoveIt.AddListener(MoveController.MoveIt);
        InputController.MoveIt.AddListener(AnimationController.RotateIt);
        InputController.AnimateIt.AddListener(AnimationController.ChangeAnimation);

        OnGameover.AddListener(InactiveMovementController);
        OnGameover.AddListener(InactiveAnimationController);
        OnGameover.AddListener(InactiveInputController);
        OnGameover.AddListener(UIManager.instance.ShowGameOverUI);




    }

    private void InactiveInputController()
    {
        InputController.enabled = false;

    }

    private void InactiveAnimationController()
    {
        AnimationController.ChangeAnimation(AnimationState.Dead);
        AnimationController.enabled = false;
    }

    private void InactiveMovementController()
    {
        MoveController.enabled = false;
    }
}
