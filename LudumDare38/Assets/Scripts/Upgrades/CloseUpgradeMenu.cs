using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseUpgradeMenu : MonoBehaviour {

    public UpgradeMenu m_UpgradeMenu;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Collider2D col = Physics2D.OverlapPoint(new Vector2(mousePos.x, mousePos.y));
            if (col != null)
            {
                if (col.tag.Equals("CloseButton"))
                {
                    m_UpgradeMenu.CloseMenu();
                }
            }
        }
    }
}
