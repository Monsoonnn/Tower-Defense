using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : AttackAbstract
{
    protected string effectName = "Grenades";
    protected bool isAvailable = true;
    protected float cooldownTime = 3f;
    protected float cooldownTimer = 0f;



    protected override void Attacking() {
        if (!InputManager.Instance.IsThrowGrenade()) return;

        if(!this.isAvailable) return;

        AttackPoint attackPoint = this.GetAttackPoint();

        EffectCtrl effect = this.effectSpawner.Spawn(this.GetEffect(), attackPoint.transform.position);

        effect.gameObject.SetActive(true);

        this.isAvailable = false;
        this.cooldownTimer = cooldownTime;


        Debug.Log("Throw");
    }


    protected virtual EffectCtrl GetEffect() {
        return this.effectPrefabs.GetByName(this.effectName);
    }

    protected override void Cooldown() {
        if(this.isAvailable) return;

        cooldownTimer -= Time.deltaTime; 

        if (cooldownTimer <= 0f) {
            isAvailable = true;
            cooldownTimer = 0f; 
        }
    }
}
