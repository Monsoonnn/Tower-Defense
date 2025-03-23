using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleEffect : NewMonobehavior
{
    [SerializeField] protected MuzzleCode muzzle;
    [SerializeField] protected EffectSpawner spawner;

    protected virtual void OnEnable() {
        this.SpawnMuzzle();
    }

    protected virtual void SpawnMuzzle() {
        if (this.muzzle == MuzzleCode.NoEffect) return;
        EffectSpawner effectSpawner = EffectSpawnerCtrl.Instance.Spawner;
        EffectCtrl prefab = effectSpawner.PoolPrefabs.GetByName(this.muzzle.ToString());
        EffectCtrl newEffect = effectSpawner.Spawn(prefab, transform.position);
        newEffect.gameObject.SetActive(true);
    }
}

