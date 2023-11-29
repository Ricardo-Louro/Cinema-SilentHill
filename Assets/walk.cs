using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class walk : MonoBehaviour
{
    [SerializeField] private float rotationAmount;
    [SerializeField] private float moveSpeed;
    private Rigidbody rb;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("w") ^ Input.GetKey("s"))
        {
            if(Input.GetKey("w"))
            {
                animator.SetBool("walk_forward", true);
                animator.SetBool("walk_backwards", false);
                rb.velocity = transform.forward * (moveSpeed * Time.deltaTime);
            }
            else
            {
                animator.SetBool("walk_forward", false);
                animator.SetBool("walk_backwards", true);
                rb.velocity = transform.forward * (-moveSpeed * Time.deltaTime);
            }
        }
        else
        {
            animator.SetBool("walk_forward", false);
            animator.SetBool("walk_backwards", false);
            rb.velocity = new Vector3(0,0,0);
        }

        if(Input.GetKey("a") ^ Input.GetKey("d"))
        {
            Vector3 currentRotation = transform.eulerAngles;

            if(Input.GetKey("a"))
            {
                transform.eulerAngles = new Vector3(currentRotation[0],
                                                    currentRotation[1] - (rotationAmount * Time.deltaTime),
                                                    currentRotation[2]);
            }
            else
            {
                transform.eulerAngles = new Vector3(currentRotation[0],
                                                    currentRotation[1] + (rotationAmount * Time.deltaTime),
                                                    currentRotation[2]);
            }
        }
        
    }
}
