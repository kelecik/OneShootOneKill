using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierVisulation : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 10);
    }
}
