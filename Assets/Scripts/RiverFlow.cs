using UnityEngine;

public class RiverFlow : MonoBehaviour
{
    public Vector3 flowDirection = new Vector3(1, 0, 1); // direction of rotation
    public float flowStrength = 5f;                      // current strength
    public float maxSpeed = 5f;                          // maximum boat speed

    private void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;
        if (rb != null)
        {
            Vector3 flatVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
            float speed = flatVelocity.magnitude;

            // If the speed is less than the maximum, add force
            if (speed < maxSpeed)
            {
                rb.AddForce(flowDirection.normalized * flowStrength, ForceMode.Force);
            }
        }
    }
}
