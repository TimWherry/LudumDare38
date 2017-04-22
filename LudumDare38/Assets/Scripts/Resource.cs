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
    private eResource resourceType;

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
}
