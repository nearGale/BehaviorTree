using System;
using System.Collections;
using System.Collections.Generic;

namespace BehaviorTree{
    public class StudentAi{
        public static Dictionary<string, TupleList<NodeType, string, object>> nodesGeneratorDict = new Dictionary<string, TupleList<NodeType, string, object>>(){
            {
                Nodes.BTree_Root_Str, new TupleList<NodeType, string, object> {
                    {NodeType.Sequence, "Seq顺序节点1", null},
                }
            },
            {
                "Seq顺序节点1", new TupleList<NodeType, string, object>{
                    {NodeType.Condition, "Condi是否饿了", null},
                    {NodeType.Select, "Sel选择节点1", null},
                    {NodeType.Action, "Act移动", "Food"},
                    {NodeType.Action, "Act吃饭", null},
                }
            },
            {
                "Condi是否饿了", new TupleList<NodeType, string, object>{

                }
            },
            {
                "Sel选择节点1", new TupleList<NodeType, string, object>{
                    {NodeType.Condition, "Condi是否有饭", null},
                    {NodeType.Sequence, "Seq顺序节点2", null},
                }
            },
            {
                "Seq顺序节点2", new TupleList<NodeType, string, object>{
                    {NodeType.Action, "Act移动", "Cooking"},
                    {NodeType.Action, "Act做饭", null},
                }
            }
        };
    }
}