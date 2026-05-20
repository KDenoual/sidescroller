using UnityEngine;

public class PlayerMovementPlatformer : MonoBehaviour
{
   
    public Transform maaTransform;
    public Rigidbody2D rb;
    public float speed = 1;
    public float jumpforce = 1;
    public LayerMask mask;
    public bool isGround;
    public bool Jump;
    public float DashSpeed = 1;
    public float DashDuration = 1;
    public float DashCooldown = 1;

    public bool flipX;

    private Vector2 dashDirection;
    public bool isDashing = false;
    private float dashTimeLeft;
    private float lastDashTime;

    [SerializeField]private SpriteRenderer spriteRenderer;
    [SerializeField]private Animator animator;

    void Update()
    {
        bool isRuning;
        var hDirection = 0f;
        var vDirection = 0f;
        if(isGround == true || Jump == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                {
                    vDirection += jumpforce;
                } 
            }   
        }

        if (Input.GetKey(KeyCode.A))
        {
            hDirection += -1;
        }
        if(Input.GetKey(KeyCode.D))
        {
            hDirection += 1;
        }


        if(rb.linearVelocityX>0 || rb.linearVelocityX<0)
        {
           isRuning = true;
        }
        else isRuning = false;

        animator.SetBool("isRuning",isRuning);

        if (rb.linearVelocityX > 2)
        {
            flipX = true;
        }

        else if (rb.linearVelocityX < -2)
        {
            flipX = false;
        }
    
        if (flipX)
        {
            maaTransform.localScale = new Vector3(x: 1, maaTransform.localScale.y, maaTransform.localScale.z);
        }

        else 
        {
            maaTransform.localScale = new Vector3(x: -1, maaTransform.localScale.y, maaTransform.localScale.z);
        }
    


        //transform.localScale = new Vector3(Mathf.Sign(hDirection),transform.localScale.y,1);

        if (Time.time >= lastDashTime + DashCooldown && !isDashing)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                StartDash();
            }
        }
        if (isDashing)
        {
            animator.SetTrigger("isDashing");
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            animator.SetTrigger("isFihting");
        }

            rb.linearVelocity = new Vector2(hDirection * speed, rb.linearVelocityY+vDirection);
    }
    void FixedUpdate()
    {
        if (isDashing)
        {
            if (dashTimeLeft > 0)
            {
                rb.linearVelocity = dashDirection * DashSpeed;
                dashTimeLeft -= Time.fixedDeltaTime;
            }
            else
            {
                isDashing = false;
            }
        }
    }

    private void StartDash()
    {

        float moveX = Input.GetAxisRaw("Horizontal");

        if (moveX == 0)
            moveX = transform.localScale.x > 0 ? 1 : -1;

        dashDirection = new Vector2(moveX, 0).normalized;

        isDashing = true;
        dashTimeLeft = DashDuration;
        lastDashTime = Time.time;
    }
}