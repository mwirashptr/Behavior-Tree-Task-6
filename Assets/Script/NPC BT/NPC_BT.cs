using BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_BT : BehaviorTree.Tree
{
    public static float speed = 1.0f;
    public static float fovRange = 5.0f;
    public static float attackRange = 1f;

    protected override Node SetupTree() // Detect first, Idle last
    {
        Node root = new Selector(new List<Node>
        {
            //First Child
            new Sequence(new List<Node>
            {
                new CheckPlayerInAttackRange(transform),
                new Attack(transform)
            }),

            //Second Child
            new Sequence(new List<Node>
            {
                new CheckPlayerInChaseRange(transform),
                new Chase(transform)
            }),

            //Third Child
            new Idle(transform)
        });
        return root;
    }
}