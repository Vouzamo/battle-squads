using UnityEngine;
/// <summary>
/// Exposes collision flags relating to locomotion
/// </summary>
public interface ILocomotionCollisions
{
    /// <summary>
    /// Boolean flag to indicate if the subject is currently colliding with the ground (usually because of gravity)
    /// </summary>
    public bool IsGrounded { get; }

    /// <summary>
    /// Provides information about the most recent movement collisions
    /// </summary>
    public CollisionFlags Flags { get; }
}
