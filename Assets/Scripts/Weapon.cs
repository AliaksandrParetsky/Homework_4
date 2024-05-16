using UnityEngine;

public class Weapon : MonoBehaviour
{
    private GameObject bulletPrefab;

    private float speed;

    public Vector3 Offset { get; set; }

    private void Start()
    {
        speed = 50f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(bulletPrefab != null)
            {
                Fire();
            }
            else
            {
                Debug.Log("Оружие не заряжено!");
                return;
            }
        }
    }

    public void LoadWeapon(GameObject bullet)
    {
        bulletPrefab = bullet;
    }

    private void Fire()
    {
        GameObject newbullet = Instantiate(bulletPrefab, transform.position + Offset, transform.rotation);
        newbullet.GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
}
