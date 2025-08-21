using UnityEngine;

public interface ICharacterState
{
    public void EnterState();
    public void UpdateState();
    public void FixedUpdateState();
    public void ExitState();
}
