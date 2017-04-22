using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    public GameObject m_SpriteHolder;
    public SphereCollider m_SphereCollider;
    public float m_Scale = 1.0f;
    private float initialRadius;
    // Use this for initialization
    void Start()
    {
        if (m_SphereCollider != null)
        {
            initialRadius = m_SphereCollider.radius;
        }
        Scale(m_Scale);
    }

    public void Scale(float scale)
    {
        m_Scale = scale;
        m_SpriteHolder.transform.localScale = new Vector3(m_Scale, m_Scale, 1.0f);
        if (m_SphereCollider != null)
        {
            m_SphereCollider.radius = initialRadius * m_Scale;
        }
    }
}
