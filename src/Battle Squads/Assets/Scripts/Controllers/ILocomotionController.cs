using UnityEngine;

/// <summary>
/// Encapsulates any change in motion and status of colliders
/// </summary>
public interface ILocomotionController
{
    public Vector3 CumulativeVelocity { get; }
    public float TerminalVelocity { get; }

    /// <summary>
    /// Applies a cumulative translation to be applied during each Update
    /// </summary>
    /// <param name="translation">Vector3 translation with Time.deltaTime already applied</param>
    public void ApplyTranslation(Vector3 translation);

    /// <summary>
    /// Applies a cumulative velocity to be applied during each Update
    /// </summary>
    /// <param name="velocity">Vector3 translation without Time.deltaTime applied</param>
    public void ApplyVelocity(Vector3 velocity);

    /// <summary>
    /// Applies a quaternion rotation to the transform
    /// </summary>
    /// <param name="rotation">Quaternion rotation without Time.deltaTime applied</param>
    public void ApplyRotation(Quaternion rotation);

    /// <summary>
    /// Resets any cumulative velocity or translation to Vector3.zero
    /// </summary>
    public void Reset();
}
