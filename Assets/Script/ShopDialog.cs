using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class ShopDialog : Dialog
{
    public Transform gridRoot;
    public ShopItem itemUI;

    public override void Show(bool isShow)
    {
        base.Show(isShow);

        UpdateUI();
    }

    private void UpdateUI()
    {
        var items = ShopManage.Ins.items;

        if (items == null || items.Length <= 0 || !gridRoot || !itemUI) return;

        clearChild();

        for(int i = 0; i < items.Length; i++)
        {
            int idx = i;

            var item = items[i];

            if(item != null)
            {
                var itemUIClone = Instantiate(itemUI, Vector3.zero, Quaternion.identity);

                itemUIClone.transform.SetParent(gridRoot);

                itemUIClone.transform.localPosition = Vector3.zero;

                itemUIClone.transform.localScale = Vector3.one;

                itemUIClone.UpdateUI(item, idx);

                if (itemUIClone.btn)
                {
                    itemUIClone.btn.onClick.RemoveAllListeners();
                    itemUIClone.btn.onClick.AddListener(() => ItemEvent(item, idx));
                }
            }
        }
    }

    void ItemEvent(Shop item, int shopItemId)
    {
        if (item == null) return;

        bool isUnlocked = Pref.GetBool(PrefConst.PLAYER_PEFIX + shopItemId);

        if (isUnlocked)
        {
            if (shopItemId == Pref.CurPlayerId) return;

            Pref.CurPlayerId = shopItemId;

            //GameManage.Ins.ActivePlayer();

            UpdateUI();
        }
        else
        {
            if(Pref.Coins >= item.price)
            {
                Pref.Coins -= item.price;

                Pref.SetBool(PrefConst.PLAYER_PEFIX + shopItemId, true);

                Pref.CurPlayerId = shopItemId;

                GUIManage.Ins.UpdateCoin();

                //GameManage.Ins.ActivePlayer();

                UpdateUI();
            }
            else
            {
                Debug.Log("You don't have enough coin");
            }
        }
    }

    public void clearChild()
    {
        if (!gridRoot || gridRoot.childCount <= 0) return;

        for(int i = 0; i < gridRoot.childCount; i++)
        {
            var child= gridRoot.GetChild(i);

            if (child) 
                Destroy(child.gameObject);
        }
    }
}
