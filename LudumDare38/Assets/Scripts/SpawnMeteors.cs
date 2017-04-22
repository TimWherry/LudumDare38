using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMeteors : Pausable
{
    public GameObject m_MeteorPrefab;

    public float m_MinSpawnTime = 2.5f;
    public float m_MaxSpawnTime = 3.5f;

    private float spawnTimer = 0.0f;

    public float m_SpawnDistance = 30.0f;

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
                rollRandomMeteor();
            }
        }
    }

    private void rollRandomSpawnTime()
    {
        spawnTimer = Random.Range(m_MinSpawnTime, m_MaxSpawnTime);
    }

    private void rollRandomMeteor()
    {
        float angle = Random.Range(0.0f, Mathf.PI * 2.0f);
        GameObject newMeteor = GameObject.Instantiate(m_MeteorPrefab, new Vector3(Mathf.Cos(angle), Mathf.Sin(angle)) * m_SpawnDistance, Quaternion.identity);
        newMeteor.GetComponent<MeteorMovement>().sendInDirection(Vector3.zero - newMeteor.transform.position);
        newMeteor.GetComponent<Scaler>().m_Scale = m_Scale;
        Vector3 velocity = newMeteor.GetComponent<Rigidbody>().velocity;
        newMeteor.GetComponent<Rigidbody>().velocity = Vector3.zero;
        newMeteor.transform.Rotate(new Vector3(0.0f, 0.0f, Random.Range(-10.0f, 10.0f)));
        newMeteor.GetComponent<Rigidbody>().velocity = newMeteor.transform.up * velocity.magnitude * m_Scale;
    }
}
