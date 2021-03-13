using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBullet : MonoBehaviour
{
    public LayerMask layer;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer ==10)
        {
            other.gameObject.GetComponent<BadSoldier>().health -= 25;
            Destroy(gameObject);
        }
    }
}
