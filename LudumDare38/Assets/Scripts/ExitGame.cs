using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public GameObject[] m_BullyPlanets;
    public GameObject m_WinScreen;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if(areBulliesDead())
        {
            // WIN GAME
            m_WinScreen.SetActive(true);
            PauseManager.getInstance().EndGame();
        }
    }

    private bool areBulliesDead()
    {
        int count = 0;
        for(int i = 0; i < m_BullyPlanets.Length; ++i)
        {
            if(m_BullyPlanets[i] == null)
            {
                count++;
            }
        }
        return count == m_BullyPlanets.Length;
    }
}
