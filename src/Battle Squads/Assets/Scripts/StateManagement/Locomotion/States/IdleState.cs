using UnityEngine;

public class IdleState : LocomotionBaseState
{
    private readonly int _stateHashName;

    public IdleState()
    {
        _stateHashName = Animator.StringToHash("Idle");
    }

    public override void Enter(IStateMachine<LocomotionStateContext> stateMachine, LocomotionStateContext context)
    {
        context.Animator.CrossFadeInFixedTime(_stateHashName);
    }

    public override void Update(IStateMachine<LocomotionStateContext> stateMachine, LocomotionStateContext context)
    {
        if (context.Input.DirectionXZ.magnitude > 0f)
        {
            stateMachine.SwitchState<MovingState>();
        }
    }
}
