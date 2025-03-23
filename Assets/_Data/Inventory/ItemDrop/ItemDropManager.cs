using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropManager : SingletonCtrl<ItemDropManager>
{
    [SerializeField] protected ItemDropSpawner spawner;
    public ItemDropSpawner Spawner => spawner;

    public float spawnHeight = 1.0f;
    public float forceAmount = 5.0f;
  

    protected override void LoadComponents() {
        base.LoadComponents();
        this.LoadSpawner();
    }

    protected virtual void LoadSpawner() {
        if (this.spawner != null) return;
        this.spawner = GetComponent<ItemDropSpawner>();
        Debug.Log(transform.name + ": LoadSpawner", gameObject);
    }

    public virtual void Drop(ItemCode itemCode, int dropCount, InvCodeName invCodeName, Vector3 dropPosition) {
        
        Vector3 spawnPosition = dropPosition + new Vector3(Random.Range (-2.0f, 2.0f), spawnHeight, Random.Range(-2.0f, 2.0f));
        
        ItemDropCtrl itemPrefab = this.spawner.PoolPrefabs.GetByName(itemCode.ToString());
        if(itemPrefab == null ) itemPrefab = this.spawner.PoolPrefabs.GetByName("Default");

        ItemDropCtrl newItem = this.spawner.Spawn(itemPrefab, spawnPosition);

        newItem.SetValue(itemCode, dropCount, invCodeName);

        newItem.gameObject.SetActive(true);

        Vector3 randomDirection = Random.onUnitSphere;
        randomDirection.y = Mathf.Abs(randomDirection.y);
        newItem.Rb.AddForce(randomDirection * forceAmount, ForceMode.Impulse);
    }
}
