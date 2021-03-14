using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryController : MonoBehaviour
{
    public int Medkit = 2;
    public int SoldierHealedCount = 0;

    /// <summary>
    /// MedkitCollected SoldierHealed

    /// </summary>
    public void MedkitCollected()
    {
        Medkit++;
        UIManager.instance.UpdateMedic?.Invoke(Medkit);//TODO:ShowMedkitinUI

    }
    public void UseMedkit()
    {
        Medkit--;
        SoldierHealedCount++;
        UIManager.instance.UpdateMedic?.Invoke(Medkit);//TODO:ShowMedkitinUI
        UIManager.instance.UpdateSoldier?.Invoke(SoldierHealedCount);


        print(Medkit + "Updated");

    }

}
