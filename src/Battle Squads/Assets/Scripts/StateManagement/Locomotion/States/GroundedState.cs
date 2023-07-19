using UnityEngine;

public class GroundedState : LocomotionBaseState
{
    private LocomotionStateMachine _stateMachine;

    public override void Enter(IStateMachine<LocomotionStateContext> stateMachine, LocomotionStateContext context)
    {
        //context.Controller.Reset();
        
        _stateMachine = new LocomotionStateMachine(context);

        if(context.Input.DirectionXZ.magnitude > 0f)
        {
            _stateMachine.SwitchState<MovingState>();
        }
        else
        {
            _stateMachine.SwitchState<IdleState>();
        }
    }

    public override void Update(IStateMachine<LocomotionStateContext> stateMachine, LocomotionStateContext context)
    {
        _stateMachine.Update();

        context.Animator.SetMagnitudeXZ(context.Input.SpeedXZ, Time.deltaTime);

        if (!context.Collisions.IsGrounded)
        {
            stateMachine.SwitchState<FallingState>();
        }

        if (context.Input.Jump)
        {
            stateMachine.SwitchState<JumpingState>();
        }
    }
}
