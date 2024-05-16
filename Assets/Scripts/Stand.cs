using UnityEngine;

public class Stand : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] Vector3 offset;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Weapon>(out var weapon))
        {
            if (weapon != null)
            {
                weapon.Offset = offset;
                weapon.LoadWeapon(bulletPrefab);
            }
            else
            {
                Debug.Log("Weapon is Null!");
            }
            
            Debug.Log(bulletPrefab.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Weapon>(out var weapon))
        {
            if (weapon != null)
            {
                weapon.LoadWeapon(null);

                Debug.Log("Weapon is Null!");
            }
        }
    }
}
