using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentBehaviourTree
{
    /// <summary>
    /// Decorator node that inverts the success/failure of its child.
    /// </summary>
    public class AlwaysTrueNode : IParentBehaviourTreeNode
    {
        /// <summary>
        /// Name of the node.
        /// </summary>
        private string name;

        /// <summary>
        /// The child to be inverted.
        /// </summary>
        private IBehaviourTreeNode childNode;

        public AlwaysTrueNode(string name)
        {
            this.name = name;
        }

        public BehaviourTreeStatus Tick(TreeData data)
        {
            if (childNode == null)
            {
                throw new ApplicationException("InverterNode must have a child node!");
            }

            var result = childNode.Tick(data);
            if (result == BehaviourTreeStatus.Failure)
            {
                return BehaviourTreeStatus.Success;
            }
            else if (result == BehaviourTreeStatus.Success)
            {
                return BehaviourTreeStatus.Success;
            }
            else
            {
                return result;
            }
        }

        /// <summary>
        /// Add a child to the parent node.
        /// </summary>
        public void AddChild(IBehaviourTreeNode child)
        {
            if (this.childNode != null)
            {
                throw new ApplicationException("Can't add more than a single child to InverterNode!");
            }

            this.childNode = child;
        }
    }
}
