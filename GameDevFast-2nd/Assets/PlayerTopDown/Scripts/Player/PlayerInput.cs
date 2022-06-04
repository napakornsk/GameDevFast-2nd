using UnityEngine;

namespace PlayerScripts
{
    public class PlayerInput : InputManager
    {
        public override void HandleInput()
        {
            base.HandleInput();
        }

        #region "Constructor"
        public float HorizontalInput
        {
            get
            {
                return xInput;
            }
        }
        public float VerticalInput
        {
            get
            {
                return yInput;
            }
        }
        #endregion
    }
}

