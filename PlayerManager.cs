using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
   public static PlayerManager Instance;
   // Named itself Instance.
   public Player Player;
   // Initialize a Player and now this Player is in the PlayerManager which called Instance.

   private void Awake()
   {
      if(Instance != null)
         Destroy(Instance.gameObject);
      else
         Instance = this;
      // give itself to Instance.
   }
}
