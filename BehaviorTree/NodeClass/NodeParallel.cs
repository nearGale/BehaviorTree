namespace BehaviorTree
{
    /// <summary>
    /// 并行节点(组合节点)
    /// </summary>
    public class NodeParallel : NodeRoot
    {
        public NodeParallel():base(NodeType.Parallel)
        { }

        /// <summary>
        /// 并行节点同时执行所有节点，直到一个节点返回 Fail 或者全部节点都返回 Success
        /// 才向父节点返回 Fail 或者 Success，并终止执行其他节点
        /// 其他情况向父节点返回 Running
        /// </summary>
        /// <returns></returns>
        public override ResultType Execute()
        {
            ResultType resultType = ResultType.Fail;

            int successCount = 0;
            for (int i = 0; i < nodeChildList.Count; ++i)
            {
                NodeRoot nodeRoot = nodeChildList[i];
                resultType = nodeRoot.Run();

                if (resultType == ResultType.Fail)
                {
                    break;
                }

                if (resultType == ResultType.Success)
                {
                    ++successCount;
                    continue;
                }

                if (resultType == ResultType.Running)
                {
                    continue;
                }
            }

            if (resultType != ResultType.Fail)
            {
                resultType = (successCount >= nodeChildList.Count) ? ResultType.Success : ResultType.Running;
            }

            return resultType;
        }
    }
}