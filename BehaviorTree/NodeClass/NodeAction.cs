namespace BehaviorTree
{
    /// <summary>
    /// 行为节点(叶节点)
    /// </summary>
    public abstract class NodeAction : NodeRoot
    {
        public NodeAction() : base(NodeType.Action)
        {
        }
    }
}