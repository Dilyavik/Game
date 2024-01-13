using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{

    public Transform cameraPivot;
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;

    
    void Update()
    {
        HandleMovement();
        HandleRotation();
    }


    void HandleMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 inputDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        Vector3 moveDirection = cameraPivot.forward * inputDirection.z + cameraPivot.right * inputDirection.x;
        moveDirection.y = 0f;

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }

    void HandleRotation()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 cursorDirection = hit.point - transform.position;
            cursorDirection.y = 0f;



            Quaternion targetRotation = Quaternion.LookRotation(cursorDirection);

            float step = rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, step);
        }
    }

}
