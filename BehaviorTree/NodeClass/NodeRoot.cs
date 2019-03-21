using System;
using System.Collections.Generic;

namespace BehaviorTree
{
    /// <summary>
    /// 节点超类
    /// </summary>
    public abstract class NodeRoot
    {
        /// <summary>
        /// 节点类型
        /// </summary>
        protected NodeType nodeType;
        /// <summary>
        /// 节点序列
        /// </summary>
        private int nodeIndex;
        /// <summary>
        /// 角色ID
        /// </summary>
        private int roleId;
        /// <summary>
        /// 节点名称
        /// </summary>
        private string name;

        public NodeRoot(NodeType nodeType)
        {
            this.nodeType = nodeType;
        }

        /// <summary>
        /// 执行节点抽象方法
        /// </summary>
        /// <returns>返回执行结果</returns>
        public abstract ResultType Execute();

        public ResultType Run(){
            if(this.name.Equals(Nodes.BTree_Root_Str)){
                Console.WriteLine();
                Console.Write(name);
            }
            else
                Console.Write(" - " + this.name);
            return Execute();
        }

        public int NodeIndex
        {
            get { return nodeIndex; }
            set { nodeIndex = value; }
        }
        public int RoleId
        {
            get { return roleId; }
            set { roleId = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        // 保存子节点
        protected List<NodeRoot> nodeChildList = new List<NodeRoot>();

        // 添加子节点
        public void AddChild(NodeRoot nodeRoot)
        {
            int count = nodeChildList.Count;
            nodeRoot.NodeIndex = count;
            nodeChildList.Add(nodeRoot);
        }
    }
}