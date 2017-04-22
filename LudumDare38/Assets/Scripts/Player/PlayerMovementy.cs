using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementy : OrbitSun
{
    public float m_PlayerMovementPower = 0.1f;
    public float m_PlayerMovementMax = 1.5f;
    public LineRenderer m_LineRenderer;
    public int m_LineSegments = 10;
    public float m_LineTStep = 0.15f;
    private Vector3 playerMovementHistory;

    // Use this for initialization
    void Start () {
        m_LineRenderer.numPositions = m_LineSegments;
        setLinePoints();
    }
	
	// Update is called once per frame
	new void FixedUpdate () {
        if (!isPaused)
        {
            base.FixedUpdate();
            Vector3 playerMovement = new Vector3();

            tMulti -= 0.05f;
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
            if (Input.GetKey(KeyCode.Space))
            {
                tMulti += 0.1f;
            }
            tMulti = Mathf.Clamp(tMulti, 1.0f, 2.0f);


            playerMovementHistory += playerMovement;
            playerMovementHistory.x = Mathf.Clamp(playerMovementHistory.x, -m_PlayerMovementMax, m_PlayerMovementMax);
            playerMovementHistory.y = Mathf.Clamp(playerMovementHistory.y, -m_PlayerMovementMax, m_PlayerMovementMax);

            transform.Translate(playerMovementHistory);
            setLinePoints();
        }
    }

    private void setLinePoints()
    {
        for(int i = 0; i < m_LineSegments; ++i)
        {
            Vector3 futurePosition = Vector3.zero;
            futurePosition.x += getXPosition(t + i * m_LineTStep * tMulti) + playerMovementHistory.x;
            futurePosition.y += getYPosition(t + i * m_LineTStep * tMulti) + playerMovementHistory.y;
            futurePosition.z += 0.01f;
            m_LineRenderer.SetPosition(i, futurePosition);
        }
    }
}
