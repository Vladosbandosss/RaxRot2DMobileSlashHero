using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuCharachter : MonoBehaviour
{
   [SerializeField] private Sprite[] animSprites;

   [SerializeField]private float timeTreshold = 0.1f;

   private float timer;

   private int state;

   private Image img;

   private void Awake()
   {
      img = GetComponent<Image>();
   }

   private void Update()
   {
      if (Time.time > timer)
      {
         img.sprite = animSprites[state];
         state++;
         
         if (state == animSprites.Length)
         {
            state = 0;
         }
         
         timer = Time.time + timeTreshold;
         
      }
   }
}
