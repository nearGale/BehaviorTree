namespace BehaviorTree
{
    /// <summary>
    /// 条件节点(叶节点)
    /// </summary>
    public abstract class NodeCondition : NodeRoot
    {
        public NodeCondition() : base(NodeType.Condition)
        {
        }
    }
}