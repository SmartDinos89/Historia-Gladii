
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private bool hurts = false;

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
        Dead = false;

    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Spike"){
            StartCoroutine(TakeDamage(1f));
        }
    }
    //=====================================================
    // Update is called once per frame
    //=====================================================
    void Update()
    {
        if(currentHealth <= 0)
        {
            if(!Dead)
            StartCoroutine(die());
        }
        //Checking for inputs
        xAxis = Input.GetAxisRaw("Horizontal");

        //space jump key pressed?
        if (Input.GetButtonDown("Jump"))
        { 
            isJumpPressed = true;
        }

        //space Atatck key pressed?
        if (Input.GetButtonDown("Fire1"))
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

        if (xAxis < 0 && !hurts && !Dead)
        {
            vel.x = -walkSpeed;
        }
        else if (xAxis > 0 && !hurts && !Dead)
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
    
    public IEnumerator TakeDamage(float damage)
	{
        hurts = true;
		currentHealth -= damage;
        ChangeAnimationState(PLAYER_HURT);
        healthBar.SetHealth(currentHealth);
        Physics2D.IgnoreLayerCollision(6,7,true);
        yield return new WaitForSeconds(.8f);
        Physics2D.IgnoreLayerCollision(6,7,false);
        hurts = false;

	}

    public void Heal(float healAmount){
        currentHealth += healAmount;
        healthBar.SetHealth(currentHealth);
    }


    public IEnumerator die(){
        Dead = true;
        yield return new WaitForSeconds(.1f);
        SceneManager.LoadScene("Lose");

    }

    void Flip(){
        movingRight = !movingRight;

        transform.Rotate(0f, 180f, 0f);
    }

}
