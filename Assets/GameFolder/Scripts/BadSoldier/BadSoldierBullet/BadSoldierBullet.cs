﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadSoldierBullet : MonoBehaviour
{
    public LayerMask layer;
    private void Update()
    {
        Collider[] myObject = Physics.OverlapSphere(transform.position, 3, layer, QueryTriggerInteraction.UseGlobal);

        if (myObject.Length > 0)
        {
            myObject[0].GetComponent<SoldierLifeStatus>().health -= 25;
            Destroy(gameObject);
        }
    }
}