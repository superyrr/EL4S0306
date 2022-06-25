using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FontObject : MonoBehaviour
{
    // 田島追加
    public phase Phaze => m_Phase;

    public enum phase
    {
        phase_dissolve,
        phase_move,
        phase_fall
    }
    private phase m_Phase = phase.phase_move;
    private float m_DissTime = 0;
    [SerializeField]
    private float m_RotateSpeed = 20;
    [SerializeField]
    private float m_MoveSpeed = 20;
    [SerializeField]
    private float m_FallSpeed;
    [SerializeField]
    private GameObject[] m_Effect;
    private Rigidbody2D m_Rb;
    [SerializeField]
    public Sprite[] m_SpriteArray;
    private SpriteRenderer m_SpriteRenderer;
    // Start is called before the first frame update
    void Awake()
    {
        m_Rb = GetComponent<Rigidbody2D>();
        m_Rb.gravityScale = 0;
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        int id = Random.Range(0, 4);
        int Scale = 1;
        switch (id)
        {
            case 0:
            case 2:
                Scale = 10;
                break;
            case 3:
                Scale = 23;
                break;
            case 1:
                Scale = 6;
                break;
        }
        var effect = Instantiate(m_Effect[id], transform);
        effect.transform.position += new Vector3(0, 0, -0.1f);
        effect.transform.localScale = new Vector3(Scale, Scale, Scale);
        effect.transform.parent = null;
        m_Phase = phase.phase_dissolve;
        m_DissTime = 0.0f;
    }
    public int GetArrayNumber()
    {
        return m_SpriteArray.Length;
    }
    public void SetSprite(int ID)
    {
        m_SpriteRenderer.sprite = m_SpriteArray[ID];
        gameObject.AddComponent<PolygonCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Q))
        //{
        //    int id = Random.Range(0, 4);
        //    int Scale = 1;
        //    switch(id)
        //    {
        //        case 0:
        //        case 2:
        //            Scale = 10;
        //            break;
        //        case 3:
        //            Scale = 23;
        //            break;
        //        case 1:
        //            Scale = 6;
        //            break;
        //    }
        //    var effect = Instantiate(m_Effect[id], transform);
        //    effect.transform.position += new Vector3(0, 0, -0.1f);
        //    effect.transform.localScale = new Vector3(Scale, Scale, Scale);
        //    effect.transform.parent = null;
        //    m_Phase = phase.phase_dissolve;
        //    m_DissTime = 0.0f;
        //}
        switch(m_Phase)
        {
            case phase.phase_dissolve:
                m_DissTime += Time.deltaTime;
                if (m_DissTime >= 0.2f)
                {
                    m_DissTime = 0.2f;
                    m_Phase = phase.phase_move;
                }
                transform.localScale = new Vector3(m_DissTime * 5, m_DissTime * 5, m_DissTime * 5);
                
                break;
            case phase.phase_move:
                if (Input.GetKey(KeyCode.R))
                {
                    transform.Rotate(Vector3.forward, m_RotateSpeed * Time.deltaTime);
                }
                if(Input.GetKey(KeyCode.A))
                {
                    transform.position -= new Vector3(m_MoveSpeed * Time.deltaTime, 0, 0);
                }
                if(Input.GetKey(KeyCode.D))
                {
                    transform.position += new Vector3(m_MoveSpeed * Time.deltaTime, 0, 0);
                }
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    m_Phase = phase.phase_fall;
                    m_Rb.gravityScale = 1;
                }
                break;
            case phase.phase_fall:
                if (m_Rb.velocity.y < -m_FallSpeed)
                {
                    m_Rb.gravityScale = 0;
                }
                else if (m_Rb.velocity.y > -m_FallSpeed + 0.1f) 
                {
                    m_Rb.gravityScale = 1;
                }
                break;
        }
    }
}
