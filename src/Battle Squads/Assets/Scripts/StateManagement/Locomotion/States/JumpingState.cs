using UnityEngine;

public class JumpingState : LocomotionBaseState
{
    private readonly int _stateHashName;

    public JumpingState()
    {
        _stateHashName = Animator.StringToHash("Jumping");
    }

    public override void Enter(IStateMachine<LocomotionStateContext> stateMachine, LocomotionStateContext context)
    {
        context.Animator.CrossFadeInFixedTime(_stateHashName);

        context.Controller.ApplyVelocity(new Vector3(0, 10f, 0));
    }

    public override void Update(IStateMachine<LocomotionStateContext> stateMachine, LocomotionStateContext context)
    {
        MoveXZ(context, 5f);

        if (context.Controller.CumulativeVelocity.y < 0f)
        {
            stateMachine.SwitchState<FallingState>();
        }
    }
}
