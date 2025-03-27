using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMOve : HungMono
{
    [SerializeField] private float lastTimeOnGorund;
    [SerializeField] private float timeJumpCounter;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector2 dirMove; 
    
    [SerializeField] private MoveSSC moveSC;
    private bool isJumping;

    
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Vector2 gCheckSize;
    [SerializeField] private Transform centerGCheck;
    protected override void Start()
    {
        base.Start();
    }
    // Update is called once per frame
    void Update()
    {
        dirMove.x = Input.GetAxisRaw("Horizontal");
        dirMove.y = Input.GetAxisRaw("Vertical");

        lastTimeOnGorund = ( lastTimeOnGorund < 0) ? 0 : -1 * Time.deltaTime;
        GroundCheck();  
      
    }
    void FixedUpdate()
    {
        Move(1);
        if(dirMove.y > 0 )
        {
            if(lastTimeOnGorund > 0 ) Jump();
            
            if(isJumping && moveSC.timeToMaxHight > timeJumpCounter)
            {
                timeJumpCounter += Time.deltaTime;
                rb.velocity = new Vector2(rb.velocity.x , rb.velocity.y - (Physics2D.gravity.y * moveSC.mulJump * Time.deltaTime));
            }
        }else{
            isJumping = false;
        }
    }
    private void Move(float lerpAmout)
    {
        float targetSpeed = this.dirMove.x  
            *   PlayerCrl.Instance.proceserPlayer.statSys.GetStatNumber(StatType.Speed);

        targetSpeed = Mathf.Lerp(PlayerCrl.Instance.proceserPlayer.statSys.GetStatNumber(StatType.Speed), targetSpeed , lerpAmout);

        float difSpeed = targetSpeed - this.rb.velocity.x;

        float force = difSpeed * moveSC.accelGround;

        this.rb.AddForce(force * Vector2.right);
    }
    private void Jump()
    {
        isJumping = true;
        rb.AddForce(moveSC.jumpForce * Vector2.up ,ForceMode2D.Impulse);
        timeJumpCounter = 0;
    }
    void GroundCheck()
    {
        if(Physics2D.OverlapBox(centerGCheck.position , gCheckSize , 0 , layerMask))
        {
            this.lastTimeOnGorund = 1;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(this.centerGCheck.position , gCheckSize );
    }
    protected override void LoadComponent()
    {
        Debug.Log("done load Move component");

        this.rb = this.GetComponent<Rigidbody2D>();
        this.moveSC = Resources.Load<MoveSSC>("MoveSC");

        this.centerGCheck = this.transform.GetChild(0).GetChild(0);
    }
    public void SetGravityScale(float scaleGravity)
    {
        this.rb.gravityScale = scaleGravity;
    }
}
