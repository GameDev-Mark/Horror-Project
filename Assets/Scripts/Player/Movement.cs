using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;
    public float xRange = 1f;
    public float yRange = 1f;

    private float vertical;
    private float horizontal;
    private float xAxis;
    private float yAxis;
    private float gravity = 9.81f; // gravity (player settings)

    //
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        FollowMouseCamera();
    }

    //
    private void PlayerMovement()
    {
        // calculate movement and speeds
        vertical = Input.GetAxis("Vertical");
        vertical *= moveSpeed * Time.deltaTime;

        horizontal = Input.GetAxis("Horizontal");
        horizontal *= moveSpeed * Time.deltaTime;

        // apply to new local space vector
        Vector3 move = new(horizontal, 0f, vertical);

        // normalize vector for consistent speeds
        if (move.magnitude > 1f)
        {
            move = move.normalized;
        }

        // covert local to global movement
        move = transform.TransformDirection(move);

        // apply simple gravity
        move.y -= gravity * Time.deltaTime;

        // move with controller
        GetComponent<CharacterController>().Move(move);
    }

    //
    private void FollowMouseCamera()
    {
        xAxis = Input.GetAxis("Mouse X") * rotationSpeed;
        yAxis = Input.GetAxis("Mouse Y") * rotationSpeed;

        Vector3 angles = transform.rotation.eulerAngles;
        angles.x = (angles.x > 180) ? angles.x - 360 : angles.x;

        if ((angles.x > 90 && angles.x < 270) || (angles.x < -90 && angles.x > -270))
        {
            yAxis = -yAxis;
        }

        //if (angles.x > 50f)
        //{
        //    angles.x = 50f;
        //}
        //else if (angles.x < -50f)
        //{
        //    angles.x = -50f;
        //}

        angles.z = 0f;

        transform.rotation = Quaternion.Euler(angles);
        transform.Rotate(-yAxis, xAxis, 0f, Space.Self);
    }
}