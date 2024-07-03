using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Bullet bulletPrefab;

    private float speed;

    void Start()
    {
        speed = 60.0f;
    }

    private void OnEnable()
    {
        InputContrpller.ShotEvent += Shot;
    }

    private void OnDisable()
    {
        InputContrpller.ShotEvent -= Shot;
    }

    private void Shot()
    {
        if (bulletPrefab != null)
        {
            Fire();
        }
        else
        {
            Debug.Log("Prefab is Null!");
            return;
        }
    }

    public void LoadWeapon(Bullet bullet)
    {
        bulletPrefab = bullet;
    }

    private void Fire()
    {
        Bullet newbullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        newbullet.GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
}
