using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField]
    public FontObject m_FontPrefab;
    [SerializeField]
    public Game m_Game;
    [SerializeField]
    public Camera m_Camera;
    [SerializeField]
    public float m_Interval = 0.5f;
    [SerializeField]
    public float m_Distance = 2.0f;

    private FontObject m_CurrentFont = null;
    private Rigidbody m_CurrentFontRigidbody = null;

    private int m_NextId = 0;

    public void Next()
    {
        Debug.Log($"next{m_NextId}");

        m_CurrentFont = Instantiate(m_FontPrefab.gameObject, transform).GetComponent<FontObject>();
        m_CurrentFontRigidbody = m_CurrentFont.gameObject.GetComponent<Rigidbody>();
        m_CurrentFont.SetSprite(m_NextId);
        m_NextId = UnityEngine.Random.Range(0, m_FontPrefab.GetArrayNumber());
        m_NextId = 0;
    }

    private void OnFontStop()
    {
        if (m_CurrentFont.transform.position.y + m_Distance > transform.position.y)
        {
            transform.position.SetY(m_CurrentFont.transform.position.y + m_Distance);
        }

        Invoke("Next", m_Interval);


    }

    private void Awake()
    {
        m_NextId = UnityEngine.Random.Range(0, m_FontPrefab.GetArrayNumber());
        m_NextId = 0;
    }

    private void Update()
    {
        var bottom = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 0.5f, 0.0f, -m_Camera.transform.position.z)).y;
        if (m_CurrentFont.transform.position.y <= bottom)
            m_Game.GameOver();

        if (m_CurrentFont.Phaze == FontObject.phase.phase_fall &&
            m_CurrentFontRigidbody.velocity.sqrMagnitude <= 0.01f * 0.01f)
        {
            Debug.Log("stop");
            OnFontStop();
        }
    }
}
