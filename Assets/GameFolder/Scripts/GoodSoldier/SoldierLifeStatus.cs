using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoldierLifeStatus : MonoBehaviour
{
    public UnityEvent Respawn;
    public bool isDeath;
    public int health = 100;
    Soldier soldier;
    private void Start()
    {
        soldier = GetComponent<Soldier>();
        Respawn.AddListener(RespawnValidator);
        Respawn.AddListener(RespawnState);
    }

    private void Update()
    {
        HealthStatus();
    }
    private void RespawnValidator()
    {
        isDeath = false;
        health = 100;
    }
    private void RespawnState()
    {
        soldier.soldierState = SoldierState.WALK;
    }
    void HealthStatus()
    {
        if (health < 1)
        {
            isDeath = true;
        }
    }
}
