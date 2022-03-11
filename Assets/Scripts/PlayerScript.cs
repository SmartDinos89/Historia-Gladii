
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed = 5f;

    public Animator animator;

    public float xAxis;
    private float yAxis;
    public GameObject playerVis;
    public Rigidbody2D rb2d;
    private bool isJumpPressed;
    private float jumpForce = 850;
    public LayerMask groundMask;
    [HideInInspector]
    public bool isGrounded;

    public Transform groundCheck;
    private string currentAnimaton;
    [HideInInspector]
    public bool isAttackPressed;
    [HideInInspector]
    public bool isAttacking;
    public float maxHealth = 100;
	public float currentHealth;
	public HealthBar healthBar;

    public GameObject Tomb;
    public Respawnandcheckpoint respawn;
    public GameObject blackScreen;
    public GameObject ui2;
    public bool Dead;
    bool movingRight = true;
    [SerializeField]
    

    //Animation States
    const string PLAYER_IDLE = "Idle";
    const string PLAYER_RUN = "Run";
    const string PLAYER_JUMP = "Jump";
    const string PLAYER_ATTACK = "Attack";
    const string PLAYER_AIR_ATTACK = "Attack";
    const string PLAYER_HURT = "Hurt";
    const string PLAYER_DEATH = "Death";

    //=====================================================
    // Start is called before the first frame update
    //=====================================================
    void Start()
    {
        currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);

    }

    //=====================================================
    // Update is called once per frame
    //=====================================================
    void Update()
    {
        //Checking for inputs
        xAxis = Input.GetAxisRaw("Horizontal");

        //space jump key pressed?
        if (Input.GetButtonDown("Jump"))
        { 
            isJumpPressed = true;
        }

        //space Atatck key pressed?
        if (Input.GetMouseButtonDown(0))
        {
            isAttackPressed = true;
        }
    }

    //=====================================================
    // Physics based time step loop
    //=====================================================
    private void FixedUpdate()
    {
        //check if player is on the ground
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.1f, groundMask);

        if (hit.collider != null)
        {
            isGrounded = true;
            animator.SetBool("Grounded", true);
        }
        else
        {
            isGrounded = false;
            animator.SetBool("Grounded", false);
        }

        //------------------------------------------

        //Check update movement based on input
        Vector2 vel = new Vector2(0, rb2d.velocity.y);

        if (xAxis < 0)
        {
            vel.x = -walkSpeed;
        }
        else if (xAxis > 0)
        {
            vel.x = walkSpeed;
            
        }
        else
        {
            vel.x = 0;
            
        }
        if (xAxis < 0 && movingRight || xAxis > 0 && !movingRight)
        {
            Flip();
        }


        if (isGrounded && !isAttacking && !hurts && !Dead)
        {
            if (xAxis != 0)
            {
                ChangeAnimationState(PLAYER_RUN);
            }
            else
            {
                ChangeAnimationState(PLAYER_IDLE);
            }
        }

        //------------------------------------------

        //Check if trying to jump 
        if (isJumpPressed && isGrounded)
        {
            rb2d.AddForce(new Vector2(0, jumpForce));
            isJumpPressed = false;
            ChangeAnimationState(PLAYER_JUMP);
        }

        //assign the new velocity to the rigidbody
        rb2d.velocity = vel;


    }

    

    //=====================================================
    // mini animation manager
    //=====================================================
    public void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimaton == newAnimation) return;

        animator.Play(newAnimation);
        currentAnimaton = newAnimation;
    }
    private bool hurts = false;
    public void TakeDamage(float damage)
	{
		currentHealth -= damage;

        StartCoroutine(Iframe());

		healthBar.SetHealth(currentHealth);

        ChangeAnimationState(PLAYER_HURT);

	}


    public IEnumerator die(){
        rb2d.isKinematic = true;
        Dead = true;
        ChangeAnimationState(PLAYER_DEATH);
        yield return new WaitForSeconds(1f);
        Instantiate(Tomb, transform.position, transform.rotation);
        ui2.SetActive(false);
        blackScreen.SetActive(true);
        rb2d.isKinematic = false;
        respawn.respawn();
        healthBar.SetHealth(maxHealth);
        currentHealth = maxHealth;
        yield return new WaitForSeconds(2f);
        blackScreen.SetActive(false);
        ui2.SetActive(true);
        Dead = false;

    }

    IEnumerator Iframe(){
        Physics2D.IgnoreLayerCollision(6,7,true);
        yield return new WaitForSeconds(.7f);
        Physics2D.IgnoreLayerCollision(6,7,false);
    }

    void Flip(){
        movingRight = !movingRight;

        transform.Rotate(0f, 180f, 0f);
    }

}
