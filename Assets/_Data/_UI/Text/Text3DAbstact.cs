using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Text3DAbstact : NewMonobehavior
{
    [SerializeField]  protected TextMeshPro textPro;

    protected override void LoadComponents() {
        base.LoadComponents();
        this.LoadTextMeshPro();
    }

    protected virtual void LoadTextMeshPro() {
        if (this.textPro != null) return;
        this.textPro = GetComponent<TextMeshPro>();
        Debug.Log(transform.name + ": LoadTextMeshPro", gameObject);
    }
}
