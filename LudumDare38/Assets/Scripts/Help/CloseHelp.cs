using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseHelp : MonoBehaviour
{
    public GameObject m_HelpMenu;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Collider2D col = Physics2D.OverlapPoint(new Vector2(mousePos.x, mousePos.y));
            if (col != null)
            {
                if (col.gameObject == gameObject)
                {
                    m_HelpMenu.SetActive(false);
                    PauseManager.getInstance().Resume();
                }
            }
        }
    }
}
