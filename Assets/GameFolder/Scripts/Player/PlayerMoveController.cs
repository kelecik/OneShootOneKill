using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMoveController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float MovementSpeed = 1;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

    }
    internal void MoveIt(Vector3 Direction)
    {
        //rb.MovePosition(gameObject.transform.position + Direction * MovementSpeed * Time.fixedDeltaTime);
        gameObject.transform.Translate(Direction * MovementSpeed * Time.fixedDeltaTime, Space.World);
    }
}
