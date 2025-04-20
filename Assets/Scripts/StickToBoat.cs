using UnityEngine;

public class StickToBoat : MonoBehaviour
{
    private Transform boat;
    private Vector3 offset;
    private bool isOnBoat = false;

    void Update()
    {
        if (isOnBoat && boat != null)
        {
            transform.position = boat.TransformPoint(offset);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boat"))
        {
            Debug.Log("BOT ON BOAT");
            transform.SetParent(other.transform); // make the bot a child object of the boat
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Boat"))
        {
            transform.SetParent(null); // disable parent

        }
    }
}
