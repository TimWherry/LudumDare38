using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyOrbit : BaseBuyButton
{
    public override void PurchaseUpgrade()
    {
        m_UpgradeManager.increaseOrbit();
        Debug.Log("here");
    }
}
