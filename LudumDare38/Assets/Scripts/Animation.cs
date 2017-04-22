using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    public Sprite[] m_Sprites;
    private int index = 0;

    private new SpriteRenderer renderer;

    public float m_TotalAnimationTime = 0.0f;
    private float timer = 0.0f;
    // Use this for initialization
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        if(renderer == null)
        {
            Debug.LogError("No Renderer");
        }
        resetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0.0f)
        {
            resetTimer();
            index++;
            if (index >= m_Sprites.Length)
            {
                index = 0;
            }
            renderer.sprite = m_Sprites[index];
        }
    }

    private void resetTimer()
    {
        timer = m_TotalAnimationTime / m_Sprites.Length;
    }
}
