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

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Score.score = 0;
            if (m_GameMode)
            {
                SceneManager.LoadScene(m_TitleSceneName);
            }
            else
            {
                SceneManager.LoadScene(m_MultiPlaySceneName);
            }

        }
    }
}
