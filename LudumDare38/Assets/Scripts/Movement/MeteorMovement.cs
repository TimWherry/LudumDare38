using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMovement : Pausable
{
    public GameObject m_ParticleSystem;
    public AudioClip m_ImpactSound;
    public float m_LifeTime = 7.5f;
    public float m_MinSpeed = 4.5f;
    public float m_MaxSpeed = 6.5f;

    private new AudioSource audio;
    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
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
            else if (collision.gameObject.tag.Equals("Resource"))
            {
                collision.gameObject.GetComponent<Resource>().Kill();
            }
            HitWorld(collision.contacts[0].normal);
            Kill();
        }
    }

    private void HitWorld(Vector3 hitDirection)
    {
        float angle = Vector3.Angle(new Vector3(hitDirection.x, hitDirection.y, 0.0f), Vector3.right);
        GameObject particles = GameObject.Instantiate(m_ParticleSystem, transform.position, Quaternion.AngleAxis(180.0f, Vector3.right));
        Destroy(particles, 1.5f);
    }

    private void Kill()
    {
        PauseManager.getInstance().RemovePausable(this);
        Destroy(gameObject);
    }
}
