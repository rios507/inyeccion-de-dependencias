using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MachineState : MonoBehaviour
{
    ICharacterState currentState;

    Dictionary<ICharacterState, List<StateTransition>> transitions = new();
    List<StateTransition> anyTransitions = new();

    public void AddTransition(ICharacterState state, StateTransition transition)
    {
        if (!transitions.ContainsKey(state))
        {
            transitions.Add(state, new());
        }
        transitions[state].Add(transition);
    }
    public void CheckAnyTransitions()
    {
        foreach (var item in anyTransitions)
        {
            if (item.Conditions())
            {
                SetState(item.newState);
            }
        }
    }
    public void CheckStateTransitions()
    {
        if(currentState == null)
        {
            return; 
        }

        if (transitions.ContainsKey(currentState))
        {
            foreach (var item in transitions[currentState])
            {
                if (item.Conditions())
                {
                    SetState(item.newState);
                }
            }
        }
    }
    public void SetState(ICharacterState newState)
    {
        if (currentState != newState)
        {
            currentState?.ExitState();
            currentState = newState;
            currentState?.EnterState();
        } 
    }
    private void Update()
    {
        currentState?.UpdateState();
        CheckAnyTransitions();
        CheckStateTransitions();
    }
    private void FixedUpdate()
    {
        currentState?.FixedUpdateState();
    }
}
