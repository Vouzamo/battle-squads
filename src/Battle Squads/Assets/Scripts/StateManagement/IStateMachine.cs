public interface IStateMachine<TContext>
{
    public IState<TContext> PreviousState { get; }
    public float CurrentStateElapsedTime { get; }
    public void SwitchState<TState>() where TState : IState<TContext>, new();
}
