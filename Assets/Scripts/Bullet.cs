using System.Collections;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [HideInInspector] public float time;

    private void Start()
    {
        time = 0.1f;
        StartCoroutine(DestroyHimself(time));
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<Obj>(out var obj))
        {
            obj.OnHit();

            Debug.Log("OnCollisionEnter");
        }
    }

    public virtual IEnumerator DestroyHimself(float time)
    {
        yield return new WaitForSeconds(time);

        Destroy(gameObject);
    }
}


