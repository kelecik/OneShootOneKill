using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimasyonController : MonoBehaviour
{
    Animator PlayerAnimator;

    readonly int Idle = Animator.StringToHash("Idle");
    readonly int Run = Animator.StringToHash("Run");
    readonly int Died = Animator.StringToHash("Died");
    readonly int Heailng = Animator.StringToHash("Heal");

    int LastStateId = Animator.StringToHash("Idle");
    private void Start()
    {
        PlayerAnimator = gameObject.GetComponent<Animator>();
    }


    internal void AnimateIt(Vector3 Direction)
    {
        transform.LookAt(transform.position + Direction);
        //print("animate it");
        //TODO:animasyonlar
    }

    internal void ChangeAnimation(AnimationState Currentstate)
    {
        switch (Currentstate)
        {
            case AnimationState.None:
                Debug.LogError("something wrong");
                break;
            case AnimationState.Idle:
                print("Idle");
                PlayerAnimator.SetBool(Idle, true);
                if (LastStateId == Idle) break;
                PlayerAnimator.SetBool(LastStateId, false);
                LastStateId = Idle;
                break;
            case AnimationState.Running:

                PlayerAnimator.SetBool(Run, true);
                print("koş");
                if (LastStateId == Run) break;
                PlayerAnimator.SetBool(LastStateId, false);
                LastStateId = Run;
                break;
            case AnimationState.Dead:
                PlayerAnimator.SetBool(Died, true);
                print("öl");
                PlayerAnimator.SetBool(LastStateId, false);
                LastStateId = Died;
                break;
            case AnimationState.Healing:
                PlayerAnimator.SetBool(Heailng, true);
                print("Yaşat");
                PlayerAnimator.SetBool(LastStateId, false);
                LastStateId = Heailng;
                break;
            default:
                break;
        }



        //print("AnimationStop");
        //TODO:animasyonstop
    }
}
