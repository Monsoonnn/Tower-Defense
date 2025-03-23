using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class GrenadesDamageSender : EffectDamageSender {

    protected override string GetHitName() {
       return "HitGrenades";
    }

    
}
