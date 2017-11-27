using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

	public GameObject EndPanel;
	public GameObject[] HideEnd;

	private BoxCollider2D boxCollider;
	private SpriteRenderer spriteRenderer;
	private Animator animator;

	// Use this for initialization
	void Start () {
		EndPanel.transform.GetChild(6).gameObject.SetActive(false);
		
		Time.timeScale = 1;

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
			// Input.GetAxisRaw("Horizontal") == 0
			if(LeftButton.IsDown || RightButton.IsDown)
			{
				animator.SetTrigger("IsWalking");			
				
			}else
			{
				animator.SetTrigger("IsIdle");
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

		// Input.GetAxisRaw("Horizontal") > 0
		if(LeftButton.IsDown)
		{
			// spriteRenderer.flipX = true;
			WalkLeft();
		}
		//Input.GetAxisRaw("Horizontal") < 0 && spriteRenderer.flipX
		if(RightButton.IsDown)
		{
			// spriteRenderer.flipX = false;
			WalkRight();
		}
		// transform.Translate(Input.GetAxisRaw("Horizontal") * Speed * Time.deltaTime, 0, 0);
	}

	public void WalkRight(){
		spriteRenderer.flipX = true;
		transform.Translate(Speed * Time.deltaTime, 0, 0);
	}

	public void WalkLeft(){
		spriteRenderer.flipX = false;
		transform.Translate(-Speed * Time.deltaTime, 0, 0);
	}

	private void Jump()
	{
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, JumpSpeed, 0);
	}

	public void PerformJump(){
		if(IsGrounded()){
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, JumpSpeed, 0);
		}
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

		Time.timeScale = 0;
		EndPanel.transform.GetChild(0).GetComponent<Text>().text = Scorer.Score.ToString();

		if(PlayerPrefs.GetInt("Hiscore") < Scorer.Score)
		{
			EndPanel.transform.GetChild(2).GetComponent<Text>().text = Scorer.Score.ToString();
			PlayerPrefs.SetInt("Hiscore", Scorer.Score);
			EndPanel.transform.GetChild(6).gameObject.SetActive(true);
		}
		else{
			EndPanel.transform.GetChild(2).GetComponent<Text>().text = PlayerPrefs.GetInt("Hiscore").ToString();
		}

		foreach (GameObject item in HideEnd)
		{
			item.SetActive(false);
		}

		LeftButton.IsDown = false;
		RightButton.IsDown = false;

		EndPanel.GetComponent<Animator>().SetTrigger("Enter");
	}
}
