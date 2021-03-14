using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearCheck : MonoBehaviour
{
    public GameObject Enemy;
    public int layerCount;
    public bool isOtherAlive;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == layerCount)
        {
            if (Enemy == null)
            {
                Enemy = other.gameObject;
            }
        }
    }
    private void Update()
    {
        DeterminationStatus();
    }
    void DeterminationStatus()
    {
        if (Enemy != null)
        {
            isOtherAlive = Enemy.GetComponent<MySoldierLifeStatus>().isAlive;
        }
        if (!isOtherAlive)
        {
            Enemy = null;
        }
    }
}
