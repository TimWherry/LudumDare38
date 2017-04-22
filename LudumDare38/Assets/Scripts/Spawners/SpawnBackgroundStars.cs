using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBackgroundStars : Pausable
{
    public GameObject m_StarPrefab;

    public GameObject m_ResourceAnchor, m_UpgradeAnchor;

    public float m_MinSpawnTime = 0.5f;
    public float m_MaxSpawnTime = 1.0f;

    private float spawnTimer = 0.0f;

    public float m_Scale = 1.0f;

    // Use this for initialization
    void Start()
    {
        rollRandomSpawnTime();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPaused)
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0.0f)
            {
                rollRandomSpawnTime();
                rollRandomStar();
            }
        }
    }

    private void rollRandomSpawnTime()
    {
        spawnTimer = Random.Range(m_MinSpawnTime, m_MaxSpawnTime);
    }
    private void rollRandomStar()
    {
        Vector3 spawnPos = new Vector3();
        spawnPos.x = Random.Range(m_ResourceAnchor.transform.position.x * 1.1f, m_UpgradeAnchor.transform.position.x * 1.1f);
        spawnPos.y = m_ResourceAnchor.transform.position.y * 1.1f;
        spawnPos.z = 10;
        GameObject newStar = GameObject.Instantiate(m_StarPrefab, spawnPos, Quaternion.identity);
        newStar.GetComponent<Scaler>().m_Scale = m_Scale;
    }
}
