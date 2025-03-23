using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextExpCouint : TextAbstact
{
    protected virtual void FixedUpdate() {
        this.LoadGoldCount();
    }

    protected virtual void LoadGoldCount() {

        ItemIventory item = InventoryManager.Instance.Monies().FindItem(ItemCode.Exp);
        string goldCount;
        if (item == null) goldCount = "0";
        else goldCount = item.itemCount.ToString();
        this.textPro.text = goldCount;
    }
}
