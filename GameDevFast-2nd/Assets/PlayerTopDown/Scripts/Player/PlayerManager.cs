using UnityEngine;

namespace PlayerScripts
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] PlayerInput playerInput;
        [SerializeField] PlayerLocomotion playerLocomotion;
        void Awake()
        {
            playerInput = GetComponent<PlayerInput>();
            playerLocomotion = GetComponent<PlayerLocomotion>();
        }

        void Update()
        {
            playerInput.HandleInput();
        }
        void FixedUpdate()
        {
            playerLocomotion.HandleAllLocomotion();
        }
    }
}

