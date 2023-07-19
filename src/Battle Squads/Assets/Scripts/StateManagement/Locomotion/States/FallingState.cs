using UnityEngine;

public class FallingState : LocomotionBaseState
{
    private readonly int _stateHashName;

    public FallingState()
    {
        _stateHashName = Animator.StringToHash("Falling");
    }

    public override void Enter(IStateMachine<LocomotionStateContext> stateMachine, LocomotionStateContext context)
    {
        context.Animator.CrossFadeInFixedTime(_stateHashName);
    }

    public override void Update(IStateMachine<LocomotionStateContext> stateMachine, LocomotionStateContext context)
    {
        MoveXZ(context, 5f);

        context.Animator.SetMagnitudeY(context.Controller.CumulativeVelocity.y / context.Controller.TerminalVelocity, Time.deltaTime);

        if (context.Collisions.IsGrounded)
        {
            if (context.Controller.CumulativeVelocity.y < -20f)
            {
                stateMachine.SwitchState<ImpactState>();
            }
            else if (context.Controller.CumulativeVelocity.y < -5f)
            {
                stateMachine.SwitchState<LandingState>();
            }
            else
            {
                stateMachine.SwitchState<GroundedState>();
            }
        }
        else if (context.Input.Jump && stateMachine.CurrentStateElapsedTime <= 0.2f && stateMachine.PreviousState.GetType() == typeof(GroundedState))
        {
            stateMachine.SwitchState<JumpingState>();
        }
    }
}
