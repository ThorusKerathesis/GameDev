using System;
using System.Collections.Generic;

public class StateMachine
{
    private iState _CurrentState;
    private Dictionary<Type, List<Transition>> _transitions = new Dictionary<Type, List<Transition>>();
    private List<Transition> _CurrentTransitions = new List<Transition>();
    private List<Transition> _AnyTransitions = new List<Transition>();

    private static List<Transition> EmptyTransitions = new List<Transition>(0);

    public void Tick()
    {
        var transition = GetTransition();
        if (transition != null)
            SetState(transition.To);

        _CurrentState?.Tick();
    }

    public void SetState(iState state) 
    {
        if (state == _CurrentState)
            return;

        _CurrentState?.OnExit();
        _CurrentState = state;

        _transitions.TryGetValue(_CurrentState.GetType(), out _CurrentTransitions);
        if (_CurrentTransitions == null)
            _CurrentTransitions = EmptyTransitions;

        _CurrentState.OnEnter();

    }

    public void AddTransition(iState from, iState to, Func<bool> predicate)
    {
        if (_transitions.TryGetValue(from.GetType(), out var transitions) == false) {
            transitions = new List<Transition>();
            _transitions[from.GetType()] = transitions;
        }

        transitions.Add(new Transition(to, predicate));

    }
    public void AddAnyTransition(iState state, Func<bool> predicate)
    {
        _AnyTransitions.Add(new Transition(state, predicate));
    }


    private class Transition
    {
        public iState To { get; }
        public Func<bool> Condition { get; }

        public Transition(iState to, Func<bool> condition)
        {
            To = to;
            Condition = condition;
        }
    }

    private Transition GetTransition() {
        foreach (var transition in _AnyTransitions)
            if (transition.Condition())
                return transition;

        foreach (var transition in _CurrentTransitions)
            if (transition.Condition())
                return transition;

        return null;
    }
}
