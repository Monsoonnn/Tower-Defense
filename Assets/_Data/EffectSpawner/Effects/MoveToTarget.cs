using UnityEngine;

public class MoveToTarget : NewMonobehavior {
    public Transform target;
    [SerializeField] protected float speed = 10f;

    void Update() {
        this.IsFlying();
    }

    void IsFlying() {
        if(target == null) return;
        transform.parent.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public virtual void SetTarget(Transform target) {
        this.target = target;
        transform.parent.LookAt(target.position);
    } 
}
