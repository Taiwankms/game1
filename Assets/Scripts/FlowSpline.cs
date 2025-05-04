using UnityEngine;
using UnityEngine.Splines;
using Unity.Mathematics;

[RequireComponent(typeof(SplineContainer))]
public class FlowSpline : MonoBehaviour
{
    public float flowForce = 5f;

    private SplineContainer spline;

    private void Awake()
    {
        spline = GetComponent<SplineContainer>();
    }

    private void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;
        if (rb == null) return;

        float3 nearestPoint;
        float t;

        SplineUtility.GetNearestPoint(spline.Spline, other.transform.position, out nearestPoint, out t);

        Vector3 flowDirection = spline.Spline.EvaluateTangent(t);

        rb.AddForce(flowDirection.normalized * flowForce, ForceMode.Force);
    }
}
