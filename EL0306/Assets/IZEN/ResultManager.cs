using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{

    [SerializeField]
    private string m_SinglePlaySceneName;
    [SerializeField]
    private string m_MultiPlaySceneName;
    [SerializeField]
    private string m_TitleSceneName;

    [SerializeField]
    private Text m_Score;
    [SerializeField]
    private Text m_MultiScore;
    [SerializeField]
    private Text m_MultiWinner;

    private bool m_GameMode;
    [SerializeField]
    private Image m_FloorImage;
    [SerializeField]
    private Image m_Floor2Image;

    // Start is called before the first frame update
    void Start()
    {
        m_GameMode = false;
        m_Floor2Image.enabled = false;

        m_Score.text = Score.score.ToString();
        m_MultiScore.text = Score.score.ToString();
        m_MultiWinner.text = "WIN P" + GameMode.winner.ToString();

        if (GameMode.mode == 0)
        {
            m_MultiScore.enabled = false;
            m_MultiWinner.enabled = false;
        }
        else
        {
            m_Score.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            m_GameMode = false;
            m_Floor2Image.enabled = false;
            m_FloorImage.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            m_GameMode = true;
            m_Floor2Image.enabled = true;
            m_FloorImage.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Score.score = 0;
            if (m_GameMode)
            {
                GameMode.mode = 0;
                SceneManager.LoadScene(m_TitleSceneName);
            }
            else
            {
                SceneManager.LoadScene(m_MultiPlaySceneName);
            }

        }
    }
}
