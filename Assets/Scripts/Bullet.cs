using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    private float timeDestroy = 2.0f;

    private void Start()
    {
        DestroyHimSelf(timeDestroy);
    }

    private void Awake()
    {
        SetColorTrail();
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<Target>(out var obj))
        {
            Debug.Log("Base OnCollisionEnter");
        }
    }

    protected void DestroyHimSelf(float timeDestroy)
    {
        Destroy(gameObject, timeDestroy);
    }

    protected void SetColorTrail()
    {
        gameObject.GetComponentInChildren<TrailRenderer>().material.color = gameObject.GetComponent<Renderer>().material.color;
    }

}


