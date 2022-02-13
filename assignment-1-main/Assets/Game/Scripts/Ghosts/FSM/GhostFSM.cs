using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GhostController), typeof(Animator))]
public class GhostFSM : FSM
{
    [HideInInspector] public Animator _animator;
    [HideInInspector] public GhostController ghost;

    protected override void Awake()
    {
        ghost = GetComponent<GhostController>();
        _animator = ghost.gameObject.GetComponent<Animator>();
        base.Awake();
    }
}
