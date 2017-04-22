using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    private int[] m_ResourceCount;
    // Use this for initialization
    void Start()
    {
        m_ResourceCount = new int[(int)Resource.eResource.Max];
    }

    public void incrementResource(Resource.eResource resource)
    {
        m_ResourceCount[(int)resource]++;
        Debug.Log(resource.ToString() + " = " + m_ResourceCount[(int)resource]);
    }
}
