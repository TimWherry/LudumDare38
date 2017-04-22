using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMovement : MonoBehaviour
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
        m_LifeTime -= Time.deltaTime;
        if(m_LifeTime <= 0.0f)
        {
            Destroy(gameObject);
        }
    }

    public void sendInDirection(Vector3 direction)
    {
        GetComponent<Rigidbody>().velocity = direction.normalized * Random.Range(m_MinSpeed, m_MaxSpeed);
        transform.up = GetComponent<Rigidbody>().velocity.normalized;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Player was hit!");
        }
        Destroy(gameObject);
    }
}
