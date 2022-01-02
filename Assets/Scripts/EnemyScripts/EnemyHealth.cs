using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

   public void TakeDamage()
   {
       if (gameObject.CompareTag(TagManager.ENEMYTAG))
       {
          SoundManager.instance.EnemyDeadSound();
       }
       
       else
       {
           SoundManager.instance.ObstacleDestroySound();
       }
       
       Destroy(gameObject);
   }
}
