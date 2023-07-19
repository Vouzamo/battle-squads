using UnityEngine;

public class LandingState : LocomotionBaseState
{
    private readonly int _stateHashName;

    public LandingState()
    {
        _stateHashName = Animator.StringToHash("Landing");
    }

    public override void Enter(IStateMachine<LocomotionStateContext> stateMachine, LocomotionStateContext context)
    {
        context.Animator.CrossFadeInFixedTime(_stateHashName);
    }

    public override void Update(IStateMachine<LocomotionStateContext> stateMachine, LocomotionStateContext context)
    {
        if(stateMachine.CurrentStateElapsedTime > 1f - context.Input.SpeedXZ)
        {
            stateMachine.SwitchState<GroundedState>();
        }
    }
}