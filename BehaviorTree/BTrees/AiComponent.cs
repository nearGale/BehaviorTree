using System;
using System.Collections;
using System.Collections.Generic;

namespace BehaviorTree{
    public class AiComponent{
        NodeRoot root;

        public void Init(int iId, Dictionary<string, TupleList<NodeType, string, object>> nodesGeneratorDict){
            root = TreeConstructor.Init(iId, nodesGeneratorDict);
        }

        public void Update(){
            if (root != null)
            {
                root.Run();  // 每帧调用行为树根节点，行为树入口
            }
        }
    }
}