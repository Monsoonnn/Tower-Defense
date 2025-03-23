using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderAbstact : NewMonobehavior
{
    [SerializeField] protected Slider slider;

    protected override void LoadComponents() {
        base.LoadComponents();
        this.LoadSider();
    }

    protected virtual void LoadSider() {
        if(this.slider != null) return;
        this.slider = GetComponent<Slider>();
        Debug.Log(transform.name + ": LoadSider()");
    }
}
