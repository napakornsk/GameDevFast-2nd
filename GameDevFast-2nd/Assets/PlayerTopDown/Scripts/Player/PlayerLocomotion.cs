using UnityEngine;

namespace PlayerScripts
{
    public class PlayerLocomotion : MonoBehaviour
    {
        PlayerInput playerInput;
        Rigidbody playerRigidbody;
        Vector3 moveDirection;
        Transform cameraObject;
        Quaternion playerRotation;

        [SerializeField] float moveSpeed = 10f;
        [SerializeField] float rotationSpeed = 15f;
        [SerializeField] bool isSmoothRotate;

        void Awake()
        {
            playerRigidbody = GetComponent<Rigidbody>();
            cameraObject = Camera.main.transform;
            playerInput = GetComponent<PlayerInput>();
        }
        public void HandleAllLocomotion()
        {
            HandleMovement();
            HandleRotation();
        }
        void HandleMovement()
        {
            moveDirection = cameraObject.right * playerInput.HorizontalInput;
            moveDirection = moveDirection + (cameraObject.forward * playerInput.VerticalInput);
            moveDirection.Normalize();
            moveDirection.y = 0;
            moveDirection = moveDirection * moveSpeed;

            playerRigidbody.velocity = moveDirection;
        }
        void HandleRotation()
        {
            Vector3 targetDirection = Vector3.zero;

            targetDirection = cameraObject.forward * playerInput.VerticalInput;
            targetDirection = targetDirection + (cameraObject.right * playerInput.HorizontalInput);
            targetDirection.Normalize();
            targetDirection.y = 0;

            // Make character stop turn around and freeze direction that player looking.
            if (targetDirection == Vector3.zero)
            {
                targetDirection = transform.forward;
            }

            // To make player turn into specified direction which is (z, x) depends on input.
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            // Rotate with speed by defining : (startPoint, endPoint, speed)
            if (isSmoothRotate)
            {
                playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            }
            else
            {
                playerRotation = targetRotation;
                transform.rotation = playerRotation;
            }

            transform.rotation = playerRotation;
        }
    }
}

