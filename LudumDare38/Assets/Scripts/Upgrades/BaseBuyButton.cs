using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBuyButton : MonoBehaviour {
    public TextMesh m_UpgradeCost;
    public TextMesh m_UpgradeAmount;

    public PlayerResources m_PlayerResources;
    public UpgradeManager m_UpgradeManager;
    public BaseBuyButton m_OtherButton;

    public float m_ResourceScale = 1.2f;
    public int m_BaseCost = 3;
    protected int amountPurchased = 0;
    protected int resourcesNeeded = 0;
    public Resource.eResource m_ResourceNeeded = Resource.eResource.Null;

    public void SetupCosts(int amount)
    {
        amountPurchased = amount;
        CalcNextAmount();
        if (Mathf.Abs(m_OtherButton.amountPurchased - amountPurchased) >= 2)
        {
            m_UpgradeCost.text = "Can't Upgrade It Too Much Faster Than " + m_OtherButton.name;
        }
        else
        {
            m_UpgradeCost.text = resourcesNeeded + " " + m_ResourceNeeded.ToString();
        }
        m_UpgradeAmount.text = "" + amountPurchased;
    }

    private void CalcNextAmount()
    {
        resourcesNeeded = m_BaseCost;
        float needed = resourcesNeeded;
        for (int i = 0; i < amountPurchased; ++i)
        {
            needed = needed * m_ResourceScale;
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
                if (col.tag.Equals("BuyButton") && col.gameObject == gameObject)
                {
                    if (m_PlayerResources.getResourceAmount(m_ResourceNeeded) >= resourcesNeeded && Mathf.Abs(m_OtherButton.amountPurchased - amountPurchased) < 2)
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
