using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausable : MonoBehaviour
{
    private Vector3 pauseVelocity;
    [SerializeField]
    protected bool isPaused;

    public void Awake()
    {
        if(isPaused)
        {
            Pause();
        }
        PauseManager.getInstance().AddPausable(this);
    }

    public void Pause()
    {
        isPaused = true;
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        {
            pauseVelocity = body.velocity;
            body.velocity = Vector3.zero;
        }
    }

    public void Resume()
    {
        isPaused = false;
        if (gameObject != null)
        {
            Rigidbody body = GetComponent<Rigidbody>();
            if (body != null)
            {
                body.velocity = pauseVelocity;
            }
        }
        pauseVelocity = Vector3.zero;
    }
}
