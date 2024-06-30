using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Target : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        if (GetComponent<Rigidbody>())
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    public void OnHit()
    {
        rb.AddForce(GetRandomVector3(), ForceMode.Force);
        rb.AddTorque(360f, 45f, 30f);
    }

    private Vector3 GetRandomVector3()
    {
        return new Vector3(Random.Range(-50.0f, 50.0f), Random.Range(-50.0f, 50.0f), Random.Range(-50.0f, 50.0f));
    }
}
