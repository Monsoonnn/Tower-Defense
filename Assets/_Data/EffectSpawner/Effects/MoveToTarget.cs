using UnityEngine;

public class MoveToTarget : NewMonobehavior {
    public Transform target;
    [SerializeField] protected float speed = 10f;

    void Update() {
        this.IsFlying();
    }

    protected virtual void IsFlying() {
        if(target == null) return;
        transform.parent.Translate(speed * Time.deltaTime * Vector3.forward);
    }   

    public virtual void SetTarget(Transform target) {
        this.target = target;
        transform.parent.LookAt(target.position);
    } 
}
