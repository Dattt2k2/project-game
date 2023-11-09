using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManage : Singleton<GUIManage>
{

    public Text cointCounting;
    public override void Awake()
    {
        MakeSingleton(false);
    }

    public void UpdateCoin()
    {
        if (cointCounting)
        {
            cointCounting.text = "COINS: " + Pref.Coins;
        }
    }
}
