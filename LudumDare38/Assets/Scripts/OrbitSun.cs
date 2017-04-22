using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitSun : MonoBehaviour
{
    public GameObject m_CenterObject;
    public float m_OrbitSize = 5.0f;//sure thats good
    private float t = 0.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    protected void Update()
    {
        t += Time.deltaTime;
        if(t >= Mathf.PI * 2.0f)
        {
            t = 0.0f;
        }

        transform.Translate(-transform.position);

        transform.Translate(new Vector3(m_OrbitSize * Mathf.Cos(t), 0.5f * m_OrbitSize * Mathf.Sin(t)));
    }
}
