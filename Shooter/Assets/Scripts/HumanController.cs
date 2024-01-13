using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    public Camera mainCamera;
    public float zoomedFOV = 40f;
    public float defaultFOV = 60f;
    public float rotationSpeed = 5f;



    //public float rotationSpeed = 1f;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }



    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        bool isWalk = Mathf.Abs(verticalInput) > 0.1f;
        animator.SetBool("isWalk", isWalk);

        //RotateCharacterTowardsCursor();


        FastRun();

        Fire();

        if (Input.GetMouseButton(1))
        {
            ZoomIn();
        }
        else
        {
            ZoomOut();
        }
    }

    void FastRun()
    {
        bool isRuning;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRuning = true;
        }
        else
        {
            isRuning = false;
        }

        if (isRuning)
        {
            animator.SetBool("isRuning", true);
        }
        else
        {
            animator.SetBool("isRuning", false);
        }
    }

    void Fire()
    {
        bool isFire;

        if (Input.GetKey(KeyCode.Mouse0))
            isFire = true;
        else
            isFire = false;

        if (isFire)
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 targetDirection = hit.point - transform.position;
                targetDirection.y = 0f;

                Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
            animator.SetBool("isFire", true);
        }
        else
        {
            animator.SetBool("isFire", false);
        }
    }



    void ZoomIn()
    {
        mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, zoomedFOV, Time.deltaTime * 5f);
    }

    void ZoomOut()
    {
        mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, defaultFOV, Time.deltaTime * 5f);
    }



    
}
