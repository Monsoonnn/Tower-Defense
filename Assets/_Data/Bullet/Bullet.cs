using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : SpawnableObj {
    [SerializeField] protected float speed = 10f;

    private void Update() {
        transform.Translate(Vector3.forward * speed * Time.deltaTime); 
    }


    public override string GetName() {
        return "Bullet";
    }
}
