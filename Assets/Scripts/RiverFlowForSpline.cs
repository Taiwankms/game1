using UnityEngine;

public class RiverFlowForSpline : MonoBehaviour
{
    public Vector3 flowDirection = Vector3.forward; // Current direction
    public float forceStrength = 5f;                // Current strength
    public float maxSpeed = 5f;                     // Max. speed to which we accelerate

    private void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;
        if (rb != null)
        {
            Vector3 worldFlow = transform.TransformDirection(flowDirection.normalized);
            float speedInFlowDir = Vector3.Dot(rb.linearVelocity, worldFlow);

            if (speedInFlowDir < maxSpeed)
            {
                rb.AddForce(worldFlow * forceStrength, ForceMode.Acceleration);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(transform.position, transform.TransformDirection(flowDirection.normalized) * 2f);
    }
}
