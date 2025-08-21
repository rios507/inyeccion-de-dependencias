using System;
using UnityEngine;

public class StateTransition
{
    public ICharacterState newState;
    public Func<bool> Conditions;
    public StateTransition(ICharacterState newState, Func<bool> conditions)
    {
        this.newState = newState;
        this.Conditions = conditions;
    }


}
