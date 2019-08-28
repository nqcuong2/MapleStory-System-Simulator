using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[Header("Movement Values")]
	[SerializeField] float movingSpeed = 5f;
	[SerializeField] float climbingSpeed = 5f;
	[SerializeField] float jumpForce = 10f;

	[Header("Ground Check Info")]
	[SerializeField] Transform groundCheck;
	[SerializeField] float groundCheckRadius;
	[SerializeField] LayerMask groundMask;
	[SerializeField] bool grounded;


	[Header("Others")]
	[SerializeField] bool canClimb;
	[SerializeField] float changeDirectionOffset = 0.4f;
	[SerializeField] float raycastDistance = 5f;
	[SerializeField] LayerMask ladderMask;
	[SerializeField] Vector3 raycastOffset = new Vector3(-0.6f, -1.65f);

	private Player player;
	private Rigidbody2D rigidBody2D;
	private BoxCollider2D boxCollider2D;
	private Animator animator;
	private bool facingRight;

	private string isWalkingString = "isWalking";
	private string isClimbingString = "isClimbing";

	// Start is called before the first frame update
	void Start()
	{
		player = new Player("Player");
		animator = GetComponent<Animator>();
		rigidBody2D = GetComponent<Rigidbody2D>();
		boxCollider2D = GetComponent<BoxCollider2D>();
	}

    // Update is called once per frame
    void Update()
	{
		DoMovement();
	}

	void FixedUpdate()
	{
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundMask);
	}

	private void DoMovement()
	{
		Vector3 raycastPosition = transform.position + raycastOffset;
		RaycastHit2D hitLadderUp = Physics2D.Raycast(raycastPosition, Vector2.up, raycastDistance, ladderMask);
		RaycastHit2D hitLadderDown = Physics2D.Raycast(raycastPosition, Vector2.down, raycastDistance, ladderMask);

		if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)))
		{
			if (!animator.GetBool(isClimbingString))
			{
				animator.SetBool(isWalkingString, true);
				Walk();
			}
			else
			{
				animator.SetBool(isWalkingString, false);
				Jump();
			}
		}
		else
		{
			animator.SetBool(isWalkingString, false);
		}

		if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.Space))
		{
			StartCoroutine(JumpDown());
		}
		else if (Input.GetKey(KeyCode.Space) && grounded)
		{
			animator.SetBool(isWalkingString, false);
			Jump();
		}

		if ((Input.GetKey(KeyCode.UpArrow) || (Input.GetKey(KeyCode.DownArrow) && !grounded)) && canClimb ||
			hitLadderDown.collider != null && Input.GetKey(KeyCode.DownArrow))
		{
			animator.SetBool(isClimbingString, true);
			rigidBody2D.bodyType = RigidbodyType2D.Kinematic;
			Climb();
		}
		else if (hitLadderDown.collider == null && grounded)
		{
			rigidBody2D.bodyType = RigidbodyType2D.Dynamic;
			animator.SetBool(isClimbingString, false);
		}

		if (!canClimb)
		{
			animator.SetBool(isClimbingString, false);
		}

		//Debug.Log(grounded);
	}

	private void Walk()
	{
		float horizontal = Input.GetAxisRaw("Horizontal");
		if ((horizontal > 0 && !facingRight) || (horizontal < 0 && facingRight))
		{
			ChangeDirection();
		}

		Vector3 movingDistance = new Vector3(horizontal * movingSpeed * Time.deltaTime, 0);
		transform.Translate(movingDistance);
	}

	private void Climb()
	{
		float vertical = Input.GetAxisRaw("Vertical");
		Vector3 climbingDistance = new Vector3(0, vertical * climbingSpeed * Time.deltaTime);
		transform.Translate(climbingDistance);

	}

	private void Jump()
	{
		rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, jumpForce);
	}

	private void ChangeDirection()
	{
		facingRight = !facingRight;
		transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y);
		transform.localPosition += new Vector3(changeDirectionOffset * transform.localScale.x, 0);
		raycastOffset.x *= -1;
	}

	private IEnumerator JumpDown()
	{
		boxCollider2D.isTrigger = true;
		yield return new WaitForSeconds(0.5f);
		boxCollider2D.isTrigger = false;
	}

	public void SetCanClimb(bool canClimb)
	{
		this.canClimb = canClimb;
	}
}
