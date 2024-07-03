
using UnityEngine;

public class StandartBullet : Bullet
{
    private ParticleSystem particle;

    private GameObject tinyExpl;

    private void OnEnable()
    {
        particle = transform.GetChild(2).GetComponent<ParticleSystem>();

        tinyExpl = particle.gameObject;

        tinyExpl.SetActive(false);

        particle.Stop();
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Target>(out var obj))
        {
            obj.OnHit();

            tinyExpl?.SetActive(true);
            particle?.Play();

            DestroyHimSelf(2.0f);
        }
    }
}
