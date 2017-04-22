using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : Pausable
{
    public enum eResource
    {
        Null = -1,
        Water = 0,
        Soil = 1,
        Max = 2,
    }
    public Sprite[] m_ResourceSprites;
    public float m_Speed = 2.5f;
    public float m_Lifetime = 15.0f;
    private eResource resourceType;

    public void rollRandomDirection()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        body.velocity = new Vector3(Random.insideUnitCircle.x, Random.insideUnitCircle.y) * m_Speed;
    }

    // Use this for initialization
    void Start()
    {
        resourceType = (eResource)Random.Range(0, (int)eResource.Max);
        if ((int)resourceType > -1 && (int)resourceType < m_ResourceSprites.Length)
        {
            GetComponent<Scaler>().m_SpriteHolder.GetComponent<SpriteRenderer>().sprite = m_ResourceSprites[(int)resourceType];
        }
    }

    private void Update()
    {
        if (!isPaused)
        {
            m_Lifetime -= Time.deltaTime;
            if (m_Lifetime <= 0.0f)
            {
                Kill();
            }
        }
    }

    public eResource getResource()
    {
        return resourceType;
    }

    public void OnCollisionEnter(Collision collision)
    {
        OnCollision(collision);
    }
    public void OnCollisionExit(Collision collision)
    {
        OnCollision(collision);
    }
    public void OnCollisionStay(Collision collision)
    {
        OnCollision(collision);
    }

    private void OnCollision(Collision collision)
    {
        if (!isPaused)
        {
            if (collision.gameObject.tag.Equals("Player"))
            {
                collision.gameObject.GetComponent<PlayerResources>().incrementResource(resourceType);
                Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
                Kill();
            }
        }
    }

    private void Kill()
    {
        PauseManager.getInstance().RemovePausable(this);
        Destroy(gameObject);
    }
}
