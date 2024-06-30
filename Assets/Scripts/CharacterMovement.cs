using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    private CharacterController charController;

    [SerializeField] private float speed;

    private float gravity = -9.8f;

    private Vector2 moveDirection;

    void Start()
    {
        if(GetComponent<CharacterController>())
        {
            charController = GetComponent<CharacterController>();
        }
    }

    private void OnEnable()
    {
        InputContrpller.MoveEvent += HandleMove;
    }

    private void OnDisable()
    {
        InputContrpller.MoveEvent -= HandleMove;
    }

    void Update()
    {
        float deltaX = moveDirection.x;
        float deltaZ = moveDirection.y;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);

        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;

        movement = transform.TransformDirection(movement);
        charController.Move(movement * (speed * Time.deltaTime));
    }

    private void HandleMove(Vector2 dir)
    {
        moveDirection = dir;
    }
}
