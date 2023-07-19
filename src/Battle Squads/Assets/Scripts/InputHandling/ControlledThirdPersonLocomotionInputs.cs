using UnityEngine;
using UnityEngine.InputSystem;

public class ControlledThirdPersonLocomotionInputs : MonoBehaviour, ILocomotionInput
{
    public Transform Camera;

    private Vector3 inputDirection = Vector3.zero;
    private float? mostRecentJumpPress;

    public Vector3 DirectionXZ { get; private set; } = Vector2.zero;
    public float SpeedXZ { get; private set; } = 0f;
    public Quaternion RotationY { get; private set; } = Quaternion.identity;
    public bool Run { get; private set; } = false;
    public bool Jump => mostRecentJumpPress + Constants.JUMP_BUTTON_PRESS_GRACE_PERIOD >= Time.time;

    public void Awake()
    {

    }

    public void OnApplicationFocus(bool focus)
    {
        Cursor.lockState = focus ? CursorLockMode.Locked : CursorLockMode.None;
    }

    public void Update()
    {
        DirectionXZ = (Quaternion.AngleAxis(Camera.rotation.eulerAngles.y, Vector3.up) * inputDirection).normalized;

        if (DirectionXZ != Vector3.zero)
        {
            RotationY = Quaternion.LookRotation(DirectionXZ, Vector3.up);
        }

        SpeedXZ = Mathf.Clamp01(inputDirection.magnitude) * (Run ? Constants.RUN_SPEED : Constants.WALK_SPEED);
    }

    public void OnMovement(InputValue value)
    {
        var input = value.Get<Vector2>();

        inputDirection = new Vector3(input.x, 0, input.y);
    }

    public void OnJump(InputValue value)
    {
        if(value.isPressed)
        {
            mostRecentJumpPress = Time.time;
        }
    }

    public void OnRun(InputValue value)
    {
        Run = value.isPressed;
    }
}