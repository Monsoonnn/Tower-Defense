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

    public virtual bool RemoveItem ( ItemIventory item ) {
        ItemIventory itemExist = this.FindItemNotEmpty(item.itemProfile.itemCodeName);

        if(itemExist == null) return false;
        if(itemExist.itemCount < item.itemCount ) return false;
        
        itemExist.itemCount -= item.itemCount;
        if(itemExist.itemCount == 0) items.Remove(itemExist);
        return true;
    }


    public virtual ItemIventory FindItem(ItemCode itemCodeName) {
        foreach (ItemIventory item in items) {
            if(item.itemProfile.itemCodeName == itemCodeName) return item;
        }
        return null;
    }

    public virtual ItemIventory FindItemNotEmpty( ItemCode itemCodeName ) {
        foreach (ItemIventory item in items) {
            if (item.itemProfile.itemCodeName != itemCodeName) continue;
            if (item.itemCount > 0) return item;
            }
        return null;
    }
}
