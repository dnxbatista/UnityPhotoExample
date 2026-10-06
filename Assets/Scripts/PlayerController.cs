using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    #region Variables
    // -- Movement
    private readonly float _movementSpeed = 5f;
    private Vector3 _customVelocity = Vector3.zero;

    // -- Camera
    [HideInInspector] public float CameraSensitivity = 1f; // Default should be 1
    private Vector2 lookInputWithSens = new();

    // -- Input
    private InputAction _moveAction;
    private InputAction _lookAction;

    // -- External References
    [Header("Ext Refs")]
    [SerializeField] private Transform _cameraHolderTransform;
    private CharacterController _characterController;
    #endregion

    #region Engine Functions
    private void Start()
    {
        SetupPlayer();
    }

    private void Update()
    {
        PlayerApplyGravity();
        PlayerLook();
        PlayerMove();
    }
    #endregion

    #region Custom Functions
    private void SetupPlayer()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _characterController = GetComponent<CharacterController>();

        _lookAction = InputSystem.actions.FindAction("Look");
        _moveAction = InputSystem.actions.FindAction("Move");

        if (_lookAction == null || _moveAction == null)
        {
            Debug.LogError("Failed to find action");
        }
    }

    private void PlayerMove()
    {
        Vector2 moveInput = _moveAction.ReadValue<Vector2>();

        Vector3 dirInput = new();
        dirInput += transform.forward * moveInput.y;
        dirInput += transform.right * moveInput.x;
        
        _characterController.Move((dirInput * _movementSpeed + _customVelocity) * Time.deltaTime);
    }

    private void PlayerLook()
    {
        var lookInput = _lookAction.ReadValue<Vector2>() * CameraSensitivity;
        lookInputWithSens += lookInput;

        lookInputWithSens.y = Mathf.Clamp(lookInputWithSens.y, -80f, 80f);

        _cameraHolderTransform.localRotation = Quaternion.Euler(-lookInputWithSens.y, 0f, 0f);
        transform.localRotation = Quaternion.Euler(0f, lookInputWithSens.x, 0f);
    }

    private void PlayerApplyGravity()
    {
        var customGravity = Physics.gravity * Time.deltaTime;
        _customVelocity.y = _characterController.isGrounded ? -1f : _customVelocity.y + customGravity.y;
    }
    #endregion
}
