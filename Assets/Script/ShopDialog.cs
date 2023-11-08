using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopDialog : Dialog
{
    public Transform girdRoot;
    public ShopItem itemUI;

    public override void Show(bool isShow)
    {
        base.Show(isShow);

        UpdateUI();
    }

    private void UpdateUI()
    {
        var items = ShopManage.Ins.items;
        if (items == null || items.Length <= 0 || !girdRoot || !itemUI) return;

        for(int  i = 0; i < items.Length; i++)
        {
            int index = i;

            var item = items[i]; 
            if(item != null)
            {
                var itemUIClone = Instantiate(itemUI, Vector3.zero, Quaternion.identity);
            }
        }
    }
}
