namespace BehaviorTree{
    /// <summary>
    /// 条件节点：是否有饭
    /// </summary>
    public class ConditionNode_HasFood : NodeCondition {
        private Student student;

        public override ResultType Execute()
        {
            if(student == null)
                student = ObjManager.GetObj(RoleId) as Student;
            ResultType resultType = student.HasFood() ? ResultType.Success : ResultType.Fail;

            return resultType;
        }
    }
}