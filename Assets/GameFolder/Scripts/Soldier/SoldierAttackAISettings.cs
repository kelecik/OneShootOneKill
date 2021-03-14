using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SoldierAsset", menuName = "Soldier/AttackAI", order = 1)]
public class SoldierAttackAISettings : ScriptableObject
{
   public float fireFrequency;
   public GameObject bulletPrefab;
}
