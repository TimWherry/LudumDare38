using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullyCollision : MonoBehaviour
{
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
                float distanceApart = Vector3.Distance(c.gameObject.transform.position, transform.position);
                float overlap = distanceApart - sphereCollider.radius - otherCollider.radius;
                Debug.Log(overlap);
                c.gameObject.transform.position += (transform.position - c.gameObject.transform.position).normalized * overlap;
            }
        }
    }
}
