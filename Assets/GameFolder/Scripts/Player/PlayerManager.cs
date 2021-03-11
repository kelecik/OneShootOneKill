using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerInputController), typeof(PlayerAnimasyonController), typeof(PlayerMoveController))] //scripts
[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]  //physics
[RequireComponent(typeof(PlayerCollisionController))]  //physics
public class PlayerManager : MonoBehaviour
{
    private PlayerInputController InputController;
    private PlayerMoveController MoveController;
    private PlayerAnimasyonController AnimationController;
    private PlayerCollisionController CollisionDetection;


    public UnityEvent OnGameover;


    private void Start()
    {
        #region GetCompanents
        InputController = gameObject.GetComponent<PlayerInputController>();
        MoveController = gameObject.GetComponent<PlayerMoveController>();
        AnimationController = gameObject.GetComponent<PlayerAnimasyonController>();
        CollisionDetection = gameObject.GetComponent<PlayerCollisionController>();

        #endregion

        InputController.MoveIt.AddListener(MoveController.MoveIt);
        InputController.MoveIt.AddListener(AnimationController.RotateIt);
        InputController.AnimateIt.AddListener(AnimationController.ChangeAnimation);

        OnGameover.AddListener(InactiveMovementController);
        OnGameover.AddListener(InactiveAnimationController);
        OnGameover.AddListener(InactiveInputController);
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

    private void Update()
    {

    }

}
