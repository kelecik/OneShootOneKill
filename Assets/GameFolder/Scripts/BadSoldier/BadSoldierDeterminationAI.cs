using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadSoldierDeterminationAI : MonoBehaviour
{
    public Collider[] nearstObjectContainer;
    [SerializeField]
    LayerMask nearsObjectLayer;
    public bool isNearObjectDeath;
    private BadSoldier badSoldier;

    private void Start()
    {
        badSoldier = GetComponent<BadSoldier>();
    }
    private void Update()
    {
        Determination();
        DeterminationNearstObjectLifeStatus();
    }
    void Determination()
    {
        nearstObjectContainer = Physics.OverlapSphere(transform.position, 10, nearsObjectLayer, QueryTriggerInteraction.UseGlobal);
    }

    void DeterminationNearstObjectLifeStatus()
    {
        if(nearstObjectContainer.Length > 0)
        {
            if (nearstObjectContainer[0].GetComponent<SoldierLifeStatus>().isDeath)
            {
                isNearObjectDeath = true;
            }
            else if (!nearstObjectContainer[0].GetComponent<SoldierLifeStatus>().isDeath)
            {
                isNearObjectDeath = false;
            }
        }
    }
}
