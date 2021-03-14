using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState
{
    NONE,
    START,
}
public class GameManager : MonoBehaviour
{

    private GameState gameState = GameState.NONE;
    private void Awake()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {
        Check();
        Listen();
    }

    void Check()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameState = GameState.START;
        }
    }

    void Listen()
    {
        if (gameState == GameState.START)
        {
            Time.timeScale = 1;
        }
    }
}
