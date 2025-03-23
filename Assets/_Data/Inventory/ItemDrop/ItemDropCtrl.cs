using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropCtrl : SpawnableObj {

    [SerializeField] protected Rigidbody _rb;
    public Rigidbody Rb => this._rb;

    protected ItemCode itemCode;
    protected InvCodeName inventoryCodeName = InvCodeName.Items;
    protected int itemCount = 1;

    public ItemCode ItemCode => this.itemCode;
    public InvCodeName InventoryCodeName => this.inventoryCodeName;
    public int ItemCount => this.itemCount;


    public override string GetName() {
        return "ItemDrop";
    }

    public void SetValue( ItemCode itemCode, int itemCount ) {
        this.itemCode = itemCode;
        this.itemCount = itemCount;
    }

    public virtual void SetValue( ItemCode itemCode, int itemCount, InvCodeName iventoryCodeName ) { 
        this.itemCode = itemCode;
        this.itemCount = itemCount;
        this.inventoryCodeName = iventoryCodeName;
    }

    protected override void LoadComponents() {
        base.LoadComponents();
        this.LoadRigiBody();
    }

    protected virtual void LoadRigiBody() {
        if (this._rb != null) return;
        this._rb = GetComponent<Rigidbody>();
        Debug.Log(transform.name + ": LoadRigiBody", gameObject);
    }
}

    
