using UnityEngine;

public class FlowZone : MonoBehaviour
{
    public Vector3 flowDirection = Vector3.forward; // Направление течения
    public float flowForce = 20f; // Сила течения

    private void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;
        if (rb != null)
        {
            rb.AddForce(flowDirection.normalized * flowForce, ForceMode.Force);
        }
    }
}
