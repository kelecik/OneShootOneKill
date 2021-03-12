using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControll : MonoBehaviour
{
    public LayerMask layerMask;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == layerMask)
        {
            other.gameObject.GetComponent<Soldier>().health -= 20;
            Debug.Log("ben girdim ");
        }
    }
}
