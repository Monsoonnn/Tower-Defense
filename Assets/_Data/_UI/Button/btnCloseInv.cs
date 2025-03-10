using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCloseInv : ButtonAbstact
{
    protected virtual void CloseInventoryUI() { 
        InventoryUI.Instance.HideUI();
    }


    protected override void OnClick() {
        this.CloseInventoryUI();
    }
}
