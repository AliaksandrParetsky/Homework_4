using UnityEngine;

public class TennisBall : Bullet
{
    private PhysicMaterial physicMaterial;

    private float timeDestroyTennisBall = 5.0f;

    private ParticleSystem particle;

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

        DestroyHimSelf(timeDestroyTennisBall);
    }
}
