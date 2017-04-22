using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    public GameObject m_SpriteHolder;
    public SphereCollider m_SphereCollider;
    public float m_Scale = 1.0f;
    // Use this for initialization
    void Start()
    {
        Scale(m_Scale);
    }

    public void Scale(float scale)
    {
        m_Scale = scale;
        m_SpriteHolder.transform.localScale = new Vector3(m_Scale, m_Scale, 1.0f);
        m_SphereCollider.radius *= m_Scale;
    }
}
