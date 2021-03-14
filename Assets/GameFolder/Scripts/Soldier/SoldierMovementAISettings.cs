using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SoldierAsset", menuName = "Soldier/MovementAI", order = 1)]
public class SoldierMovementAISettings : ScriptableObject
{
    public List<GameObject> TrenchList = new List<GameObject>();
    [HideInInspector]
    public int trenchCount;
    public float walkFrequency; 
}
