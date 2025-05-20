using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public abstract class BaseMove : HungMono
{
    [SerializeField] protected float lastTimeOnGorund;
    [SerializeField] protected float timeJumpCounter;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public Vector2 dirMove;

    [SerializeField] protected MoveSSC moveSC;
    public bool isJumping;


    [SerializeField] protected LayerMask layerMask;
    [SerializeField] protected Vector2 gCheckSize;
    [SerializeField] protected Transform centerGCheck;
    protected override void Start()
    {
        base.Start();
    }
    // Update is called once per frame
    protected virtual void Update()
    {
        LoadDirMove();

        lastTimeOnGorund = (lastTimeOnGorund < 0) ? 0 : -1 * Time.deltaTime;
        GroundCheck();

    }
    protected virtual void FixedUpdate()
    {
        Move(1);
        HandleJump();
        Flip();
    }
    public void Move(float lerpAmout)
    {
        float targetSpeed = this.dirMove.x
            * GetMaxSpeed();
        targetSpeed = Mathf.Lerp(GetMaxSpeed(), targetSpeed, lerpAmout);

        float difSpeed = targetSpeed - this.rb.velocity.x;

        float force = difSpeed * moveSC.accelGround;
        // Debug.Log("force: " + force );
        this.rb.AddForce(force * Vector2.right);
    }
    
    protected void Jump()
    {
        isJumping = true;
        rb.AddForce(moveSC.jumpForce * Vector2.up, ForceMode2D.Impulse);
        timeJumpCounter = 0;
    }
    public void HandleJump()
    {
        if (dirMove.y > 0)
        {
            if (lastTimeOnGorund > 0) Jump();

            if (isJumping && moveSC.timeToMaxHight > timeJumpCounter)
            {
                timeJumpCounter += Time.deltaTime;
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y - (Physics2D.gravity.y * moveSC.mulJump * Time.deltaTime));
            }
        }
        else
        {
            isJumping = false;
        }
    }
    protected override void LoadComponent()
    {
        Debug.Log("done load Move component");

        this.rb = this.GetComponent<Rigidbody2D>();
        LoadGroundCheck();
        LoadMoveSC();
    }
    protected abstract void LoadGroundCheck();
    protected abstract void LoadMoveSC();
    protected abstract float GetMaxSpeed();
    protected abstract void LoadDirMove();
    protected void GroundCheck()
    {
        if (Physics2D.OverlapBox(centerGCheck.position, gCheckSize, 0, layerMask))
        {
            this.lastTimeOnGorund = 1;
        }
    }
    protected void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(this.centerGCheck.position, gCheckSize);
    }

    public void SetGravityScale(float scaleGravity)
    {
        this.rb.gravityScale = scaleGravity;
    }
    protected void Flip()
    { 
        if (dirMove.x > 0)
        {
            this.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else if (dirMove.x < 0)
        {
            this.transform.rotation = new Quaternion(0, 180, 0, 0);
        }
    }
}
