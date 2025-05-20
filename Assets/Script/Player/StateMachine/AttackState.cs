using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : MonoBehaviour
{
    private PlayerCrl _playerCrl;
    private PlayerStateMachine _pStateMachine;
    private PlayerStateCrl _pMove;
    public PlayerCrl playerCrl { get => _playerCrl; set => _playerCrl = value; }
    public PlayerStateMachine pStateMachine { get => _pStateMachine; set => _pStateMachine = value; } 
    public PlayerStateCrl pMove { get => _pMove; set => _pMove = value; }
    public AttackState(PlayerCrl playerCrl, PlayerStateMachine pStateMachine, PlayerStateCrl playerMOve)
    {
        this.playerCrl = playerCrl;
        this.pStateMachine = pStateMachine;
        this.pMove = playerMOve;
    }
}
