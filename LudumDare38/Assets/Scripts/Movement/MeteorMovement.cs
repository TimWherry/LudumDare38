using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMovement : Pausable
{
    public float m_LifeTime = 7.5f;
    public float m_MinSpeed = 4.5f;
    public float m_MaxSpeed = 6.5f;
    // Use this for initialization
    void Start()
    {
    }

    private void Update()
    {
        if (!isPaused)
        {
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

    private void OnCollisionEnter(Collision collision)
    {
        if (!isPaused)
        {
            if (collision.gameObject.tag.Equals("Player"))
            {
                collision.gameObject.GetComponent<PlayerResources>().removeResources(Resource.eResource.Water, 2);
                collision.gameObject.GetComponent<PlayerResources>().removeResources(Resource.eResource.Soil, 2);
            }
            if (collision.gameObject.tag.Equals("Resource"))
            {
                Destroy(collision.gameObject);
            }
            Kill();
        }
    }

    private void Kill()
    {
        PauseManager.getInstance().RemovePausable(this);
        Destroy(gameObject);
    }
}
