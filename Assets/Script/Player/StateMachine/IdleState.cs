using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IPlayerState 
{
    private PlayerCrl _playerCrl;
    private PlayerStateMachine _pStateMachine;
    private PlayerStateCrl _pMove;
    public PlayerCrl playerCrl { get => _playerCrl; set => _playerCrl = value; }
    public PlayerStateMachine pStateMachine { get => _pStateMachine; set => _pStateMachine = value; }
    public PlayerStateCrl pMove { get => _pMove; set => _pMove = value; }

    public IdleState(PlayerCrl playerCrl, PlayerStateMachine pStateMachine, PlayerStateCrl playerMOve)
    {
        this.playerCrl = playerCrl;
        this.pStateMachine = pStateMachine;
        this.pMove = playerMOve;
    }

    public void EnterStae()
    {
        this.pMove.animator.SetBool("IsRun", false);
        this.pMove.animator.SetBool("IsJump", false);
        this.pMove.animator.SetBool("IsIdle", true);
    }

    public void ExitState()
    {
        this.pMove.animator.SetBool("IsIdle", false);
    }

    public void FixedUpdateState()
    {
        this.pMove.Move(1);
        if (Mathf.Abs(this.pMove.dirMove.x) != 0)
        {
            this.pStateMachine.ChangState(this.pMove.runState);
            return;
        }
        if (this.pMove.dirMove.y > 0)
        {
            this.pStateMachine.ChangState(this.pMove.jumpState);
            return;
        }
    }

    public void UpdateState()
    {
        
    }
}
