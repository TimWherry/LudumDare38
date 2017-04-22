using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnResources : MonoBehaviour
{
    public GameObject m_ResourcePrefab;
    public float m_MinSpawnTime = 1.5f;
    public float m_MaxSpawnTime = 5.5f;
    private float spawnTimer = 0.0f;
    // Use this for initialization
    void Start()
    {
        rollRandomSpawnTime();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if(spawnTimer <= 0.0f)
        {
            rollRandomSpawnTime();
            spawnRandomResource();
        }

    }

    private void rollRandomSpawnTime()
    {
        spawnTimer = Random.Range(m_MinSpawnTime, m_MaxSpawnTime);
    }

    private void spawnRandomResource()
    {
        GameObject newResource = GameObject.Instantiate(m_ResourcePrefab, transform.position, Quaternion.identity);
        // send it in random direction
    }
}
