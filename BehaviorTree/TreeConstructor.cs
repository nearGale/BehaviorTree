using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace BehaviorTree{
    public class TreeConstructor{

        public static NodeRoot Init(int iId,
                            Dictionary<string, TupleList<NodeType, string, object>> nodesGeneratorDict,
                            Tuple<NodeType,string, object> nodeData=null, int layer = 0
                        ){
            NodeRoot oNode = null;
            NodeType type;
            string typeStr;
            string nodeName;
            if(nodeData == null)
            {
                // 生成根节点
                type = NodeType.Select;
                nodeName = Nodes.BTree_Root_Str;
                typeStr = Nodes.str[NodeType.Select];
            }
            else
            {
                type = nodeData.Item1;
                nodeName = nodeData.Item2;
                if(type == NodeType.Select){
                    typeStr = Nodes.str[NodeType.Select];
                }
                else if (type==NodeType.Sequence)
                    typeStr = Nodes.str[NodeType.Sequence];
                else
                    typeStr = Nodes.nodesDict[nodeName];
            }
            // Console.WriteLine("typeStr: " + typeStr);
            Assembly assembly = Assembly.GetExecutingAssembly();
            object obj = assembly.CreateInstance(typeStr);
            switch (type){
                case NodeType.Action:
                    oNode = obj as NodeAction;
                    break;
                case NodeType.Condition:
                    oNode = obj as NodeCondition;
                    break;
                case NodeType.Decorator:
                    oNode = obj as NodeDecorator;
                    break;
                case NodeType.Parallel:
                    oNode = obj as NodeParallel;
                    break;
                case NodeType.Random:
                    oNode = obj as NodeRandom;
                    break;
                case NodeType.Select:
                    oNode = obj as NodeSelect;
                    break;
                case NodeType.Sequence:
                    oNode = obj as NodeSequence;
                    break;
                default:
                    oNode = null;
                    break;
            }
            if(oNode == null){
                Console.WriteLine("Node 找不到目标名 " + nodeName);
                return null;
            }
            oNode.Name = nodeName;
            oNode.RoleId = iId;
            
            // 根节点打印
            if(layer==0)
                Console.WriteLine(" - " + nodeName + " " + layer);

            if(nodesGeneratorDict.ContainsKey(nodeName)){
                int childLayer = layer + 1;
                foreach(Tuple<NodeType, string, object> childData in nodesGeneratorDict[nodeName]){
                    for (int i=0;i<4 * childLayer;i++){
                        Console.Write(" ");
                    }
                    Console.WriteLine(" - " + childData.Item2 + " " + childLayer);
                    oNode.AddChild(Init(iId, nodesGeneratorDict, childData, childLayer));
                }
            }
            return oNode;
        }
    }
}