using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : NewMonobehavior
{
    [SerializeField] protected Transform playerCamera;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCamera();
    }

    protected virtual  void LoadCamera() {
        if (this.playerCamera != null) return;
        this.playerCamera = GameObject.Find("PlayerCamera").transform;
        Debug.Log(transform.name + ": LoadCamera", gameObject);
    }

    private void Update() {
        transform.LookAt(this.playerCamera);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y+ 180, 0);
    }
}
