
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : SingletonCtrl<InputManager>
{

    protected bool isLookClose = false;

    protected float attackHold = 0;
    protected float attackHoldLimit = 3f;
    protected bool isRollingGrenade = false;
    protected bool isThrowGrenade = false;

    private void Update() {
        this.CheckLookClose();
        this.CheckGrenadeHold();
    }

    protected virtual void CheckLookClose() { 
        this.isLookClose = Input.GetMouseButton(1);
    }

    protected virtual void CheckGrenadeHold() {

       if (!this.isLookClose) return;

       if(Input.GetMouseButton(0)) this.attackHold += Time.deltaTime;
        if (Input.GetMouseButtonUp(0)) {
            this.isRollingGrenade = this.attackHold < this.attackHoldLimit;
            this.attackHold = 0;
        } else { 
            this.isRollingGrenade = false;
        }
        if(this.attackHold > this.attackHoldLimit) this.isThrowGrenade = true;
        else this.isThrowGrenade = false;


    }

    public virtual bool IsLookClose() { 
        return this.isLookClose;
    }

    public virtual bool IsThrowGrenade() {
        return this.isThrowGrenade;
    }

    public virtual bool IsRollingGrenade() {
        return this.isRollingGrenade;
    }
}
