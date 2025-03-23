using System.Collections;
using System.Collections.Generic;
using UnityEngine;  
public class DamageReceiver : NewMonobehavior {


    public int maxHP = 10;
    public int currentHP = 10;
    protected bool isDead = false;


    [SerializeField] public bool isImomortal = false;

    public virtual int Deduct( int hp ) {
        if(!this.isImomortal) this.currentHP -= hp;

        if (this.IsDead()) this.onDead();
        else  this.onHit();


        if (this.currentHP < 0) this.currentHP = 0;
        return this.currentHP;

    }

    protected virtual void OnEnable() {
        this.OnReborn();
    }

    
    public virtual bool IsDead() { 
        return this.isDead = this.currentHP <= 0;
    } 

    protected virtual void onDead() { 
        //For override
    }
    protected virtual void onHit() {
        //For override
    }

    protected virtual void OnReborn() {
        this.currentHP = this.maxHP;
        this.isDead = false;
    }
}
