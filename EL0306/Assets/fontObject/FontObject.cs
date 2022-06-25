using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FontObject : MonoBehaviour
{
    enum phase
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
    // Start is called before the first frame update
    void Start()
    {
        m_Rb = GetComponent<Rigidbody2D>();
        m_Rb.gravityScale = 0;
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
                break;
        }
    }
}