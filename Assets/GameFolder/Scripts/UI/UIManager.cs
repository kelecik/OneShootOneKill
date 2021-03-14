using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Text MedkitCount;
    public Text SoliterCount;

    public Animator animator;

    [System.Serializable]
    public class UpdateProcess : UnityEvent<int> { }

    public UpdateProcess UpdateSoldier;

    [System.Serializable]
    public class UpdateMedicEvent : UnityEvent<int> { }

    public UpdateMedicEvent UpdateMedic;

    public UnityEvent<UIState> ChangeUI;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }



        //ChangeUI.AddListener(ChangeAnim);

    }//Singleton Events

    private void Start()
    {
        UpdateMedic.AddListener(UpdateMedKitCount);
        UpdateSoldier.AddListener(UpdatePlayerProcess);
    }

    public void UpdatePlayerProcess(int Count)
    {
        print("X " + Count);
        SoliterCount.text = ("X " + Count).ToString();
    }


    /// <summary>
    /// UI State Degisir  Start->0 Win ->1 Fail->2
    /// </summary>
    /// <param name="state"></param>
    public void ChangeAnim(int index)//Starting Event Dont Clear it
    {
        switch (index)
        {
            case (int)UIState.Start:
                animator.SetTrigger("Start");
                break;
            case (int)UIState.Win:
                animator.SetTrigger("Win");
                break;
            case (int)UIState.Fail:
                animator.SetTrigger("Fail");
                break;
            default:
                Application.Quit();//application quit
                break;
        }
    }

    private void UpdateMedKitCount(int count)
    {
        MedkitCount.text = ("x " + count).ToString();
    }

}
