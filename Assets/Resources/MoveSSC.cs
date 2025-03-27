using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "MoveSC")]
public class MoveSSC : ScriptableObject
{
    [SerializeField] private float timeToMaxSpeed ;
    [SerializeField] public float accelGround ; 
    [SerializeField] public float accelAir;

    [SerializeField] public float timeToMaxHight;
    // [SerializeField] private float maxJumpHight;
    // [SerializeField] public float scaleGravity;
    // [SerializeField] private float gravityToJump;
    public float jumpForce;
    public float mulJump;
    private void OnValidate()
    {
        // this.gravityToJump = -(2 * maxJumpHight ) / (timeToMaxHight * timeToMaxHight);

        // scaleGravity = this.gravityToJump / Physics2D.gravity.y;

        // jumpForce =  Mathf.Abs(gravityToJump) * timeToMaxHight; 
        
        this.accelGround = 1 / timeToMaxSpeed;
    }
}
