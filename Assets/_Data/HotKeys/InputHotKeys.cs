using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHotKeys : SingletonCtrl<InputHotKeys>
{
    protected bool isToogleInventoryUI = false;

    public bool IsToogleInventoryUI => isToogleInventoryUI;

    public virtual void Update() {
        this.OpenInventory();

    }

    public virtual void OpenInventory() {
        this.isToogleInventoryUI = Input.GetKeyUp(KeyCode.I);
    }
}
