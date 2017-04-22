using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    public TextMesh m_Display;
    private int[] m_ResourceCount;
    // Use this for initialization
    void Start()
    {
        m_ResourceCount = new int[(int)Resource.eResource.Max];
    }

    private void Update()
    {
        m_Display.text = "";
        for(int i = 0; i < (int)Resource.eResource.Max; ++i)
        {
            m_Display.text += (Resource.eResource)i + ": " + m_ResourceCount[i] + "\n";
        }
    }

    public int getResourceAmount(Resource.eResource resource)
    {
        return m_ResourceCount[(int)resource];
    }

    public void removeResources(Resource.eResource resource, int amount)
    {
        m_ResourceCount[(int)resource] -= amount;
        if(m_ResourceCount[(int)resource] <= 0)
        {
            m_ResourceCount[(int)resource] = 0;
        }
    }


    public void incrementResource(Resource.eResource resource)
    {
        m_ResourceCount[(int)resource]++;
    }
}
