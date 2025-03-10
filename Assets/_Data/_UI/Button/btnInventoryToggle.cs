using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnInventoryToggle : ButtonAbstact
{
    
    protected override void OnClick() {
        InventoryUI.Instance.ToggleUI(); 
    }
}
