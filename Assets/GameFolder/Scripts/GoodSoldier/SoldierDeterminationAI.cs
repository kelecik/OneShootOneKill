using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierDeterminationAI : MonoBehaviour
{
    [HideInInspector]
    public Collider[] nearstObjectContainer;
    [SerializeField]
    LayerMask nearsObjectLayer;
    public bool isNearObjectDeath;
    private Soldier soldier;

    private void Start()
    {
        soldier = GetComponent<Soldier>();
    }
    private void Update()
    {
        Determination();
        DeterminationNearstObjectLifeStatus();
    }
    void Determination()
    {
        nearstObjectContainer = Physics.OverlapSphere(transform.position,10,nearsObjectLayer,QueryTriggerInteraction.UseGlobal);
    }
    void DeterminationNearstObjectLifeStatus()
    {
        if (nearstObjectContainer.Length > 0)
        {
            if (nearstObjectContainer[0].GetComponent<BadSoldier>().isDeath)
            {
                isNearObjectDeath = true;
            }
            else if(!nearstObjectContainer[0].GetComponent<BadSoldier>().isDeath)
            {
                isNearObjectDeath = false;             
            }
        }
    }
}
