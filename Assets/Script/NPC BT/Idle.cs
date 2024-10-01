using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class Idle : Node
{
    private Transform _transform;
    private Animator _animator;

    public Idle(Transform transform)
    {
        _transform = transform;
        _animator = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        _animator.SetBool("isWalking", false);
        state = NodeState.RUNNING;
        Debug.Log("Idleee.........");
        return state;
    }
}