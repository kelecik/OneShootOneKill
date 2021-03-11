using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerInputController : MonoBehaviour
{
    private Vector3 StartPos = Vector3.zero;
    private Vector3 EndPos = Vector3.zero;
    [System.Serializable]
    public class MoveEvent : UnityEvent<Vector3> { }

    public MoveEvent MoveIt;

    [System.Serializable]
    public class StopEvent : UnityEvent<AnimationState> { }

    public StopEvent AnimateIt;
    private const bool alwaysTrue = true;
    private void FixedUpdate()
    {
        TakeInput();
        
    }
    public void TakeInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartPos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            EndPos = Input.mousePosition;

        }

        if (Input.GetMouseButtonUp(0))
        {
            EndPos = StartPos = Vector3.zero;
            AnimateIt?.Invoke(AnimationState.Idle);
            
        }
        if (Mathf.Abs((StartPos - EndPos).magnitude) > 2f)
        {
            Vector3 InputDirection = new Vector3((EndPos.x - StartPos.x), 0, (EndPos.y - StartPos.y));
            MoveIt?.Invoke(InputDirection.normalized);
            AnimateIt?.Invoke(AnimationState.Running);
        }

    }
}
