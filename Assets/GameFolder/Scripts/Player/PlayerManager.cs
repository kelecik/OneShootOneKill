using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInputController), typeof(PlayerAnimasyonController), typeof(PlayerMoveController))] //scripts
[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]  //physics
[RequireComponent(typeof(PlayerCollisionDetection))]  //physics
public class PlayerManager : MonoBehaviour
{
    private PlayerInputController InputController;
    private PlayerMoveController MoveController;
    private PlayerAnimasyonController AnimationController;
    private PlayerCollisionDetection CollisionDetection;



    private void Start()
    {
        #region GetCompanents
        InputController = gameObject.GetComponent<PlayerInputController>();
        MoveController = gameObject.GetComponent<PlayerMoveController>();
        AnimationController = gameObject.GetComponent<PlayerAnimasyonController>();
        CollisionDetection = gameObject.GetComponent<PlayerCollisionDetection>();

        #endregion

        InputController.MoveIt.AddListener(MoveController.MoveIt);
        InputController.MoveIt.AddListener(AnimationController.AnimateIt);
        InputController.AnimateIt.AddListener(AnimationController.ChangeAnimation);
    }
    private void Update()
    {

    }
}
