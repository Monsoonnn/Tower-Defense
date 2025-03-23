using UnityEngine;

public class MoveToTargetParabol : MoveToTarget {
    private float height = 2f;
    private float timeElapsed = 0f;
    private float duration = 1f;
    private Vector3 startPosition;

    public override void SetTarget( Transform target ) {
        base.SetTarget(target);
        startPosition = transform.position;
        float distance = Vector3.Distance(startPosition, target.position);
        duration = distance / speed;
        timeElapsed = 0f;
    }

    protected override void IsFlying() {
        if (target == null) return;

        timeElapsed += Time.deltaTime;
        float t = Mathf.Clamp01(timeElapsed / duration);


        Vector3 nextPosition = Vector3.Lerp(startPosition, target.position, t);


        nextPosition.y += height * Mathf.Sin(t * Mathf.PI);

        transform.parent.position = nextPosition;

    }
}