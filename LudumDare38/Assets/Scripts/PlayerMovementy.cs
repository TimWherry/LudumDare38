using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementy : OrbitSun
{
    public float m_PlayerMovementPower = 0.1f;
    public float m_PlayerMovementMax = 1.5f;
    private Vector3 playerMovementHistory;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	new void Update () {
        base.Update();
        Vector3 playerMovement = new Vector3();

        if (Input.GetKey(KeyCode.A))
        {
            playerMovement.x -= m_PlayerMovementPower;
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerMovement.x += m_PlayerMovementPower;
        }
        if (Input.GetKey(KeyCode.W))
        {
            playerMovement.y += m_PlayerMovementPower;
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerMovement.y -= m_PlayerMovementPower;
        }

        playerMovementHistory += playerMovement;
        playerMovementHistory.x = Mathf.Clamp(playerMovementHistory.x, -m_PlayerMovementMax, m_PlayerMovementMax);
        playerMovementHistory.y = Mathf.Clamp(playerMovementHistory.y, -m_PlayerMovementMax, m_PlayerMovementMax);

        transform.Translate(playerMovementHistory);
    }
}
