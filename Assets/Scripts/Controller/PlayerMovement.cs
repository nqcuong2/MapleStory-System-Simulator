using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	#region Serialize Fields
	[Header("Movement Values")]
	[SerializeField] float movingSpeed = 5f;
	[SerializeField] float climbingSpeed = 5f;
	[SerializeField] float jumpForce = 10f;
	[SerializeField] float jumpAsideForceX = 4f;
	[SerializeField] float jumpAsideForceY = 7f;

	[Header("Ground Check Info")]
	[SerializeField] LayerMask groundMask;
	[SerializeField] bool grounded;


	[Header("Others")]
	[SerializeField] bool canClimb;
	// [SerializeField] float changeDirectionOffset = 0.4f;
	[SerializeField] float raycastDistance = 5f;
	[SerializeField] LayerMask ladderMask;
	[SerializeField] Vector3 raycastOffset = new Vector3(-0.6f, -1.65f);
	#endregion

	#region Class Fields
	private Player player;
	private Rigidbody2D rigidBody2D;
	private BoxCollider2D playerCollider;
	private Animator animator;
	private bool facingRight;

	private bool isWalking;
	private bool isClimbing;
	private RaycastHit2D hitLadderUp;
	private RaycastHit2D hitLadderDown;
	private bool isInLadderArea;

	private const string IS_WALKING_STRING = "isWalking";
	private const string IS_CLIMBING_STRING = "isClimbing";
	#endregion

	#region Script Cycle
	// Start is called before the first frame update
	void Start()
	{
		player = new Player("Player");
		animator = GetComponent<Animator>();
		rigidBody2D = GetComponent<Rigidbody2D>();
		playerCollider = GetComponent<BoxCollider2D>();
	}

    // Update is called once per frame
    void Update()
	{
		DoMovement();
	}
	#endregion

	#region Methods
	private void DoMovement()
	{
		RaycastHit2D hitGround = Physics2D.BoxCast
		(
			playerCollider.bounds.center,
			playerCollider.bounds.size,
			0f,
			Vector2.down,
			PlayerConstants.GroundBoxCastDistance,
			groundMask
		);
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

		if (IsClimbable())
		{
			MovePlayerPosToMiddleOfLadder();
			AdjustRigidBodyToClimb();
			Climb();
		}
		else if (IsGroundedWhileClimbing() || !isInLadderArea)
		{
			CancelClimb();
		}
	}

	private bool IsClimbable() 
	{
		hitLadderUp = Physics2D.Raycast
		(
			playerCollider.bounds.center,
			Vector2.up,
			playerCollider.bounds.size.y / 2,
			ladderMask
		);
		hitLadderDown = Physics2D.Raycast
		(
			playerCollider.bounds.center,
			Vector2.down,
			playerCollider.bounds.size.y / 2 + PlayerConstants.LadderDownRaycastDistanceOffset,
			ladderMask
		);
		if (CanClimbInLadderArea() || CanClimbFromTopOfLadder())
		{
			return true;
		}
		
		return false;
	}

	private bool CanClimbInLadderArea()
	{
		if (Input.GetKey(KeyCode.UpArrow) || (Input.GetKey(KeyCode.DownArrow) && !grounded))
		{
			if (isInLadderArea && (hitLadderUp.collider != null || hitLadderDown.collider != null))
			{
				return true;
			}
		}

		return false;
	}

	private  bool CanClimbFromTopOfLadder() {
		return Input.GetKey(KeyCode.DownArrow) && hitLadderDown.collider != null;
	}

	private void MovePlayerPosToMiddleOfLadder()
	{
		Vector2 playerPosPriorClimbing = transform.position;
		if (hitLadderUp.collider != null)
		{
			playerPosPriorClimbing = new Vector2(hitLadderUp.collider.bounds.center.x, playerPosPriorClimbing.y);
		}
		else if (hitLadderDown.collider != null)
		{
			playerPosPriorClimbing = new Vector2(hitLadderDown.collider.bounds.center.x, playerPosPriorClimbing.y);
		}

		transform.position = playerPosPriorClimbing;
	}

	private void AdjustRigidBodyToClimb()
	{
		rigidBody2D.velocity = Vector2.zero;
		rigidBody2D.bodyType = RigidbodyType2D.Kinematic;
	}

	private void Climb()
	{
		isClimbing = true;
		//animator.SetBool(IS_CLIMBING_STRING, isClimbing);

		float vertical = Input.GetAxisRaw("Vertical");
		Vector3 climbingDistance = new Vector3(0, vertical * climbingSpeed * Time.deltaTime);
		transform.Translate(climbingDistance);
	}

	private bool IsGroundedWhileClimbing() {
		return isClimbing && hitLadderDown.collider == null && grounded;
	}

	private void Walk()
	{
		isWalking = true;
		//animator.SetBool(IS_WALKING_STRING, isWalking);

		float horizontal = Input.GetAxisRaw("Horizontal");
		if ((horizontal > 0 && !facingRight) || (horizontal < 0 && facingRight))
		{
			ChangeDirection();
		}

		Vector3 movingDistance = new Vector3(horizontal * movingSpeed * Time.deltaTime, 0);
		transform.Translate(movingDistance);
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
		raycastOffset.x *= -1;
	}

	private void CancelWalk()
	{
		isWalking = false;
		//animator.SetBool(IS_WALKING_STRING, isWalking);
	}

	private void CancelClimb()
	{
		isClimbing = false;
		//animator.SetBool(IS_CLIMBING_STRING, isClimbing);
		rigidBody2D.bodyType = RigidbodyType2D.Dynamic;
	}

	private IEnumerator JumpDown()
	{
		playerCollider.isTrigger = true;
		yield return new WaitForSeconds(0.5f);
		playerCollider.isTrigger = false;
	}

	public void SetCanClimb(bool canClimb)
	{
		this.canClimb = canClimb;
	}

	private void OnTriggerEnter2D(Collider2D otherCollider)
	{
		if (otherCollider.tag == "Ladder")
		{
			isInLadderArea = true;
		}
	}

	private void OnTriggerExit2D(Collider2D otherCollider)
	{
		if (otherCollider.tag == "Ladder")
		{
			isInLadderArea = false;
		}
	}
	#endregion
}
