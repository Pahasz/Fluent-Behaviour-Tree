using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentBehaviourTree
{
    /// <summary>
    /// Runs child nodes in sequence, until one fails.
    /// </summary>
    public class SequenceNode : IParentBehaviourTreeNode
    {
        /// <summary>
        /// Name of the node.
        /// </summary>
        private string name;

        /// <summary>
        /// List of child nodes.
        /// </summary>
        private List<IBehaviourTreeNode> children = new List<IBehaviourTreeNode>(); //todo: this could be optimized as a baked array.
        
        private int currNodeIndex = 0;

        public SequenceNode(string name)
        {
            this.name = name;
        }

        public BehaviourTreeStatus Tick(TreeData data)
        {
            if(currNodeIndex < children.Count){
                var childStatus = children[currNodeIndex].Tick(data);
                if (childStatus != BehaviourTreeStatus.Success)
                {
                    return childStatus;
                }else if(childStatus == BehaviourTreeStatus.Success){
                    currNodeIndex++;
                    return childStatus;
                }
            }

            return BehaviourTreeStatus.Success;
        }

        /// <summary>
        /// Add a child to the sequence.
        /// </summary>
        public void AddChild(IBehaviourTreeNode child)
        {
            children.Add(child);
        }
    }
}
