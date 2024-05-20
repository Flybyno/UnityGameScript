using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager Instance;
    public DashSkill Dash { get;private set; }

    private void Awake()
    {
        if(Instance != null)
            Destroy(Instance.gameObject);
        else
            Instance = this;
    }

    private void Start()
    {
        Dash = GetComponent<DashSkill>();
    }
}
