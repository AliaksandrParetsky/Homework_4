using UnityEngine;

public class Fragments : StandartBullet
{
    private Rigidbody rb;

    private float timeDestroyFragments = 1.0f;

    private void Start()
    {
        if (GetComponent<Rigidbody>())
        {
            rb = GetComponent<Rigidbody>();
            rb.AddForce(GetRandomVector3(), ForceMode.Impulse);
        }

        DestroyHimSelf(timeDestroyFragments);
    }

    private Vector3 GetRandomVector3()
    {
        return new Vector3(Random.Range(-20.0f, 20.0f), Random.Range(-20.0f, 20.0f), Random.Range(-20.0f, 20.0f));
    }
}
