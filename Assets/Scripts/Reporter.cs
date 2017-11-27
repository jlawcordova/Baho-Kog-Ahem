using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reporter : MonoBehaviour 
{

	#region Player Movements
	public float Speed;
	public float JumpSpeed;
	#endregion
	#region Interacting Layers
	public LayerMask GroundLayer;
	public LayerMask HitLayer;
	#endregion

	private BoxCollider2D boxCollider;
	private SpriteRenderer spriteRenderer;
	private Animator animator;

	// Use this for initialization
	void Start () {
		boxCollider = gameObject.GetComponent<BoxCollider2D>();
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(IsHit())
		{
			animator.SetTrigger("IsHit");
			GameOver();
			
			return;
		}

		if(IsGrounded())
		{
			if(Input.GetAxisRaw("Horizontal") == 0)
			{
				animator.SetTrigger("IsIdle");
			}else
			{
				animator.SetTrigger("IsWalking");			
			}

			if(Input.GetButton("Jump"))
			{
				Jump();
			}
		}
		else
		{
			animator.SetTrigger("IsJumping");
		}
		

		

		

		if(Input.GetAxisRaw("Horizontal") > 0 && !spriteRenderer.flipX)
		{
			spriteRenderer.flipX = true;
		}

		if(Input.GetAxisRaw("Horizontal") < 0 && spriteRenderer.flipX)
		{
			spriteRenderer.flipX = false;
		}
		transform.Translate(Input.GetAxisRaw("Horizontal") * Speed * Time.deltaTime, 0, 0);
	}

	private void Jump()
	{
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, JumpSpeed, 0);
	}


	private bool IsGrounded()
	{
		RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.size, 0, Vector2.down, 0.1f, GroundLayer);

		return hit.collider != null ? true : false;	
	}

	private bool IsHit()
	{
		RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.size, 0, Vector2.down, 0f, HitLayer);

		return hit.collider != null ? true : false;	
	}

	private void GameOver()
	{
		// Time.timeScale = 0;
		SceneManager.LoadScene("Game");
	}
}
