using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : SingletonCtrl<InventoryUI>
{
    protected bool isShow = true;

    bool IsShow => isShow;

    [SerializeField] protected BtnInvUI defaultItemInventoryUI;

    protected List<BtnInvUI> btnItems = new List<BtnInvUI>();


    protected virtual void FixedUpdate() { 
        this.ItemUpdating();
    }


    protected override void Start()
    {
        base.Start();
        this.HideUI();
        this.HideDefaultItemInvPrefab();
    }

    protected override void LoadComponents() {
        base.LoadComponents();
        this.LoadBtnInventory();
    }


    protected virtual void LoadBtnInventory() { 
        if(this.defaultItemInventoryUI != null) return;

        this.defaultItemInventoryUI = GetComponentInChildren<BtnInvUI>();

        Debug.Log(transform.name + ": LoadBtnInventory", gameObject);
    }

    public virtual void HideDefaultItemInvPrefab() { 
        this.defaultItemInventoryUI.gameObject.SetActive(false);
    }


    protected virtual void ItemUpdating() {
        InventoryCtrl itemInvCtrl = InventoryManager.Instance.Items();
        foreach (ItemIventory item in itemInvCtrl.Items) {

            BtnInvUI newBtnItem = this.GetExistItem(item);

            if (newBtnItem == null) {

                newBtnItem = Instantiate(this.defaultItemInventoryUI, this.defaultItemInventoryUI.transform.parent);

                newBtnItem.SetItem(item);

                newBtnItem.gameObject.SetActive(true);

                newBtnItem.name = item.itemName+ " - " + newBtnItem.name;

                this.btnItems.Add(newBtnItem);
            }

        }
    }

    protected virtual BtnInvUI GetExistItem(ItemIventory itemIventory) {
        foreach (BtnInvUI itemUI in this.btnItems) {
            if (itemUI.ItemIventory.itemID == itemIventory.itemID) {
                return itemUI;
            }
        }
        return null;
    }

    public virtual void HideUI()
    {
        this.gameObject.SetActive(false);
        this.isShow = false;
    }

    public virtual void ShowUI()
    {
        this.gameObject.SetActive(true);
        this.isShow = true; 
    }

    public virtual void ToggleUI()
    {
        if (IsShow)
        {
            HideUI();
        }
        else
        {
            ShowUI();
        }
    }

}
