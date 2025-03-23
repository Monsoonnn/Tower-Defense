using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelByItem : LevelAbstact
{
    [SerializeField] protected ItemIventory playerExp;

    protected override int GetCurrentExp() { 
        if(this.GetPlayerExp() == null) return 0;
        return this.GetPlayerExp().itemCount;
    }

    protected override bool DeductExp(int exp) {
        return this.GetPlayerExp().Deduct(exp);
    }

    protected virtual ItemIventory GetPlayerExp() {
       if(this.playerExp == null || this.playerExp.itemID == 0) this.playerExp = InventoryManager.Instance.Monies().FindItem(ItemCode.Exp);
       return this.playerExp;
    }

}
