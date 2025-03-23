using UnityEngine;

public class TrajectoryPredictor : MonoBehaviour {
    public LineRenderer lineRenderer;
    public int resolution = 30;
    public float height = 2f;
    public float speed = 10f;

    public void PredictTrajectory( Vector3 start, Vector3 target ) {
        if (lineRenderer == null) return;

        lineRenderer.positionCount = resolution;
        Vector3[] points = new Vector3[resolution];

        float distance = Vector3.Distance(start, target);
        float duration = distance / speed;

        for (int i = 0; i < resolution; i++) {
            float t = (float)i / (resolution - 1);
            Vector3 point = Vector3.Lerp(start, target, t);
            point.y += height * Mathf.Sin(t * Mathf.PI);
            points[i] = point;
        }

        lineRenderer.SetPositions(points);
    }
}
