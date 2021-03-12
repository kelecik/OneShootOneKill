using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierDeterminationAI : MonoBehaviour
{
    [HideInInspector]
    public Collider[] nearstObjectContainer;
    [SerializeField]
    LayerMask nearsObjectLayer;
    private void Update()
    {
        Determination();
    }
    void Determination()
    {
        nearstObjectContainer = Physics.OverlapSphere(transform.position,5,nearsObjectLayer,QueryTriggerInteraction.UseGlobal);
    }
}
