namespace BehaviorTree{
    /// <summary>
    /// 条件节点：是否饿了
    /// </summary>
    public class ConditionNode_IsHungry : NodeCondition {

        private Student student;

        public override ResultType Execute()
        {
            if(student == null)
                student = ObjManager.GetObj(RoleId) as Student;
            ResultType resultType = student.IsHungry() ? ResultType.Success : ResultType.Fail;
            return resultType;
        }
    }
}