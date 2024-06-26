using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
      [SerializeField]protected float Cooldown;
      protected float CooldownTimer;

      protected void Update()
      {
        CooldownTimer -= Time.deltaTime;
      }

      public virtual bool CanUseSkill()
      {
        if (CooldownTimer < 0)
        {
            UseSkill();
            CooldownTimer = 0;
            return true;
        }
        return false;
      }

      public virtual void UseSkill()
      {
          
      }
      
}
