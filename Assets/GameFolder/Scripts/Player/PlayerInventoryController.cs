using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryController : MonoBehaviour
{
    public int Medkit = 2;

    /// <summary>
    /// MedkitCollected SoldierHealed

    /// </summary>
    public void MedkitCollected()
    {
        Medkit++;
        UIManager.UpdateMedic?.Invoke(Medkit);//TODO:ShowMedkitinUI
        print(Medkit + "Updated");

    }
    public void UseMedkit()
    {
        Medkit--;
        UIManager.UpdateMedic?.Invoke(Medkit);//TODO:ShowMedkitinUI
        print(Medkit + "Updated");

    }

}
