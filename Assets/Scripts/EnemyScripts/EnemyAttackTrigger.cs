using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
   private EnemyAnimation _enemyAnim;

   private void Awake()
   {
      _enemyAnim = GetComponentInParent<EnemyAnimation>();
   }

   private void OnTriggerStay2D(Collider2D other)
   {
      if (other.CompareTag(TagManager.PLAYERTAG))
      {
         _enemyAnim.PlayAttack();
         SoundManager.instance.EnemyAttackSound();
      }
   }
}
