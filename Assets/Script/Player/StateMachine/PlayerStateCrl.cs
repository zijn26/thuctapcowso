using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateCrl : PlayerMOve
{
    // Start is called before the first frame update
    protected PlayerStateMachine pStateMachine;
    public IdleState idleState;
    public RunState runState;
    public JumpState jumpState;
    public AttackState attackState;
    void Awake()
    {
        pStateMachine = new PlayerStateMachine();
        idleState = new IdleState(null, pStateMachine, this);
        runState = new RunState(null, pStateMachine, this);
        jumpState = new JumpState(null, pStateMachine, this);
        attackState = new AttackState(null, pStateMachine, this);
        pStateMachine.InnitState(idleState);
    }
    protected override void Update()
    {
        base.Update();
        pStateMachine.currentState.UpdateState();
    }
    protected override void FixedUpdate()
    {
        Flip();
        pStateMachine.currentState.FixedUpdateState();
    }
}
