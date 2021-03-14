using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoldierLifeStatus : MonoBehaviour
{
    public int health;
    public bool isAlive;
    private void Update()
    {
        HealthStatus();
    }
    void HealthStatus()
    {
        if(health < 1)
        {
            isAlive = false;
        }
        else
        {
            isAlive = true;
        }
    }
}
