public class LocomotionStateContext
{
    public ILocomotionInput Input { get; private set; }
    public ILocomotionController Controller { get; private set; }
    public ILocomotionCollisions Collisions { get; private set; }
    public ILocomotionAnimator Animator { get; private set; }

    public LocomotionStateContext(ILocomotionInput input, ILocomotionController controller, ILocomotionCollisions collisions, ILocomotionAnimator animator)
    {
        Input = input;
        Controller = controller;
        Collisions = collisions;
        Animator = animator;
    }
}
