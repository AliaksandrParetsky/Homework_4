using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    private CharacterController charController;

    [SerializeField] private float speed = 5.0f;

    private float gravity = -9.8f;

    void Start()
    {
        if(GetComponent<CharacterController>())
        {
            charController = GetComponent<CharacterController>();
        }
    }

    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);

        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;

        movement = movement * Time.deltaTime;

        movement = transform.TransformDirection(movement);
        charController.Move(movement);
    }
}
