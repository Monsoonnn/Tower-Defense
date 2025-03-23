using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLevelPlayer : TextAbstact
{
    protected virtual void FixedUpdate() {
        this.LoadLevelCount();
    }



    protected virtual void LoadLevelCount() {

        this.textPro.text = PlayerCtrl.Instance.Level.CurrentLevel.ToString();
    }

}
