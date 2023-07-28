using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RigidBodyContinuousMovement : MonoBehaviour
{
    public float speed = 1;
    public InputActionProperty moveInputSource;
    public  Rigidbody rb;

    public Transform directionSource; //Which way is forward?

    private Vector2 inputMoveAxis;
    // Start is called before the first frame update
    void Update()
    {
        inputMoveAxis = moveInputSource.action.ReadValue<Vector2>();   
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        Quaternion yaw = Quaternion.Euler(0, directionSource.eulerAngles.y, 0);
        Vector3 direction = yaw * new Vector3(inputMoveAxis.x, 0, inputMoveAxis.y);

        rb.MovePosition(rb.position + direction * Time.fixedDeltaTime * speed);
    }
}
