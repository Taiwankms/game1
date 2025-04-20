using UnityEngine;

public class FloatPoint : MonoBehaviour
{
    public float waterLevel = 0f;
    public float floatForce = 100f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (rb == null) return;

        float depth = waterLevel - transform.position.y;
        if (depth > 0f)
        {
            Vector3 force = Vector3.up * floatForce * depth;
            rb.AddForceAtPosition(force, transform.position);
        }
    }
}
