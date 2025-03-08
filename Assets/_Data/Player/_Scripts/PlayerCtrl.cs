using Invector.vCharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;


public class PlayerCtrl : NewMonobehavior
{
    [SerializeField] protected vThirdPersonController vThirdPersonController;
    [SerializeField] protected vThirdPersonCamera vThirdPersonCamera;
    [SerializeField] protected CrosshairPointer crosshairPointer;
    [SerializeField] protected Rig aimingRing;
    [SerializeField] protected WeaponsCtrl weaponsCtrl;
    public vThirdPersonController ThirdPersonController => vThirdPersonController;
    public vThirdPersonCamera ThirdPersonCamera => vThirdPersonCamera;
    public CrosshairPointer CrosshairPointer => crosshairPointer;
    
    public Rig AimingRing => aimingRing;

    public WeaponsCtrl WeaponsCtrl => weaponsCtrl;

    protected override void LoadComponents() {
        base.LoadComponents();
        this.LoadThirdPersonCtrl();
        this.LoadThirdPersonCamera();
        this.LoadCrosshairPointer();
        this.LoadRigging();
        this.LoadWeaponsCtrl();
    }

    void LoadThirdPersonCtrl() {
        if (this.vThirdPersonController != null) return;
        this.vThirdPersonController = GetComponentInChildren<vThirdPersonController>();
        Debug.Log(transform.name + ": Load vThirdPersonController", gameObject);
    }

    void LoadThirdPersonCamera() {
        if (this.vThirdPersonCamera != null) return;
        this.vThirdPersonCamera = GetComponentInChildren<vThirdPersonCamera>();
        Debug.Log(transform.name + ": Load vThirdPersonCamera", gameObject);
    }

    void LoadCrosshairPointer() {
        if (this.crosshairPointer != null) return;
        this.crosshairPointer = GetComponentInChildren<CrosshairPointer>();
        Debug.Log(transform.name + ": Load CrosshairPointer", gameObject);
    }

    void LoadRigging() { 
        if (this.aimingRing != null) return;
        this.aimingRing = transform.Find("Player").Find("Model").Find("AimRig").GetComponent<Rig>();
        Debug.Log(transform.name + ": Load Rigging", gameObject);
    }

    void LoadWeaponsCtrl() {
        if (this.weaponsCtrl != null) return;
        this.weaponsCtrl = GetComponentInChildren<WeaponsCtrl>();
        Debug.Log(transform.name + ": Load WeaponsCtrl", gameObject);
    }

}
