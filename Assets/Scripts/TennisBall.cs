using System.Collections;
using UnityEngine;

public class TennisBall : StandartBullet
{
    private PhysicMaterial physicMaterial;

    private void Start()
    {
        physicMaterial = GetComponent<SphereCollider>().material;

        if (physicMaterial != null)
        {
            physicMaterial.bounciness = 1;
        }
        else
        {
            Debug.LogError("PhysicMaterial TennisBall is Null!");
        }

        time = 6f;

        StartCoroutine(DestroyHimself(time));
    }

    public override IEnumerator DestroyHimself(float time)
    {
        return base.DestroyHimself(time);
    }
}
