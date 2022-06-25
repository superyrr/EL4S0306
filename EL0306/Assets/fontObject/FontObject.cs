using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FontObject : MonoBehaviour
{
    // “c“‡’Ç‰Á
    public phase Phaze => m_Phase;

    public enum phase
    {
        phase_move,
        phase_fall
    }
    private phase m_Phase = phase.phase_move;
    [SerializeField]
    private float m_RotateSpeed = 20;
    [SerializeField]
    private float m_MoveSpeed = 20;
    [SerializeField]
    private float m_FallSpeed;

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
        switch(m_Phase)
        {
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
                if(m_Rb.velocity.y<-1)
                {
                    m_Rb.gravityScale = 0;
                }
                else if(m_Rb.velocity.y>-0.5)
                {
                    m_Rb.gravityScale = 1;
                }
                break;
        }
    }
}
