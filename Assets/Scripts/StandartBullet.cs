using System.Collections;
using UnityEngine;

public class StandartBullet : Bullet
{
    private void Start()
    {
        time = 2f;
        StartCoroutine(DestroyHimself(time));
    }

    public override IEnumerator DestroyHimself(float time)
    {
        return base.DestroyHimself(time);
    }

    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
    }
}
