using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

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

    }//Singleton

    private void Start()
    {
        UpdateMedic.AddListener(UpdateMedKitCount);
        UpdateSoldier.AddListener(UpdatePlayerProcess);
    }

    public void UpdatePlayerProcess(int count)
    {
        
        if (count >= 10)
        {
            ChangeAnim(1);

        }
        else
        {
            SoliterCount.text = ("X " + (Convert.ToInt32(SoliterCount.text.Split(' ')[1]) - 1)).ToString();
        }
    }
    public void LevelLoad()//UI EVENT
    {
        SceneManager.LoadScene(0);
    }
    public void ShowGameOverUI()
    {
        animator.SetTrigger("Fail");
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
                Application.Quit();
                break;
        }
    }

    private void UpdateMedKitCount(int count)
    {
        MedkitCount.text = ( count+"X " ).ToString();
    }

}
