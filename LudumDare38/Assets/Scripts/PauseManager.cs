using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private List<Pausable> m_Pausables = new List<Pausable>();

    private static PauseManager m_Instance = null;

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
    public void Resume()
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
