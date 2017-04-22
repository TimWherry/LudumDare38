using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBuyButton : MonoBehaviour {
    public TextMesh m_UpgradeCost;
    public TextMesh m_UpgradeAmount;

    public PlayerResources m_PlayerResources;
    public UpgradeManager m_UpgradeManager;

    public float m_ResourceScale = 1.2f;
    public int m_BaseCost = 3;
    protected int amountPurchased = 0;
    protected int resourcesNeeded = 0;
    public Resource.eResource m_ResourceNeeded = Resource.eResource.Null;

    public void SetupCosts(int amount)
    {
        amountPurchased = amount;
        CalcNextAmount();
        m_UpgradeCost.text = resourcesNeeded + " " + m_ResourceNeeded.ToString();
        m_UpgradeAmount.text = "" + amountPurchased;
    }

    private void CalcNextAmount()
    {
        resourcesNeeded = m_BaseCost;
        float needed = resourcesNeeded;
        for (int i = 0; i < amountPurchased; ++i)
        {
            needed = resourcesNeeded * m_ResourceScale;
        }

        resourcesNeeded = Mathf.CeilToInt(needed);

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
                if (col.tag.Equals("BuyButton"))
                {
                    if (m_PlayerResources.getResourceAmount(m_ResourceNeeded) >= resourcesNeeded)
                    {
                        m_PlayerResources.removeResources(m_ResourceNeeded, resourcesNeeded);
                        PurchaseUpgrade();
                        SetupCosts(amountPurchased + 1);
                    }
                }
            }
        }
    }

    public abstract void PurchaseUpgrade();
}
