using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    MachineState machineState;
    IdleState idle = new();
    DeathState death = new();
    WalkState walk = new();
    RunState run = new();

    [SerializeField] float horizontal;
    [SerializeField] bool isGrounded;

    private void Start()
    {
        machineState = GetComponent<MachineState>();
        machineState.SetState(idle);

        machineState.AddTransition(idle,new StateTransition(walk, ()=> horizontal != 0));
        machineState.AddTransition(idle,new StateTransition(run, ()=> horizontal != 0 && Input.GetKey(KeyCode.LeftShift)&& isGrounded));
        machineState.AddTransition(walk,new StateTransition(run, ()=> horizontal != 0 && Input.GetKey(KeyCode.LeftShift)&& isGrounded));
        machineState.AddTransition(walk, new StateTransition(idle, () => horizontal == 0));
    }
}
