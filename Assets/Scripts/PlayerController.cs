using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float jumpForce = 10f;
    private Rigidbody2D rigidBody;
    Animator animator;
    public LayerMask groundMask;

    private const string STATE_ALIVE = "isAlive";
    private const string STATE_ON_THE_GROUND = "isOnTheGround";


    void Awake(){
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
       animator.SetBool(STATE_ALIVE, true);
       animator.SetBool(STATE_ON_THE_GROUND, false); 
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space)){
            Jump();
        }
        animator.SetBool(STATE_ON_THE_GROUND, IsTouchingTheGround());
    }
    void Jump(){
        if(IsTouchingTheGround()){
        rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        }
    }

    bool IsTouchingTheGround(){
        if(Physics2D.Raycast(this.transform.position, Vector2.down, 2.0f, groundMask)){
            return true;
        }
        else{
            return false;
        }
    }
}
