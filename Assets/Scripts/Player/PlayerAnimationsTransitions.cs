using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationsTransitions : MonoBehaviour
{
   private Animator _anim;

   [SerializeField] private GameObject damageCollider;
   private void Awake()
   {
      _anim = GetComponent<Animator>();
   }

   public void PlayFromJumpToRunning(bool running)
   {
      _anim.SetBool(TagManager.RUNNINGANIMATIONPARAMETR,running);
   }

   public void PlayJump(float velY)
   {
      _anim.SetFloat(TagManager.JUMPANIMATIONPARAMETR,velY);
   }

   public void PlayDoubleJump()
   {
      _anim.SetTrigger(TagManager.DOUBLEJUMPANIMATIONPARAMETR);
   }

   public void PlayAttack()
   {
      _anim.SetTrigger(TagManager.ATTACKANIMATIONPARAMETR);
   }

   public void PlayJumpAttack()
   {
      _anim.SetTrigger(TagManager.JUMPATTACKANIMATIONPARAMETR);
   }

   void ActivateDamageDetector()
   {
      damageCollider.SetActive(true);
   }

   void DeactivateDamageCollider()
   {
      damageCollider.SetActive(false);
   }
}
