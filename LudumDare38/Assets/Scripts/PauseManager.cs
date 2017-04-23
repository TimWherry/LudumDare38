using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private List<Pausable> m_Pausables = new List<Pausable>();

    private static PauseManager m_Instance = null;

    private bool gameEnded = false;
    public float m_FinishTimer = 2.5f;

    public static PauseManager getInstance()
    {
        if(m_Instance == null)
        {
            GameObject manager = new GameObject();
            manager.name = "PauseManager";
            m_Instance = manager.AddComponent<PauseManager>();
        }

        return m_Instance;
    }

    public void AddPausable(Pausable pausable)
    {
        m_Pausables.Add(pausable);
    }

    public void RemovePausable(Pausable pausable)
    {
        m_Pausables.Remove(pausable);
    }

    public void Pause()
    {
        foreach (Pausable pause in m_Pausables)
        {
            if (pause != null)
            {
                pause.Pause();
            }
        }
    }

    public void EndGame()
    {
        gameEnded = true;
        Pause();
    }

    public bool isGameEnded()
    {
        return gameEnded;
    }

    public void Resume()
    {
        if (!gameEnded)
        {
            foreach (Pausable pause in m_Pausables)
            {
                if (pause != null)
                {
                    pause.Resume();
                }
            }
        }
    }

    private void Update()
    {
        if(gameEnded)
        {
            m_FinishTimer -= Time.deltaTime;
            if (m_FinishTimer <= 0.0f)
            {
                if (Input.anyKey)
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene("menu");
                }
            }
        }
    }
}
