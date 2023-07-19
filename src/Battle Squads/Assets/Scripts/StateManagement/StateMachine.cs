using UnityEngine;

public abstract class StateMachine<TContext> : IStateMachine<TContext>
{
    protected TContext _context;
    protected IState<TContext> _currentState;

    public IState<TContext> PreviousState { get; protected set; }
    public float CurrentStateElapsedTime { get; protected set; } = 0f;

    public StateMachine(TContext context)
    {
        _context = context;
    }

    public void SwitchState<TState>() where TState : IState<TContext>, new()
    {
        if(_currentState?.GetType() == typeof(TState))
        {
            Debug.Log($"Attempted to call SwitchState for same state type ({typeof(TState).Name})");
            return;
        }

        _currentState?.Exit(this, _context);

        PreviousState = _currentState;
        _currentState = new TState();

        CurrentStateElapsedTime = 0f;
        _currentState.Enter(this, _context);
    }

    public void Update()
    {
        CurrentStateElapsedTime += Time.deltaTime;
        _currentState?.Update(this, _context);
    }
}
