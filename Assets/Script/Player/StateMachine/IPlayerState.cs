using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerState
{
    public PlayerCrl playerCrl { get; set; }
    public PlayerStateMachine pStateMachine { get; set; }
    public void EnterStae();
    public void ExitState();
    public void UpdateState();
    public void FixedUpdateState();
}
