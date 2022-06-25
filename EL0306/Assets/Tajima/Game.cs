using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    private Generator generator;

    private bool m_GameOver = false;

    public void GameStart()
    {
        Debug.Log("start");

        Score.score = 0;

        generator.Next();
    }

    public void GameOver()
    {
        if (m_GameOver)
            return;

        Debug.Log("over");

        m_GameOver = true;
    }

    private void Start()
    {
        GameStart();
    }
}
