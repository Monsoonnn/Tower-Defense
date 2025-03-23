using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : SingletonCtrl<InventoryManager> {
    [SerializeField] protected List<InventoryCtrl> inventories;
    [SerializeField] protected List<ItemProfileSO> itemProfiles;

    protected override void LoadComponents() {
        base.LoadComponents();
        this.LoadInventoryCtrl();
        this.LoadItemProfiles();
    }

    protected virtual void LoadItemProfiles() { 
        if (this.itemProfiles.Count > 0) return;
        this.itemProfiles = new List<ItemProfileSO>(Resources.LoadAll<ItemProfileSO>("/"));
        Debug.Log(transform.name + ": LoadItemProfiles ", gameObject);
    }

    protected virtual void LoadInventoryCtrl() {
        if (this.inventories.Count > 0) return;
        this.inventories = new List<InventoryCtrl>(GameObject.FindObjectsOfType<InventoryCtrl>());
        Debug.Log(transform.name + ": LoadLoadInventoryCtrl ", gameObject);
    }



    public virtual InventoryCtrl GetByCodeName( InvCodeName name ) {
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
        return this.GetByCodeName(InvCodeName.Currency);
    }

    public virtual InventoryCtrl Items() {
        return this.GetByCodeName(InvCodeName.Items);
    }


    // Testing

    [ProButton]
    public virtual void AddItems( ItemCode itemCode, int count) {

        for (int i = 0; i < count; i++) {
            ItemIventory newItem = new ItemIventory();

            newItem.itemProfile = this.GetProfileByName(itemCode);
            newItem.itemCount = 1;

            this.Items().AddItem(newItem);
        }


        }
    [ProButton]
    public virtual void RemoveItem( ItemCode itemCode, int count ) {


        for (int i = 0; i < count; i++) {
            ItemIventory newItem = new ItemIventory();

            newItem.itemProfile = this.GetProfileByName(itemCode);
            newItem.itemCount = 1;

            this.Items().RemoveItem(newItem);
        }


    }

    [ProButton]
    public virtual void AddGold(int count) {


            ItemIventory newItem = new ItemIventory();

            newItem.itemProfile = this.GetProfileByName(ItemCode.Monies);
            newItem.itemCount = count;

            this.Monies().AddItem(newItem);


    }

    [ProButton]
    public virtual void RemoveGold( int count ) {


        ItemIventory newItem = new ItemIventory();

        newItem.itemProfile = this.GetProfileByName(ItemCode.Monies);
        newItem.itemCount = count;

        this.Monies().RemoveItem(newItem);


    }
}   
