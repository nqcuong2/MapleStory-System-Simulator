using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[Header("Movement Values")]
	[SerializeField] float movingSpeed = 5f;
	[SerializeField] float climbingSpeed = 5f;
	[SerializeField] float jumpForce = 5f;

	[Header("Others")]
	[SerializeField] float changeDirectionOffset = 0.4f;
	[SerializeField] float raycastDistance = 5f;
	[SerializeField] LayerMask ladderMask;
	[SerializeField] LayerMask groundMask;
	[SerializeField] Vector3 raycastOffset = new Vector3(-0.6f, -1.65f);

	private Player player;
	private Animator animator;
	private bool facingRight;
	private bool canClimb;

	private string isWalkingString = "isWalking";
	private string isClimbingString = "isClimbing";

	// Start is called before the first frame update
	void Start()
	{
		player = new Player("Player");
		animator = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
	{
		DoMovement();
	}

	private void DoMovement()
	{
		Vector3 raycastPosition = transform.position + raycastOffset;
		RaycastHit2D hitLadderUp = Physics2D.Raycast(raycastPosition, Vector2.up, raycastDistance, ladderMask);
		RaycastHit2D hitLadderDown = Physics2D.Raycast(raycastPosition, Vector2.down, raycastDistance, ladderMask);
		RaycastHit2D hitGround = Physics2D.Raycast(raycastPosition, Vector2.down, 0.5f, groundMask);
		bool grounded = GetComponent<BoxCollider2D>().IsTouchingLayers(groundMask.value);

		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
		{
			if (!animator.GetBool(isClimbingString))
			{
				animator.SetBool(isWalkingString, true);
				Walk();
			}
			else if (Input.GetKey(KeyCode.Space))
			{
				animator.SetBool(isWalkingString, false);
			}
		}
		else
		{
			animator.SetBool(isWalkingString, false);
		}

		if (hitLadderUp.collider != null)
		{
			if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
			{
				animator.SetBool(isClimbingString, true);
				Climb();
			}
		}
		else if (hitLadderDown.collider != null && Input.GetKey(KeyCode.DownArrow))
		{
			animator.SetBool(isClimbingString, true);
			Climb();
		}
		else if (grounded)
		{
			animator.SetBool(isClimbingString, false);
		}
		else
		{
			animator.SetBool(isClimbingString, false);
		}

		//if (hitGround.collider != null && animator.GetBool(isClimbingString))
		//{
		//	//GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
		//	animator.SetBool(isClimbingString, false);
		//}
		//bool grounded = GetComponent<BoxCollider2D>().IsTouchingLayers(groundMask.value);
		Debug.Log(grounded);
		//if (grounded)
		//{
		//	animator.SetBool(isClimbingString, false);
		//}

		if (animator.GetBool(isClimbingString))
		{
			GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
		}
		else
		{
			GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
		}
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
		Vector3 movingDistance = new Vector3(0, vertical * climbingSpeed * Time.deltaTime);
		transform.Translate(movingDistance);

	}

	private void Jump()
	{

	}

	private void ChangeDirection()
	{
		facingRight = !facingRight;
		transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y);
		transform.localPosition += new Vector3(changeDirectionOffset * transform.localScale.x, 0);
		raycastOffset.x *= -1;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("Collision");
	}

}
