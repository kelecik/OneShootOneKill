using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationController : MonoBehaviour
{
    Animator PlayerAnimator;

    private readonly int Died = Animator.StringToHash("Died");
    private readonly int Idle = Animator.StringToHash("Idle");
    private readonly int Run = Animator.StringToHash("Run");
    private readonly int Heailng = Animator.StringToHash("Heal");

    int LastStateId = Animator.StringToHash("Idle");
    private void Start()
    {
        PlayerAnimator = gameObject.GetComponent<Animator>();
    }


    internal void RotateIt(Vector3 Direction)
    {
        transform.LookAt(transform.position + Direction);
        //print("animate it");

    }

    internal void ChangeAnimation(AnimationState Currentstate)
    {
        switch (Currentstate)
        {
            case AnimationState.None:
                Debug.LogError("something wrong");
                break;

            case AnimationState.Idle:

                PlayerAnimator.SetBool(Idle, true);
                if (LastStateId == Idle) break;
                PlayerAnimator.SetBool(LastStateId, false);
                LastStateId = Idle;
                break;

            case AnimationState.Running:

                PlayerAnimator.SetBool(Run, true);
                if (LastStateId == Run) break;

                PlayerAnimator.SetBool(LastStateId, false);
                LastStateId = Run;
                break;

            case AnimationState.Dead:
                print("öl");
                PlayerAnimator.SetTrigger(Died);
                PlayerAnimator.SetBool(LastStateId, false);

                break;

            case AnimationState.Healing:
                PlayerAnimator.SetBool(Heailng, true);
                print("Yaşat");
                if (LastStateId == Heailng) break;
                PlayerAnimator.SetBool(LastStateId, false);
                LastStateId = Heailng;
                break;

            default:
                break;
        }



        //print("AnimationStop");
        //TODO:animasyonstop
    }

    internal void CloseWalkAnimation()
    {
        //PlayerAnimator.SetBool(, true);
    }
}
