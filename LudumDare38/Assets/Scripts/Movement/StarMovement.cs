using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMovement : Pausable
{
    public float m_LifeTime = 60.5f;
    public float m_MinSpeed = 1.5f;
    public float m_MaxSpeed = 6.5f;

    // Use this for initialization
    void Start()
    {
        GetComponent<Scaler>().Scale(Random.Range(0.9f, 1.1f));
    }

    private void Update()
    {
        if (!isPaused)
        {
            sendInDirection(-Vector3.up);
            m_LifeTime -= Time.deltaTime;
            if (m_LifeTime <= 0.0f)
            {
                Kill();
            }
        }
    }
    public void sendInDirection(Vector3 direction)
    {
        GetComponent<Rigidbody>().velocity = direction.normalized * Random.Range(m_MinSpeed, m_MaxSpeed);
        transform.up = GetComponent<Rigidbody>().velocity.normalized;
    }

    private void Kill()
    {
        PauseManager.getInstance().RemovePausable(this);
        Destroy(gameObject);
    }
}
