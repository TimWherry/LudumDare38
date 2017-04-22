using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitSun : Pausable
{
    public GameObject m_CenterObject;
    public float m_OrbitSize = 5.0f;
    protected float t = 0.0f;
    protected float tMulti = 1.0f;

    // Use this for initialization
    void Start()
    {
        t = Random.Range(0.0f, Mathf.PI * 2.0f);
        tMulti = Random.Range(0.7f, 1.3f);
    }

    // Update is called once per frame
    protected void FixedUpdate()
    {
        if (!isPaused)
        {
            t += Time.fixedDeltaTime * tMulti;
            if (t >= Mathf.PI * 2.0f)
            {
                t = 0.0f;
            }

            transform.Translate(-transform.position);

            transform.Translate(new Vector3(getXPosition(t), getYPosition(t)));
        }
    }

    protected float getYPosition(float _t)
    {
        return 0.5f * m_OrbitSize * Mathf.Sin(_t);
    }

    protected float getXPosition(float _t)
    {
        return m_OrbitSize * Mathf.Cos(_t);
    }
}
