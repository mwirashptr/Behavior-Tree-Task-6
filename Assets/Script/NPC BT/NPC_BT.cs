using BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_BT : BehaviorTree.Tree
{
    protected override Node SetupTree() // Detect first, Idle last
    {
        Node root = new Selector(new List<Node>
        {
            //First Child
            new Sequence(new List<Node>
            {
                //First Child
                new CheckPlayerInChaseRange(),
                //Second Child
                new Chase()
            }),
            //Second Child
            new Idle()
        });
        return root;
    }
}