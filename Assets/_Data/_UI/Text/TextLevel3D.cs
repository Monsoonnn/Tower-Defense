using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TextLevel3D : Text3DAbstact
{

    protected virtual void FixedUpdate() {
        this.UpdateLevel();
    }

    protected virtual void UpdateLevel() {
      /*  this.textPro.text = this.towerCtrl.Level.CurrentLevel.ToString();*/
      this.textPro.text = this.GetLevel();
    }

    protected abstract string GetLevel();
}
