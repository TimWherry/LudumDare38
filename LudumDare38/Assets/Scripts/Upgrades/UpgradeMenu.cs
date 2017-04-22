using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour {
    public BuyOrbit m_BuyOrbit;
    public BuySize m_BuySize;
    public UpgradeManager m_UpgradeManager;

	public void OpenMenu()
    {
        PauseManager.getInstance().Pause();
        m_BuyOrbit.SetupCosts(m_UpgradeManager.getPlayerOrbitIncrease());
        m_BuyOrbit.m_UpgradeManager = m_UpgradeManager;
        m_BuySize.SetupCosts(m_UpgradeManager.getPlayerSizeIncrease());
        m_BuySize.m_UpgradeManager = m_UpgradeManager;
        gameObject.SetActive(true);
    }

    public void CloseMenu()
    {
        PauseManager.getInstance().Resume();
        gameObject.SetActive(false);
    }
}
