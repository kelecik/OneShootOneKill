using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

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
    }//Singleton

    public static UnityEvent<int> UpdateMedic;
    public static UnityEvent<UIState> ChangeUI;

    private TextMeshProUGUI MedkitCount;
    private TextMeshProUGUI SoliterCount;

    public Animator animator;

    public static UnityEvent<int> UpdateProcess;

    void Start()
    {
        UpdateMedic.AddListener(UpdateMedKitCount);
        UpdateProcess.AddListener(UpdatePlayerProcess);

        ChangeUI.AddListener(ChangeAnim);
    }

    private void UpdatePlayerProcess(int Count)
    {
        SoliterCount.text = ("X " + Count).ToString();
    }


    /// <summary>
    /// UI State Degisir ->
    /// </summary>
    /// <param name="state"></param>
    private void ChangeAnim(UIState state)
    {
        switch (state)
        {
            case UIState.Start:
                animator.SetTrigger("Start");
                break;
            case UIState.Win:
                animator.SetTrigger("Win");
                break;
            case UIState.Fail:
                animator.SetTrigger("Fail");
                break;
            default:
                break;
        }
    }

    private void UpdateMedKitCount(int count)
    {
        MedkitCount.text = ("x " + count).ToString();
    }

}
