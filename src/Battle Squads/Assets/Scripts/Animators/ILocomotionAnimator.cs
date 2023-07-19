using UnityEngine;

/// <summary>
/// An abstraction of the Unity Animator to encapsulate cumulative root transforms amongst other things
/// </summary>
public interface ILocomotionAnimator
{
    /// <summary>
    /// Cross fades from current animation to another using a fixed duration in seconds
    /// </summary>
    /// <param name="stateHashName">Integer hash of animation to fade to</param>
    /// <param name="fixedTransitionDuration">Float duration in seconds</param>
    public void CrossFadeInFixedTime(int stateHashName, float fixedTransitionDuration = 0.1f);

    /// <summary>
    /// Returns (and resets) the cumulative root motion translation
    /// </summary>
    /// <returns>Vector3 translation representing the cumulative root motion recorded since the last time it was processed</returns>
    public Vector3 ProcessRootMotionTranslation();

    /// <summary>
    /// Sets an animation property to indicate the subjects horizontal speed on the XZ plane
    /// </summary>
    /// <param name="speedXZ">Float speed normalized between 0 and 1</param>
    /// <param name="deltaTime">Float delta time in seconds for the current update</param>
    public void SetMagnitudeXZ(float speedXZ, float deltaTime);

    public void SetMagnitudeY(float speedY, float deltaTime);
}
