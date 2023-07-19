public interface IState<TContext>
{
    public virtual void Enter(IStateMachine<TContext> stateMachine, TContext context)
    {

    }

    public virtual void Update(IStateMachine<TContext> stateMachine, TContext context)
    {

    }

    public virtual void Exit(IStateMachine<TContext> stateMachine, TContext context)
    {

    }
}
