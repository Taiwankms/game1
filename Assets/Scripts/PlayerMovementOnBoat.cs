using UnityEngine;

public class PlayerBoatVelocityHandler : MonoBehaviour
{
    private Rigidbody rb;
    private BoatPlatform currentBoat;
    private bool isOnBoat;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Boat"))
        {
            BoatPlatform platform = collision.collider.GetComponent<BoatPlatform>();
            if (platform != null)
            {
                currentBoat = platform;
                isOnBoat = true;
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Boat"))
        {
            if (currentBoat != null && collision.collider.gameObject == currentBoat.gameObject)
            {
                currentBoat = null;
                isOnBoat = false;
            }
        }
    }

    void FixedUpdate()
    {
        if (isOnBoat && currentBoat != null)
        {
            // Add boat speed to velocity, only in the horizontal plane
            rb.linearVelocity += new Vector3(currentBoat.Velocity.x, 0f, currentBoat.Velocity.z);
        }
    }
}
