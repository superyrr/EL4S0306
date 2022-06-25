using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    private Generator generator;

    public void GameStart()
    {
        Debug.Log("start");

        Score.score = 0;

        generator.Next();
    }

    public void GameOver()
    {
        Debug.Log("over");
    }

    private void Start()
    {
        GameStart();
    }
}
