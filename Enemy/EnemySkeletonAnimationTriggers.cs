using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySkeletonAnimationTriggers : MonoBehaviour
{
   private EnemySkeleton Enemy => GetComponentInParent<EnemySkeleton>();

   private void AnimationTriggers()
   {
      Enemy.AnimationFinishTrigger();
   }

   private void AttackTrigger()
   {
      Collider2D[] Colliders = Physics2D.OverlapCircleAll(Enemy.AttackCheck.position, Enemy.AttackCheckRadius);
      
      foreach(var hit in Colliders)
      {
         if(hit.GetComponent<Player>() != null)
         {
            hit.GetComponent<Player>().Damage();
         }
      }
   }
   
   private void OpenCounterAttackWindow() => Enemy.OpenCounterAttackWindow();
   private void CloseCounterAttackWindow() => Enemy.CloseCounterAttackWindow();
   
}
