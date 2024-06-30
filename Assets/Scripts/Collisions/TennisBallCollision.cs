using UnityEngine;

public class TennisBallCollision : MonoBehaviour
{
    private ParticleSystem particle;

    private Transform particleChild;

    private void Awake()
    {
        particle = GetComponentInChildren<ParticleSystem>();
        particle.Stop();

        particleChild = transform.GetChild(0).GetComponent<Transform>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<TennisBall>(out var tennisBall))
        {
            var contactPoint = collision.contacts[0];

            particleChild.transform.position = contactPoint.point;

            particle.Play();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        particle.Stop();
    }
}
