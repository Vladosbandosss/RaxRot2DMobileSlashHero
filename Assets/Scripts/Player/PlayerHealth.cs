using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   [SerializeField] private GameObject[] healthBars;

   private int currentHealthBarIndex;

   private int health;

   private void Awake()
   {
      healthBars = GameObject.FindWithTag(TagManager.HEALTHBARHOLDER).GetComponent<HealthBarHolder>().healthBars;
   }

   private void Start()
   {
      health = healthBars.Length;
      currentHealthBarIndex = health - 1;
   }

   public void SubtractHealth()
   {
      SoundManager.instance.ObstacleDestroySound();
      healthBars[currentHealthBarIndex].SetActive(false);
      currentHealthBarIndex--;
      health--;

      if (health <= 0)
      {
        
         
         GameObject.FindWithTag(TagManager.GAMEPLAYCONTROLLERTAG)
            .GetComponent<GameOverController>().GameOverShowPanel();
         
         Destroy(gameObject);
         
      }
   }

  private void AddHealth()
   {
      SoundManager.instance.CollectableSound();
      if (health == healthBars.Length)
      {
         return;
      }

      health++;
      
      currentHealthBarIndex = health - 1;
      healthBars[currentHealthBarIndex].SetActive(true);
      
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      
      if (other.CompareTag(TagManager.HEALTHTAG))
      {
        
         AddHealth();
         
         Destroy(other.gameObject);
         
      }
   }
}
