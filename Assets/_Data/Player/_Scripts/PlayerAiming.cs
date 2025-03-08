using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : PlayerAbstract
{
    protected float closeLookDistance = 0.8f;
    protected float farLookDistance = 1.2f;
    [SerializeField] protected bool isAlwaysAiming = false;

    private void Update() {
        this.Aiming();
    }

    protected virtual void Aiming() { 
       if(this.isAlwaysAiming || InputManager.Instance.IsLookClose()) this.LookClose();
       else this.LookFar();
    }

    protected virtual void LookClose() { 
        this.playerCtrl.ThirdPersonCamera.defaultDistance = this.closeLookDistance;
        CrosshairPointer crosshairPointer = this.playerCtrl.CrosshairPointer;

        this.playerCtrl.ThirdPersonController.RotateToPosition(crosshairPointer.transform.position);
        this.playerCtrl.ThirdPersonController.isSprinting = false;
        this.playerCtrl.AimingRing.weight = 1f;
    }


    protected virtual void LookFar() { 
        this.playerCtrl.ThirdPersonCamera.defaultDistance = this.farLookDistance;
        this.playerCtrl.AimingRing.weight = 0f;
    }
}
