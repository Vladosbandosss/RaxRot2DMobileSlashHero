using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
   [SerializeField] private float moveSpeed = 7f, jumpForce = 20f;

   private Rigidbody2D rb;

   private Transform groundCheckPos;

   [SerializeField] private LayerMask groundLayer;

   private bool canDoubleJump;

   private float radiusGroundCheck = 0.1f;

   private PlayerAnimationsTransitions _playerAnim;

  [SerializeField] private float attackWaitTime = 0.5f;

   private float attackTimer;
   private bool canAttack;
   private void Awake()
   {
      rb = GetComponent<Rigidbody2D>();
      _playerAnim = GetComponent<PlayerAnimationsTransitions>();
      
      groundCheckPos = transform.GetChild(0).transform;
   }

   private void Update()
   {
      AnimatePlayer();
      
      if (Input.GetMouseButtonDown(0))
      {
         if (Input.mousePosition.x < Screen.width / 2)
         {
            JumpButton();
         }
         else
         {
            AttackButton();
         }
      }
   }

   private void FixedUpdate()
   {
      MovePlayer();
   }
   
   public void JumpButton()
   {
     
      if (!IsGrounded()&&canDoubleJump)
      {
         SoundManager.instance.PlayJumpSound();
         canDoubleJump = false;
         rb.velocity=Vector2.zero;
         rb.AddForce(new Vector2(0f,jumpForce),ForceMode2D.Impulse);
         
         _playerAnim.PlayDoubleJump();
         
      }
      if (IsGrounded())
      { SoundManager.instance.PlayJumpSound();
         canDoubleJump = true;
         rb.AddForce(new Vector2(0f,jumpForce),ForceMode2D.Impulse);
      }
   }

   private void MovePlayer()
   {
      rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
   }

   private bool IsGrounded()
   {
      return Physics2D.OverlapCircle(groundCheckPos.position, radiusGroundCheck, groundLayer);
   }


  private void AnimatePlayer()
   {
      _playerAnim.PlayJump(rb.velocity.y);
      _playerAnim.PlayFromJumpToRunning(IsGrounded());
   }
  
  public void AttackButton()
  {
     if (Time.time > attackTimer)
     {
        attackTimer = Time.time + attackWaitTime;
        canAttack = true;
        
        SoundManager.instance.PlayAttackSound();
        
        if (canAttack && IsGrounded())
        {
           canAttack = false;
           _playerAnim.PlayAttack();
        }else if (canAttack && !IsGrounded())
        {
           _playerAnim.PlayJumpAttack();
        }
     }
  }
  
}//class
