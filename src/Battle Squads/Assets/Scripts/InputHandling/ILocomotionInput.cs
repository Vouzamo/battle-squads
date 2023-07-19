using UnityEngine;

public interface ILocomotionInput
{
    public Vector3 DirectionXZ { get; }
    public float SpeedXZ { get; }
    public Quaternion RotationY { get; }
    public bool Jump { get; }
}