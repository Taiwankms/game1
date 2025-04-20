using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float movingSpeed = 2f;
    [SerializeField] private float startMovingTime = 3f;

    private float movingTime;
    private int forward = 1;

    private void Start()
    {
        forward = 1;
        movingTime = startMovingTime;
    }

    private void FixedUpdate()
    {
        if (movingTime <= -1f)
        {
            forward = -forward;
            movingTime = startMovingTime;
        }
        else
        {
            movingTime -= Time.deltaTime;
        }

        transform.Translate(Vector3.forward * movingSpeed * forward * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.transform.SetParent(transform); 
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.transform.SetParent(null);
        }
    }
}
