using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private Rigidbody body;

    public enum RotationsAxes
    {
        MouseX,
        MouseY
    }

    public RotationsAxes axes;

    [SerializeField] private float sensivitiHor;
    [SerializeField] private float sensivitiVert;

    private float minimumVert = -45.0f;
    private float maximumVert = 45.0f;

    private float verticalRot = 0;

    private float inputMouseX;
    private float inputMouseY;

    void Start()
    {
        if (GetComponent<Rigidbody>())
        {
            body = GetComponent<Rigidbody>();
        }
        
        if (body != null )
        {
            body.freezeRotation = true;
        }
    }

    private void OnEnable()
    {
        InputContrpller.MouseRotX += HandleMouseX;
        InputContrpller.MouseRotY += HandleMouseY;
    }

    private void OnDisable()
    {
        InputContrpller.MouseRotX -= HandleMouseX;
        InputContrpller.MouseRotY -= HandleMouseY;
    }

    void Update()
    {
        if(axes == RotationsAxes.MouseX)
        {
            transform.rotation = transform.rotation * Quaternion.Euler( 0f, inputMouseX * (sensivitiHor
                * Time.deltaTime), 0f);
        }
        else if(axes == RotationsAxes.MouseY)
        {
            verticalRot = verticalRot - inputMouseY * (sensivitiVert * Time.deltaTime);
            verticalRot = Mathf.Clamp(verticalRot, minimumVert, maximumVert);

            float horizontalRot = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
        }
    }

    private void HandleMouseX(float rotX)
    {
        inputMouseX = rotX;
    }

    private void HandleMouseY(float rotY)
    {
        inputMouseY = rotY;
    }
}
