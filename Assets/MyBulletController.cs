using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBulletController : MonoBehaviour
{
    public int layerCount;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == layerCount)
        {
            other.gameObject.GetComponent<MySoldierLifeStatus>().health -= 25;
            Destroy(gameObject, 0.2f);
        }
    }
}
