using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SoldierAsset", menuName = "Soldier", order = 1)]
public class SoldierInfoAsset : ScriptableObject
{
    public GameObject BulletPrefab;
    public int FireFriquency;
    public Transform[] TrencList;
    public int LayerCount;
}
