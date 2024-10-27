using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;  // Singleton instance
    public InputActionAsset controls;     // InputActionAsset variable (assign in Editor)
    public InputAction moveAction;        // Move action reference
    public InputAction fireAction;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Find and assign the Move action
        moveAction = controls.FindAction("Move");
        fireAction = controls.FindAction("Fire");

        moveAction.Enable();
        fireAction.Enable();
    }
}
