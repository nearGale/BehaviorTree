namespace BehaviorTree
{
    /// <summary>
    /// 顺序节点(组合节点)
    /// </summary>
    public class NodeSequence : NodeRoot
    {
        private NodeRoot lastRunningNode;
        public NodeSequence():base(NodeType.Sequence)
        {  }

        /// <summary>
        /// 顺序节点一次执行子节点，只要节点返回Success，就继续执行后续节点，直到一个节点
        /// 返回 Fail 或者 Running，停止执行后续节点，向父节点返回 Fail 或者 Running，如果
        /// 所有节点都返回 Success，则向父节点返回 Success
        /// 和选择节点一样，如果一个节点返回 Running，则需要记录该节点，下次执行时直接从该
        /// 节点开始执行
        /// </summary>
        /// <returns></returns>
        public override ResultType Execute()
        {
            int index = 0;
            if (lastRunningNode != null)
            {
                index = lastRunningNode.NodeIndex;
            }
            lastRunningNode = null;

            ResultType resultType = ResultType.Fail;
            for (int i = index; i < nodeChildList.Count; ++i)
            {
                NodeRoot nodeRoot = nodeChildList[i];
                resultType = nodeRoot.Run();

                if (resultType == ResultType.Fail)
                {
                    break;
                }

                if (resultType == ResultType.Success)
                {
                    continue;
                }

                if (resultType == ResultType.Running)
                {
                    lastRunningNode = nodeRoot;
                    break;
                }
            }

            return resultType;
        }
    }
}