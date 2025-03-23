using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SliderHp : SliderAbstact
{
    protected void FixedUpdate() {
        this.UpdateSider();
    }

    protected virtual void UpdateSider() {
        this.slider.value = this.GetValue();
    }

    protected abstract float GetValue();
}
