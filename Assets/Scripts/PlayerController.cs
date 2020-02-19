using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float jump = 500.0f;
    [SerializeField] private Transform groundPosition;
    [SerializeField] private LayerMask whatGround;
    [SerializeField] private float radius;


    private Rigidbody2D body2d;
    private Animator animator;
    private bool ground = false;
    private bool right = true;
    private bool crouch = false;
    // Start is called before the first frame update
    void Start()
    {
        body2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 move = Vector2.zero;
        float forward = Input.GetAxis("Horizontal");

        ground = checkingIfInGround();

        if(ground && Input.GetAxis("Jump") > 0)
        {
            body2d.AddForce(new Vector2(0.0f, jump));
            ground = false;
        }
        
        body2d.velocity = new Vector2(forward * speed, body2d.velocity.y) ;

        if(ground && body2d.velocity.x == 0 && Input.GetAxis("Vertical") < 0)
        {
            crouch = true;
        }
        else
        {
            crouch = false;
        }

        if (right && body2d.velocity.x < 0)
        {
            flipping();
        }
        else if(!right && body2d.velocity.x > 0)
        {
            flipping();
        }

        animator.SetFloat("speedX", Mathf.Abs(body2d.velocity.x));
        animator.SetFloat("speedY", Mathf.Abs(body2d.velocity.y));
        animator.SetBool("ground", ground);
        animator.SetBool("crouch", crouch);
    }
    
    private bool checkingIfInGround()
    {
        return Physics2D.OverlapCircle(groundPosition.position, radius, whatGround);
    }
    private void flipping()
    {
        Vector3 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;

        right = !right;
    }
}
