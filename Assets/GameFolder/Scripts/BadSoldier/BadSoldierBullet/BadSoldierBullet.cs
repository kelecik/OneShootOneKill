using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadSoldierBullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.layer == 9)
        {
            other.gameObject.GetComponent<SoldierLifeStatus>().health -= 25;
            Debug.Log("geldi");
            Destroy(gameObject);
        }
    }
}
