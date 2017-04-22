using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullyCollision : MonoBehaviour
{
    public GameObject m_Particles;
    private SphereCollider sphereCollider;
    // Use this for initialization
    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, sphereCollider.radius);
        foreach(Collider c in colliders)
        {
            if (c.tag.Equals("Player"))
            {
                SphereCollider otherCollider = (SphereCollider)c;
                if(otherCollider.radius > sphereCollider.radius)
                {
                    PauseManager.getInstance().RemovePausable(GetComponent<OrbitSun>());
                    GameObject particles = GameObject.Instantiate(m_Particles, transform.position, Quaternion.AngleAxis(180, Vector3.right));
                    Destroy(particles, 2.0f);
                    Destroy(gameObject);
                }
                float distanceApart = Vector3.Distance(c.gameObject.transform.position, transform.position);
                float overlap = distanceApart - sphereCollider.radius - otherCollider.radius;
                c.gameObject.transform.position += (transform.position - c.gameObject.transform.position).normalized * overlap;
            }
        }
    }
}
