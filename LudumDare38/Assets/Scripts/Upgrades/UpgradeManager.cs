using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour {
    public SpawnMeteors m_SpawnMeteors;
    public SpawnResources m_SpawnResources;
    public GameObject m_Player;
    public Camera m_Camera;
    public GameObject m_ResourceTextAnchor;
    public GameObject m_UpgradeButtonAnchor;

    private int m_PlayerSizeIncrease = 0;
    private int m_PlayerOrbitIncrease = 0;

    public int getPlayerSizeIncrease()
    {
        return m_PlayerSizeIncrease;
    }
    public int getPlayerOrbitIncrease()
    {
        return m_PlayerOrbitIncrease;
    }

    public float m_ScaleChange = 1.1f;

    public void increaseOrbit()
    {
        m_PlayerOrbitIncrease++;
        m_Player.GetComponent<OrbitSun>().m_OrbitSize *= m_ScaleChange;
        m_ResourceTextAnchor.transform.position = new Vector3(m_ResourceTextAnchor.transform.position.x * m_ScaleChange, m_ResourceTextAnchor.transform.position.y * m_ScaleChange, m_ResourceTextAnchor.transform.position.z);
        m_UpgradeButtonAnchor.transform.position = new Vector3(m_UpgradeButtonAnchor.transform.position.x * m_ScaleChange, m_UpgradeButtonAnchor.transform.position.y * m_ScaleChange, m_UpgradeButtonAnchor.transform.position.z);
        m_Camera.orthographicSize *= m_ScaleChange;
        m_SpawnResources.m_Scale = getScaleFromOrbit();
        m_SpawnMeteors.m_Scale = getScaleFromOrbit();
    }

    public void increaseSize()
    {
        m_PlayerSizeIncrease++;
        m_Player.GetComponent<Scaler>().Scale(m_Player.GetComponent<Scaler>().m_Scale * m_ScaleChange);
    }

    private float getScaleFromOrbit()
    {
        float scale = 1.0f;
        for (int i = 0; i < m_PlayerOrbitIncrease; ++i)
        {
            scale *= m_ScaleChange;
        }
        return scale;
    }
}
