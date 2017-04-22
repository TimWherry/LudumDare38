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

    public void incrementResource(Resource.eResource resource)
    {
        m_ResourceCount[(int)resource]++;
        Debug.Log(resource.ToString() + " = " + m_ResourceCount[(int)resource]);
    }
}
