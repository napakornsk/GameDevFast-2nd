using UnityEngine;

public class InputManager : MonoBehaviour
{
    protected float xInput, yInput;
    public virtual void HandleInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
    }
}
