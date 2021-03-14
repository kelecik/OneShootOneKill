using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryController : MonoBehaviour
{
    public int Medkit = 2;
    public int SoldierHealCount = 0;

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
        SoldierHealCount++;
        UIManager.instance.UpdateMedic?.Invoke(Medkit);//TODO:ShowMedkitinUI
        UIManager.instance.UpdateSoldier?.Invoke(SoldierHealCount);


        print(Medkit + "Updated");

    }

}
