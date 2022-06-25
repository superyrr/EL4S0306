using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField]
    private Generator generator;
    [SerializeField]
    private GameObject[] multiOnly;

    private bool m_GameOver = false;

    public void GameStart()
    {
        Score.score = 0;

        generator.Next();
    }

    public void GameOver()
    {
        if (m_GameOver)
            return;

        SceneManager.LoadScene("Result");

        m_GameOver = true;
    }

    private void Awake()
    {
        foreach (var obj in multiOnly)
        {
            obj.SetActive(false);
        }
    }

    private void Start()
    {
        GameStart();
    }
}
