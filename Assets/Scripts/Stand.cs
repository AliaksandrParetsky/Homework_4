using UnityEngine;

public class Stand : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;

    private void OnTriggerEnter(Collider other)
    {
        SetBullet(other, true);
    }

    private void OnTriggerExit(Collider other)
    {
        SetBullet(other, false);
    }

    private void SetBullet(Collider collider , bool enter)
    {
        if (collider.TryGetComponent<CharacterMovement>(out var characterMovement))
        {
            GameObject player = characterMovement.gameObject;

            var cam = player.GetComponentInChildren<Weapon>();

            if (cam.TryGetComponent<Weapon>(out var weapon))
            {
                if (enter)
                {
                    weapon.LoadWeapon(bulletPrefab);
                }
                else
                {
                    weapon.LoadWeapon(null);
                }
            }
        }
    }
}
