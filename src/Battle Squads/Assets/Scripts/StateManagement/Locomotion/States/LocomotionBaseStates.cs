using UnityEngine;

public abstract class LocomotionBaseState : State<LocomotionStateContext>
{
    protected void MoveXZ(LocomotionStateContext context, float maxSpeed)
    {
        var horizontalVelocity = context.Input.SpeedXZ * maxSpeed * context.Input.DirectionXZ;

        context.Controller.ApplyTranslation(horizontalVelocity * Time.deltaTime);
    }
}