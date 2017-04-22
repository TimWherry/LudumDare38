using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuySize : BaseBuyButton
{
    public override void PurchaseUpgrade()
    {
        m_UpgradeManager.increaseSize();
    }
}
