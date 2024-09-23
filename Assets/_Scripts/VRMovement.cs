using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRMovement : MonoBehaviour

{
    public float speed = 1.0f;

    public float gravity = 9.8f;

    public float jumpSpeed = 0.0f;  // Speed at which the character will jump

    private CharacterController characterController;

    public Transform cameraTransform;

    private Vector3 moveDirection = Vector3.zero;  // Movement direction of the character

    void Start()

    {
        characterController = GetComponent<CharacterController>();

        cameraTransform = Camera.main.transform;
    }

    void LateUpdate()

    {
        // Check if the character is grounded

        if (characterController.isGrounded)

        {
            // Get input from the Oculus controller thumbstick

            float h = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x;

            float v = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y;

            // Calculate direction based on camera orientation

            Vector3 forward = cameraTransform.TransformDirection(Vector3.forward);

            Vector3 right = cameraTransform.TransformDirection(Vector3.right);

            forward.y = 0;

            right.y = 0;

            forward.Normalize();

            right.Normalize();

            // Calculate movement direction

            moveDirection = (forward * v + right * h) * speed;

            // Check for jump input (using Oculus "A" button for jumping)

            if (OVRInput.GetDown(OVRInput.Button.One))

            {
                moveDirection.y =
                    jumpSpeed;  // Apply jump speed to moveDirection's y component
            }
        }

        // Apply gravity

        moveDirection.y -= gravity * Time.deltaTime;

        // Move the character controller

        characterController.Move(moveDirection * Time.deltaTime);
    }
}
