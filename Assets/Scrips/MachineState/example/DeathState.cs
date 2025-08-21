using UnityEngine;

public class DeathState : BaseCharacterState
{
    public override void EnterState()
    {
        Debug.Log("On death State");
    }
}
