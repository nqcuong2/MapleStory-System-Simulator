using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[Header("Movement Values")]
	[SerializeField] float movingSpeed = 5f;
	[SerializeField] float climbingSpeed = 5f;
	[SerializeField] float jumpForce = 10f;
	[SerializeField] float jumpAsideForceX = 4f;
	[SerializeField] float jumpAsideForceY = 7f;

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

	private bool isWalking;
	private bool isClimbing;

	private const string IS_WALKING_STRING = "isWalking";
	private const string IS_CLIMBING_STRING = "isClimbing";

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

	private void DoMovement()
	{
		Vector3 raycastPosition = transform.position + raycastOffset;
		RaycastHit2D hitLadderDown = Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, raycastDistance, ladderMask);
		float extraHeight = 1f;
		RaycastHit2D hitGround = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, extraHeight, groundMask);
		grounded = hitGround.collider != null;

		if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)))
		{
			if (!isClimbing)
			{
				Walk();
			}
			else 
			{
				if (Input.GetKey(KeyCode.Space))
				{
					JumpAside();
				}
			}
		}
		else
		{
			CancelWalk();
		}

		if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.Space))
		{
			StartCoroutine(JumpDown());
		}
		else if (Input.GetKey(KeyCode.Space) && grounded)
		{
			Jump();
		}

		if ((Input.GetKey(KeyCode.UpArrow) || (Input.GetKey(KeyCode.DownArrow) && !grounded)) && canClimb ||
			hitLadderDown.collider != null && Input.GetKey(KeyCode.DownArrow))
		{
			canClimb = true; //for the case climb down, not set this to true will cause RigidbodyType2D become Dynamic
			Climb();
		}
		else if (isClimbing && hitLadderDown.collider == null && grounded || !canClimb)
		{
			CancelClimb();
		}
	}

	private void Walk()
	{
		isWalking = true;
		animator.SetBool(IS_WALKING_STRING, isWalking);

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
		isClimbing = true;
		animator.SetBool(IS_CLIMBING_STRING, isClimbing);
		rigidBody2D.bodyType = RigidbodyType2D.Kinematic;

		float vertical = Input.GetAxisRaw("Vertical");
		Vector3 climbingDistance = new Vector3(0, vertical * climbingSpeed * Time.deltaTime);
		transform.Translate(climbingDistance);
	}

	private void Jump()
	{
		if (isWalking)
		{
			CancelWalk();
		}

		rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, jumpForce);
	}

	private void JumpAside()
	{
		CancelClimb();

		float horizontal = Input.GetAxisRaw("Horizontal");
		rigidBody2D.velocity = horizontal > 0 ? new Vector2(jumpAsideForceX, jumpAsideForceY) : new Vector2(-jumpAsideForceX, jumpAsideForceY);
	}

	private void ChangeDirection()
	{
		facingRight = !facingRight;
		transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y);
		transform.localPosition += new Vector3(changeDirectionOffset * transform.localScale.x, 0);
		raycastOffset.x *= -1;
	}

	private void CancelWalk()
	{
		isWalking = false;
		animator.SetBool(IS_WALKING_STRING, isWalking);
	}

	private void CancelClimb()
	{
		isClimbing = false;
		animator.SetBool(IS_CLIMBING_STRING, isClimbing);
		rigidBody2D.bodyType = RigidbodyType2D.Dynamic;
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
