using System;
using System.Collections;
using System.Collections.Generic;

namespace BehaviorTree
{
    /// <summary>
    /// 行为树节点类型
    /// </summary>
    public enum NodeType
    {
        /// <summary>
        /// 选择节点
        /// </summary>
        Select = 0,

        /// <summary>
        /// 顺序节点
        /// </summary>
        Sequence = 1,

        /// <summary>
        /// 修饰节点
        /// </summary>
        Decorator = 2,

        /// <summary>
        /// 随机节点
        /// </summary>
        Random = 3,

        /// <summary>
        /// 并行节点
        /// </summary>
        Parallel = 4,

        /// <summary>
        /// 条件节点
        /// </summary>
        Condition = 5,

        /// <summary>
        /// 行为节点
        /// </summary>
        Action = 6,
    }

    /// <summary>
    /// 节点执行结果
    /// </summary>
    public enum ResultType
    {
        /// <summary>
        /// 失败
        /// </summary>
        Fail = 0,

        /// <summary>
        /// 成功
        /// </summary>
        Success = 1,

        /// <summary>
        /// 执行中
        /// </summary>
        Running = 2,
    }

    public static class Nodes{
        public static Dictionary<string, string> nodesDict = new Dictionary<string, string> {
                {"Act做饭", "BehaviorTree.ActionNode_Cooking"},
                {"Act吃饭", "BehaviorTree.ActionNode_Eat"},
                {"Act移动", "BehaviorTree.ActionNode_Move"},
                {"Condi是否有饭", "BehaviorTree.ConditionNode_HasFood"},
                {"Condi是否饿了", "BehaviorTree.ConditionNode_IsHungry"},
            };
        
        public static Dictionary<NodeType, string> str = new Dictionary<NodeType, string>{
            {NodeType.Action, "BehaviorTree.NodeAction"},
            {NodeType.Condition, "BehaviorTree.NodeCondition"},
            {NodeType.Decorator, "BehaviorTree.NodeDecorator"},
            {NodeType.Parallel, "BehaviorTree.NodeParallel"},
            {NodeType.Random, "BehaviorTree.NodeRandom"},
            {NodeType.Select, "BehaviorTree.NodeSelect"},
            {NodeType.Sequence, "BehaviorTree.NodeSequence"},
        };
        public static string BTree_Root_Str = "选择的树根";
    }
}
