using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryCtrl : NewMonobehavior
{
    protected List<ItemIventory> items = new();

    public List<ItemIventory> Items => items;
    public abstract InvCodeName GetName();

    public virtual void AddItem( ItemIventory item )
    {
        ItemIventory itemExist = this.FindItem(item.itemProfile.itemCodeName);

        if(!item.itemProfile.isStackable || itemExist == null)
        {
            item.itemID = Random.Range(0, 999999);
            item.itemName = item.itemProfile.itemName;
            items.Add(item);
            return;
        }
        itemExist.itemCount += item.itemCount;
    }

    public virtual ItemIventory FindItem(ItemCode itemCodeName) {
        foreach (ItemIventory item in items) {
            if(item.itemProfile.itemCodeName == itemCodeName) return item;
        }
        return null;
    }
}
