using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimationTriggers : MonoBehaviour
{
    private Player Player01 => GetComponentInParent<Player>();

    private void AnimationTrigger()
    {
        Player01.AnimationTrigger();
    }

    private void AttackTrigger()
    {
        Collider2D[] Colliders = Physics2D.OverlapCircleAll(Player01.AttackCheck.position, Player01.AttackCheckRadius);
        foreach (var hit in Colliders)
        {
            if (hit.GetComponent<Enemy>() != null)
                hit.GetComponent<Enemy>().Damage();
        }
    }
}
