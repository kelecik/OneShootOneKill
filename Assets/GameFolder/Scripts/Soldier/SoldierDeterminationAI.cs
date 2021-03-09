using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierDeterminationAI : MonoBehaviour
{
    [SerializeField]
    Collider[] nearstObjectContainer;
    [SerializeField]
    LayerMask nearsObjectLayer;


    private void Update()
    {
        Determination();
    }
    void Determination()
    {
        nearstObjectContainer = Physics.OverlapSphere(transform.position,10,nearsObjectLayer,QueryTriggerInteraction.UseGlobal);
    }
}
