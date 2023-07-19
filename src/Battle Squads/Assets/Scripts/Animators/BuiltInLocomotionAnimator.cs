using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BuiltInLocomotionAnimator : MonoBehaviour, ILocomotionAnimator
{
    private Animator _animator;

    private int MagnitudeXZHash;
    private int MagnitudeYHash;
    private Vector3 cumulativeDeltaPosition = Vector3.zero;

    public void Awake()
    {
        _animator = GetComponent<Animator>();

        MagnitudeXZHash = Animator.StringToHash("MagnitudeXZ");
        MagnitudeYHash = Animator.StringToHash("MagnitudeY");
    }

    public void OnAnimatorMove()
    {
        cumulativeDeltaPosition += _animator.deltaPosition;
    }

    public Vector3 ProcessRootMotionTranslation()
    {
        var rootMotion = cumulativeDeltaPosition;

        cumulativeDeltaPosition = Vector3.zero;

        return rootMotion;
    }

    public void SetMagnitudeXZ(float speedXZ, float deltaTime)
    {
        _animator.SetFloat(MagnitudeXZHash, Mathf.Clamp(speedXZ, 0f, 1f), 0.1f, deltaTime);
    }

    public void SetMagnitudeY(float speedY, float deltaTime)
    {
        _animator.SetFloat(MagnitudeYHash, speedY, 0.1f, deltaTime);
    }

    public void CrossFadeInFixedTime(int stateHashName, float fixedTransitionDuration = 0.1f)
    {
        _animator.CrossFadeInFixedTime(stateHashName, fixedTransitionDuration);
    }
}
