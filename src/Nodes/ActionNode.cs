using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentBehaviourTree
{
    /// <summary>
    /// A behaviour tree leaf node for running an action.
    /// </summary>
    public class ActionNode : IBehaviourTreeNode
    {
        /// <summary>
        /// The name of the node.
        /// </summary>
        private string name;

        /// <summary>
        /// Function to invoke for the action.
        /// </summary>
        private Func<TreeData, BehaviourTreeStatus> fn;
        

        public ActionNode(string name, Func<TreeData, BehaviourTreeStatus> fn)
        {
            this.name=name;
            this.fn=fn;
        }

        public virtual BehaviourTreeStatus Tick(TreeData data)
        {
            return fn(data);
        }
    }
}
