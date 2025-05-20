using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMOve : BaseMove
{
    public Animator animator;
    protected override void Start()
    {
        base.Start();
    }
    // Update is called once per frame
    protected override float GetMaxSpeed()
    {
        return PlayerCrl.Instance.proceserPlayer.statSys.GetStatNumber(StatType.Speed);
    }
    protected override void LoadMoveSC()
    {
        if (moveSC != null) return;
        moveSC = Resources.Load<MoveSSC>("MoveSC");
        if (moveSC == null) Debug.LogError("MoveSC not found");
    }
    protected override void LoadGroundCheck()
    {
        this.centerGCheck = this.transform.GetChild(0).GetChild(0);
    }
    protected override void LoadDirMove()
    {
        dirMove.x = Input.GetAxis("Horizontal");
        dirMove.y = Input.GetAxis("Vertical");
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadAnimator();
    }
    protected void LoadAnimator()
    {
        if (animator == null)
        {
            animator = GetComponentInChildren<Animator>();
            if (animator == null) Debug.LogError("Animator not found");
        }
    }
}
