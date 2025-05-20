using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : IPlayerState
{
    private PlayerCrl _playerCrl;
    private PlayerStateMachine _pStateMachine;
    private PlayerStateCrl _pMove;
    public PlayerCrl playerCrl { get => _playerCrl; set => _playerCrl = value; }
    public PlayerStateMachine pStateMachine { get => _pStateMachine; set => _pStateMachine = value; } 
    public PlayerStateCrl pMove { get => _pMove; set => _pMove = value; }
    public JumpState(PlayerCrl playerCrl, PlayerStateMachine pStateMachine, PlayerStateCrl playerMOve)
    {
        this.playerCrl = playerCrl;
        this.pStateMachine = pStateMachine;
        this.pMove = playerMOve;
    }

    public void EnterStae()
    {
        this.pMove.animator.SetBool("IsJump", true);
    }

    public void ExitState()
    {
        this.pMove.animator.SetBool("IsJump", false);
    }

    public void UpdateState()
    {
    }

    public void FixedUpdateState()
    {
        this.pMove.Move(1);
        this.pMove.HandleJump();
        if (!this.pMove.isJumping && Mathf.Abs(this.pMove.dirMove.x) > 0.1f)
        {
            this.pStateMachine.ChangState(this.pMove.runState);
            return;
        }
        if (!this.pMove.isJumping)
        {
            this.pStateMachine.ChangState(this.pMove.idleState);
            return;
        }
    }
}
