using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{



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

        if(ground && body2d.velocity.x == 0 && Input.GetAxis("Vertical") < 0)
        {

        }
    }
}
