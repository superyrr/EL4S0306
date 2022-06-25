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
    public C_50on m_C_50On;
    [SerializeField]
    public float m_Interval = 0.5f;
    [SerializeField]
    public float m_Distance = 2.0f;

    private FontObject m_CurrentFont = null;
    private Rigidbody2D m_CurrentFontRigidbody = null;

    private int m_NextId = 0;

    private float m_NextGenCount = -1.0f;

    public void Next()
    {
        Debug.Log($"next{m_NextId}");

        m_CurrentFont = Instantiate(m_FontPrefab.gameObject, transform).GetComponent<FontObject>();
        m_CurrentFontRigidbody = m_CurrentFont.gameObject.GetComponent<Rigidbody2D>();

        m_CurrentFont.SetSprite(m_NextId);
        m_NextId = UnityEngine.Random.Range(0, m_FontPrefab.GetArrayNumber());
        m_C_50On.AIM_SPRITE = m_FontPrefab.m_SpriteArray[m_NextId];

        m_NextGenCount = -1.0f;
    }

    private void OnFontStop()
    {
        if (m_CurrentFont.transform.position.y + m_Distance > transform.position.y)
        {
            transform.position.SetY(m_CurrentFont.transform.position.y + m_Distance);
        }

        m_NextGenCount = m_Interval;
    }

    private void Awake()
    {
        m_NextId = UnityEngine.Random.Range(0, m_FontPrefab.GetArrayNumber());
    }

    private void Update()
    {
        if (m_NextGenCount > 0.0f)
        {
            m_NextGenCount -= Time.deltaTime;
            if (m_NextGenCount < 0.0f)
            {
                Next();
            }
            return;
        }

        var bottom = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 0.5f, 0.0f, -m_Camera.transform.position.z)).y;
        if (m_CurrentFont.transform.position.y <= bottom)
            m_Game.GameOver();

        if (m_CurrentFont.Phaze == FontObject.phase.phase_fall &&
            m_CurrentFontRigidbody.velocity.sqrMagnitude <= 0.01f * 0.01f &&
            m_CurrentFont.transform.position.y <= transform.position.y - 1.0f)
        {
            Debug.Log("stop");
            OnFontStop();
        }
    }
}
