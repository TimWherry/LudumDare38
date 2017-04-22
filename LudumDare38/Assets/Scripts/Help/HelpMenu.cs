using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : MonoBehaviour
{
    public GameObject m_LeftButton, m_RightButton;
    public GameObject[] m_Pages;
    private int currentPage = 0;
    // Use this for initialization
    void Start()
    {
        currentPage = 0;
        setupCurrentPage();
        PauseManager.getInstance().Pause();
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
                if (col.name.Equals("left") && currentPage > 0)
                {
                    //left a page
                    currentPage--;
                    setupCurrentPage();
                }
                if (col.name.Equals("right") && currentPage < m_Pages.Length - 1)
                {
                    //right a page
                    currentPage++;
                    setupCurrentPage();
                }
            }
        }
    }

    private void setupCurrentPage()
    {
        TurnOffPages();
        m_Pages[currentPage].SetActive(true);

        if (currentPage <= 0)
        {
            m_LeftButton.SetActive(false);
        }
        else
        {
            m_LeftButton.SetActive(true);
        }
        if (currentPage >= m_Pages.Length - 1)
        {
            m_RightButton.SetActive(false);
        }
        else
        {
            m_RightButton.SetActive(true);
        }
    }

    private void TurnOffPages()
    {
        for(int i = 0; i < m_Pages.Length; ++i)
        {
            m_Pages[i].SetActive(false);
        }
    }
}
