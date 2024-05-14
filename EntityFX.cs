using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFX : MonoBehaviour
{
    private SpriteRenderer SR;
        
    [Header("Flash FX")] 
    [SerializeField] private float Duration;
    [SerializeField] private Material HitMaterial;
    private Material OringinalMaterial;

    private void Start()
    {
        SR = GetComponentInChildren<SpriteRenderer>();
        OringinalMaterial = SR.material;
    }

    private IEnumerator FlashFX()
    {
        SR.material = HitMaterial;
        yield return new WaitForSeconds(Duration);
        SR.material = OringinalMaterial;
        
    }

    private void RedColorBlink()
    {
        if (SR.color != Color.white)
            SR.color = Color.white;
        else
            SR.color = Color.white;
    }

    private void CancelRedColorBlink()
    {
        CancelInvoke();
        SR.color = Color.white;
    }
}
