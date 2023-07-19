using UnityEngine;

public class ImpactState : LocomotionBaseState
{
    private readonly int _stateHashName;

    public ImpactState()
    {
        _stateHashName = Animator.StringToHash("Impact");
    }

    public override void Enter(IStateMachine<LocomotionStateContext> stateMachine, LocomotionStateContext context)
    {
        context.Animator.CrossFadeInFixedTime(_stateHashName);
    }

    public override void Update(IStateMachine<LocomotionStateContext> stateMachine, LocomotionStateContext context)
    {
        // Player is dead?
    }
}
