using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BtnInvUI : ButtonAbstact
{
    [SerializeField] protected TextMeshProUGUI txtItemName;

    [SerializeField] protected TextMeshProUGUI txtItemCount;

    protected ItemIventory itemIventory;
    public ItemIventory ItemIventory => itemIventory;


    protected virtual void FixedUpdate() {
        this.ItemUpdating();
    }


    protected override void LoadComponents() {
        base.LoadComponents();
        this.LoadTxtItemName();
        this.LoadTxtItemCount();
    }

    protected virtual void LoadTxtItemName() {
        if (this.txtItemName != null) return;

        this.txtItemName = this.transform.Find("txtItemName").GetComponent<TextMeshProUGUI>();

        Debug.Log(transform.name + ": Load txtItemName", gameObject);

    }

    protected virtual void LoadTxtItemCount() {
        if (this.txtItemCount != null) return;

        this.txtItemCount = this.transform.Find("txtItemCount").GetComponent<TextMeshProUGUI>();

        Debug.Log(transform.name + ": Load txtItemCount", gameObject);
    }

    protected virtual void ItemUpdating() {
        
        this.txtItemName.text = this.itemIventory.itemName;
        this.txtItemCount.text = this.itemIventory.itemCount.ToString();

        if (itemIventory.itemCount == 0) {
            Destroy(this.gameObject);
            return;
        }
    }

    public virtual void SetItem(ItemIventory itemIventory) {
        this.itemIventory = itemIventory;
    }


   protected override void OnClick() {
        Debug.Log("Item clicked");
    }
}
