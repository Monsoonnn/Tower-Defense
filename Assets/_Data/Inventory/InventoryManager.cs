using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : SingletonCtrl<InventoryManager> {
    [SerializeField] protected List<InventoryCtrl> inventories;
    [SerializeField] protected List<ItemProfileSO> itemProfiles;

    protected override void LoadComponents() {
        base.LoadComponents();
        this.LoadInventoryCtrl();
        this.AddItem();
    }

    protected virtual void LoadInventoryCtrl() {
        if (this.inventories.Count > 0) return;
        this.inventories = new List<InventoryCtrl>(GameObject.FindObjectsOfType<InventoryCtrl>());
        Debug.Log(transform.name + ": LoadLoadInventoryCtrl ", gameObject);
    }

    protected virtual void AddItem() {

        for (int i = 0; i < 10; i++) {

            ItemIventory newItem = new ItemIventory();
           
            newItem.itemProfile = this.GetProfileByName(ItemCode.Grenades);
            newItem.itemCount = 1;

            this.Items().AddItem(newItem);

        }



    }


    public virtual InventoryCtrl GetByName( InvCodeName name ) {
        foreach (InventoryCtrl inventory in this.inventories) {
            if (inventory.GetName() == name) return inventory;
        }
        return null;
    }

    public virtual ItemProfileSO GetProfileByName( ItemCode itemCodeName ) {
        foreach (ItemProfileSO profile in this.itemProfiles) {
            if (profile.itemCodeName == itemCodeName) return profile;
        }
        return null;
    }

    public virtual InventoryCtrl Monies() { 
        return this.GetByName(InvCodeName.Monies);
    }

    public virtual InventoryCtrl Items() {
        return this.GetByName(InvCodeName.Items);
    }
}   
