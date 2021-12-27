using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
   [SerializeField] private bool deactivateGameObject;

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag(TagManager.PLAYERTAG))
      {
         
         other.GetComponent<PlayerHealth>().SubtractHealth();
         
         Debug.Log("атакую игрока");
         if (deactivateGameObject)
         {
            gameObject.SetActive(false);
         }
      }

      if (other.CompareTag(TagManager.ENEMYTAG)||
          other.CompareTag(TagManager.OBSTACLETAG))
      {
        other.GetComponent<EnemyHealth>().TakeDamage();
      }
      
   }
}
