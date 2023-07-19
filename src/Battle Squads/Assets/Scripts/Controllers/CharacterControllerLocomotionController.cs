using UnityEngine;

public class CharacterControllerLocomotionController : MonoBehaviour, ILocomotionController, ILocomotionCollisions
{
    private CharacterController _controller;
    private float _initialStepOffset;
    private Vector3 _cumulativeTranslation = Vector3.zero;

    [SerializeField] public float RotationSpeed { get; private set; } = 10f;
    [SerializeField] public float TerminalVelocity { get; } = -40f;

    public Vector3 CumulativeVelocity { get; private set; } = Vector3.zero;
    public bool IsGrounded => _controller.isGrounded;
    public CollisionFlags Flags { get; private set; } = CollisionFlags.None;

    public void Awake()
    {
        _controller = GetComponent<CharacterController>();

        _initialStepOffset = _controller.stepOffset;
    }

    public void Update()
    {
        // Prevents attempting to step when colliding with a wall
        _controller.stepOffset = IsGrounded ? _initialStepOffset : 0f;

        ApplyGravity();

        _cumulativeTranslation += CumulativeVelocity * Time.deltaTime;

        AdjustForSlopesAndStairs();

        Flags = _controller.Move(_cumulativeTranslation);

        _cumulativeTranslation = Vector3.zero;
    }

    public void ApplyRotation(Quaternion rotation)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, RotationSpeed * Time.deltaTime);
    }

    public void ApplyVelocity(Vector3 velocity)
    {
        CumulativeVelocity += velocity;
    }

    public void ApplyTranslation(Vector3 translation)
    {
        _cumulativeTranslation += translation;
    }

    public void Reset()
    {
        _cumulativeTranslation = Vector3.zero;
        CumulativeVelocity = Vector3.zero;
    }

    private void ApplyGravity()
    {
        if (IsGrounded && CumulativeVelocity.y < 0f)
        {
            CumulativeVelocity = new Vector3(CumulativeVelocity.x, -_initialStepOffset, CumulativeVelocity.z);
        }
        else
        {
            CumulativeVelocity += Physics.gravity * Time.deltaTime;
        }

        if(CumulativeVelocity.y < TerminalVelocity)
        {
            CumulativeVelocity = new Vector3(CumulativeVelocity.x, TerminalVelocity, CumulativeVelocity.z);
        }
    }

    private void AdjustForSlopesAndStairs()
    {
        var ray = new Ray(transform.position, Vector3.down);

        if(IsGrounded && Physics.Raycast(ray, out var hitInfo, _initialStepOffset))
        {
            var rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
            var adjustedTranslation = rotation * _cumulativeTranslation;

            if(adjustedTranslation.y < 0f)
            {
                adjustedTranslation.y = -_initialStepOffset;

                _cumulativeTranslation = adjustedTranslation;
            }
        }
    }
}
