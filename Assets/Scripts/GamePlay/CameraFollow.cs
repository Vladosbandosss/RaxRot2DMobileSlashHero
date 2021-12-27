using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   private Transform playerPos;

   [SerializeField] private float offsetX = 6f;

   private Vector3 temp;

   private void Awake()
   {
      //FindPlayerRef();
   }

   public void FindPlayerRef()
   {
      playerPos = GameObject.FindWithTag(TagManager.PLAYERTAG).transform;
   }


   private void LateUpdate()
   {
      FollowPlayer();
   }

   private void FollowPlayer()
   {
      if (!playerPos)
      {
         return;
      }

      temp = transform.position;
      temp.x = playerPos.position.x + offsetX;
      transform.position = temp;
   }
}
