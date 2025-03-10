using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextAbstact : NewMonobehavior
{
    [SerializeField] protected TextMeshProUGUI textPro;

    protected override void LoadComponents() {
        base.LoadComponents();
        this.LoadTextMeshPro();
    }

    protected virtual void LoadTextMeshPro() {
        if (this.textPro != null) return;
        this.textPro = GetComponent<TextMeshProUGUI>();
        Debug.Log(transform.name + ": LoadTextMeshPro", gameObject);
    }
}
