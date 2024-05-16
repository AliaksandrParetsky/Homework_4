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

    void Update()
    {
        if(axes == RotationsAxes.MouseX)
        {
            transform.rotation = transform.rotation * Quaternion.Euler( 0f, Input.GetAxis("Mouse X") * sensivitiHor
                * Time.deltaTime, 0f);
        }
        else if(axes == RotationsAxes.MouseY)
        {
            verticalRot = verticalRot - Input.GetAxis("Mouse Y") * sensivitiVert * Time.deltaTime;
            verticalRot = Mathf.Clamp(verticalRot, minimumVert, maximumVert);

            float horizontalRot = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
        }
    }
}
