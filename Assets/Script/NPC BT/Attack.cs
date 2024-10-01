using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class Attack : Node
{
    private Animator _animator;

    private Transform _lastTarget;
    private PlayerManager _playerManager;

    public Attack(Transform transform)
    {
        _animator = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");
        if (target != _lastTarget)
        {
            _playerManager = target.GetComponent<PlayerManager>();
            _lastTarget = target;
        }

        bool enemyIsDead = _playerManager.TakeHit();
        if (enemyIsDead)
        {
            ClearData("target");
            _animator.SetBool("isAttacking", false);
            _animator.SetBool("isWalking", true);
        }

        state = NodeState.RUNNING;
        Debug.Log("Attack Done");
        return state;
    }
}