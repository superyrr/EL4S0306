using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManage : MonoBehaviour
{

    enum TitleState
    {
        State_ClickAny,
        State_ModeSelect,
        State_Start,
        State_Max,
    }
    [SerializeField]
    private string m_SinglePlaySceneName;
    [SerializeField]
    private string m_MultiPlaySceneName;
    private TitleState m_TitleState;
    private bool m_GameMode;
    [SerializeField]
    private Image m_FloorImage;
    [SerializeField]
    private Image m_Floor2Image;
    [SerializeField]
    private Image m_Button1Image;
    [SerializeField]
    private Image m_Button2Image;
    [SerializeField]
    private Image m_ClickImage;
    [SerializeField]
    private GameObject m_StartAudio;
    [SerializeField]
    private GameObject m_DecisionAudio;

    private float m_Timer;

    // Start is called before the first frame update
    void Start()
    {
        m_TitleState = TitleState.State_ClickAny;
        m_GameMode = false;
        m_FloorImage.enabled = false;
        m_Floor2Image.enabled = false;
        m_Button1Image.enabled = false;
        m_Button2Image.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        switch(m_TitleState)
        {
            case TitleState.State_ClickAny:

                if (Input.anyKeyDown)
                {
                    m_TitleState = TitleState.State_ModeSelect;
                    m_ClickImage.enabled = false;
                    m_FloorImage.enabled = true;
                    m_Button1Image.enabled = true;
                    m_Button2Image.enabled = true;
                    m_DecisionAudio.GetComponent<AudioSource>().Play();
                }
                break;

            case TitleState.State_ModeSelect:

                if(Input.GetKeyDown(KeyCode.W))
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
                    m_StartAudio.GetComponent<AudioSource>().Play();
                    m_Timer = Time.time;
                    m_TitleState = TitleState.State_Start;
                   
                  
                }

                break;

            case TitleState.State_Start:

                if(Time.time - m_Timer> 2.0)
                {
                    if (m_GameMode)
                    {
                        GameMode.mode = 1;
                        SceneManager.LoadScene(m_MultiPlaySceneName);
                    }
                    else
                    {
                        GameMode.mode = 0;
                        SceneManager.LoadScene(m_SinglePlaySceneName);
                    }
                }
               
                break;
        }
    }
}
