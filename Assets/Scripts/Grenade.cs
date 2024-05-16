using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : Bullet
{
     [SerializeField] private List<Fragments> standartBullets = new List<Fragments>();

    private void Start()
    {
        time = 3f;
        StartCoroutine(DestroyHimself(time));   
    }
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Obj>(out var obj))
        {
            obj.OnHit();

            Debug.Log("OnCollisionEnter");

            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Obj is Null!");
            return;
        }
    }

    public override IEnumerator DestroyHimself(float time)
    {
        return base.DestroyHimself(time);
    }

    private void OnDisable()
    {
        Explosion();
    }

    private void Explosion()
    {
        for(int i = 0; i < standartBullets.Count; i++)
        {
            standartBullets[i] = Instantiate(standartBullets[i], transform.position, transform.rotation);
        }
    }
}
