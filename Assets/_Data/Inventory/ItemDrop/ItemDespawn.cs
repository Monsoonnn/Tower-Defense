using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDespawn : Despawn<ItemDropCtrl> {

    public override void DoDespawn() {

        ItemDropCtrl itemDropCtrl = (ItemDropCtrl) this.parent;

        ItemIventory item = new ItemIventory();

        item.itemProfile = InventoryManager.Instance.GetProfileByName(itemDropCtrl.ItemCode);

        item.itemCount = itemDropCtrl.ItemCount;

        InventoryManager.Instance.GetByCodeName(itemDropCtrl.InventoryCodeName).AddItem(item);

        base.DoDespawn();

    }


}
