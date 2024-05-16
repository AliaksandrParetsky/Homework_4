using System;
using System.Collections;
using UnityEngine;

public class Fragments : Bullet
{
    private Rigidbody rb;

    private void Start()
    {
        if (GetComponent<Rigidbody>())
        {
            rb = GetComponent<Rigidbody>();
            rb.AddForce(GetRandomVector3(), ForceMode.Impulse);
        }
        
        time = 1f;

        StartCoroutine(DestroyHimself(time));
    }

    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
    }

    public override IEnumerator DestroyHimself(float time)
    {
        return base.DestroyHimself(time);
    }

    private Vector3 GetRandomVector3()
    {
        return new Vector3(UnityEngine.Random.Range(-20.0f, 20.0f), UnityEngine.Random.Range(-20.0f, 20.0f),
            UnityEngine.Random.Range(-20.0f, 20.0f));
    }
}
