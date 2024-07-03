using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : Bullet
{
    [SerializeField] private List<Fragments> fragmentsBullets = new List<Fragments>();

    private ParticleSystem particle;

    private GameObject bigExpl;

    private float timeDestroyCollision = 0.01f;
    private float timeDestroyGrenade = 3.0f;
    private float animDelayExplosion = 1.5f;

    private bool firstCollision = true;

    private void Start()
    {
        StartCoroutine(TimeExplosion(timeDestroyGrenade, animDelayExplosion));
    }

    private void OnEnable()
    {
        particle = transform.GetChild(2).GetComponent<ParticleSystem>();

        bigExpl = particle.gameObject;

        bigExpl.SetActive(false);

        particle.Stop();
    }

    private IEnumerator TimeExplosion(float firstdelay, float secondDelay)
    {
        yield return new WaitForSeconds(firstdelay);

        bigExpl?.SetActive(true);
        particle?.Play();

        Explosion();

        yield return new WaitForSeconds(secondDelay);

        DestroyHimSelf(timeDestroyCollision);
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Target>(out var obj))
        {
            if (!firstCollision)
            {
                return;
            }

            StartCoroutine(TimeExplosion(timeDestroyCollision, animDelayExplosion));

            firstCollision = false;
        }
    }

    private void Explosion()
    {
        for (int i = 0; i < fragmentsBullets.Count; i++)
        {
            fragmentsBullets[i] = Instantiate(fragmentsBullets?[i], transform.position, transform.rotation);
        }
    }
}
