using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMeteors : MonoBehaviour
{
    public GameObject m_MeteorPrefab;

    public float m_MinSpawnTime = 2.5f;
    public float m_MaxSpawnTime = 3.5f;

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
        if (spawnTimer <= 0.0f)
        {
            rollRandomSpawnTime();
            rollRandomMeteor();
        }

    }

    private void rollRandomSpawnTime()
    {
        spawnTimer = Random.Range(m_MinSpawnTime, m_MaxSpawnTime);
    }

    private void rollRandomMeteor()
    {
        Vector2 randomCircle = Random.insideUnitCircle;
        GameObject newMeteor = GameObject.Instantiate(m_MeteorPrefab, new Vector3(randomCircle.x, randomCircle.y) * 20.0f, Quaternion.identity);
        newMeteor.GetComponent<MeteorMovement>().sendInDirection(Vector3.zero - newMeteor.transform.position);
        Vector3 velocity = newMeteor.GetComponent<Rigidbody>().velocity;
        newMeteor.GetComponent<Rigidbody>().velocity = Vector3.zero;
        newMeteor.transform.Rotate(new Vector3(0.0f, 0.0f, Random.Range(-30.0f, 30.0f)));
        newMeteor.GetComponent<Rigidbody>().velocity = newMeteor.transform.up * velocity.magnitude;
    }
}
