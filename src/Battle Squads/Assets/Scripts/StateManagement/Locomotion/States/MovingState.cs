using UnityEngine;

public class MovingState : LocomotionBaseState
{
    private readonly int _stateHashName;

    public MovingState()
    {
        _stateHashName = Animator.StringToHash("Moving");
    }

    public override void Enter(IStateMachine<LocomotionStateContext> stateMachine, LocomotionStateContext context)
    {
        //context.Animator.ProcessRootMotionTranslation();

        context.Animator.CrossFadeInFixedTime(_stateHashName);
    }

    public override void Update(IStateMachine<LocomotionStateContext> stateMachine, LocomotionStateContext context)
    {
        var translationXZ = context.Animator.ProcessRootMotionTranslation();
        context.Controller.ApplyTranslation(translationXZ);

        context.Controller.ApplyRotation(context.Input.RotationY);
        
        if (context.Input.DirectionXZ.magnitude == 0f)
        {
            stateMachine.SwitchState<IdleState>();
        }
    }
}