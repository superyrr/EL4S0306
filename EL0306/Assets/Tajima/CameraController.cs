using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform m_Generator;
    [SerializeField]
    private float m_Speed = 0.2f;

    private float m_Distance;

    private void Start()
    {
        m_Distance = m_Generator.position.y - transform.position.y;
    }

    private void Update()
    {
        if (transform.position.y < m_Generator.position.y)
        {
            transform.position.SetY(Mathf.Min(transform.position.y + m_Speed, m_Generator.position.y - m_Distance));
        }
    }
}
