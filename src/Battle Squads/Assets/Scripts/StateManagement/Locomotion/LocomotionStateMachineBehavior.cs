using UnityEngine;

public class LocomotionStateMachineBehavior : MonoBehaviour
{
    private LocomotionStateMachine _stateMachine;

    public void Start()
    {
        var input = GetComponent<ILocomotionInput>();
        var controller = GetComponent<ILocomotionController>();
        var collisions = GetComponent<ILocomotionCollisions>();
        var animator = GetComponentInChildren<ILocomotionAnimator>();

        _stateMachine = new LocomotionStateMachine(new LocomotionStateContext(input, controller, collisions, animator));
        _stateMachine.SwitchState<GroundedState>();
    }

    public void Update()
    {
        _stateMachine.Update();
    }
}
