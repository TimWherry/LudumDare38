using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
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
            GetComponent<SpriteRenderer>().sprite = m_ResourceSprites[(int)resourceType];
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
        if(collision.gameObject.tag.Equals("Player"))
        {
            collision.gameObject.GetComponent<PlayerResources>().incrementResource(resourceType);
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
            Destroy(gameObject);
        }
    }
}
