using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : IPlayerState
{
    private PlayerCrl _playerCrl;
    private PlayerStateMachine _pStateMachine;
    private PlayerStateCrl _pMove;
    public PlayerCrl playerCrl { get => _playerCrl; set => _playerCrl = value; }
    public PlayerStateMachine pStateMachine { get => _pStateMachine; set => _pStateMachine = value; } 
    public PlayerStateCrl pMove { get => _pMove; set => _pMove = value; }
     public RunState(PlayerCrl playerCrl, PlayerStateMachine pStateMachine, PlayerStateCrl playerMOve)
    {
        this.playerCrl = playerCrl;
        this.pStateMachine = pStateMachine;
        this.pMove = playerMOve;
    }

    public void EnterStae()
    {
        this.pMove.animator.SetBool("IsRun", true);
    }

    public void ExitState()
    {
        this.pMove.animator.SetBool("IsRun", false);
    }

    public void UpdateState()
    {
       
    }

    public void FixedUpdateState()
    {
        this.pMove.Move(1);
        if (Mathf.Abs(this.pMove.dirMove.x) < 0.05f)
        {
            this.pStateMachine.ChangState(this.pMove.idleState);
        }
        if(this.pMove.dirMove.y > 0)
        {
            this.pStateMachine.ChangState(this.pMove.jumpState);
        }
    }
}
